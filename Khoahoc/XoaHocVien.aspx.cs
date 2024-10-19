using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khoahoc
{
    public partial class XoaHocVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string HOCVIEN_id = "";
                if (Request.QueryString["HOCVIEN_id"] != null)
                    HOCVIEN_id = Request.QueryString["HOCVIEN_id"];
                Session["HOCVIEN_id"] = HOCVIEN_id;
                LoadHV(HOCVIEN_id);
            }
        }

        protected void LoadHV(string HOCVIEN_id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT HOCVIEN_id, Ho, Ten, Gioitinh, Diachi, TAIKHOAN_id FROM HOCVIEN WHERE HOCVIEN_id=" + "'" + HOCVIEN_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;
            lblTenHocvienmain.Text = dt.Rows[0]["Ten"].ToString();
            lblHocvienid.Text = dt.Rows[0]["HOCVIEN_id"].ToString();
            txtHoHocvien.Text = dt.Rows[0]["Ho"].ToString();
            txtTenHocvien.Text = dt.Rows[0]["Ten"].ToString();
            lblGioitinh.Text = dt.Rows[0]["Gioitinh"].ToString();
            lblDCHocvien.Text = dt.Rows[0]["Diachi"].ToString();
            lblTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();
    
            ViewState["HOCVIEN"] = dt;
        }
        protected void LoadGVAfterRemove()
        {
            lblFeedback.Text = "";
            lblTenHocvienmain.Text = "";
            lblHocvienid.Text = "";
            txtHoHocvien.Text = "";
            txtTenHocvien.Text = "";
            lblGioitinh.Text = "";
            lblDCHocvien.Text = "";
            lblTaikhoan.Text = "";
 
            lblStatus.Text = "Bạn đã xóa học viên thành công => Click nút [Quay lại] để trở về";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DELETE HOCVIEN WHERE HOCVIEN_id='" + lblHocvienid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            LoadGVAfterRemove();
        }
    }
}