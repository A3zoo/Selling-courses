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
    public partial class XoaGiangVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string GIANGVIEN_id = "";
                if (Request.QueryString["GIANGVIEN_id"] != null)
                    GIANGVIEN_id = Request.QueryString["GIANGVIEN_id"];
                Session["GIANGVIEN_id"] = GIANGVIEN_id;
                LoadGV(GIANGVIEN_id);
            }
        }
        protected void LoadGV(string GIANGVIEN_id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT GIANGVIEN_id, Ho, Ten, Chuyennganh, Dienthoai, TAIKHOAN_id FROM GIANGVIEN WHERE GIANGVIEN_id=" + "'" + GIANGVIEN_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;
            lblTenGiangvienmain.Text = dt.Rows[0]["Ten"].ToString();
            lblGiangvienid.Text = dt.Rows[0]["GIANGVIEN_id"].ToString();
            txtHoGiangvien.Text = dt.Rows[0]["Ho"].ToString();
            txtTenGiangvien.Text = dt.Rows[0]["Ten"].ToString();
            lblChuyennganh.Text = dt.Rows[0]["Chuyennganh"].ToString();
            lblDTGiangvien.Text = dt.Rows[0]["Dienthoai"].ToString();
            lblTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();
            
            ViewState["GIANGVIEN"] = dt;
        }
        protected void LoadGVAfterRemove()
        {
            lblFeedback.Text = "";
            lblTenGiangvienmain.Text = "";
            lblGiangvienid.Text = "";
            txtHoGiangvien.Text = "";
            txtTenGiangvien.Text = "";
            lblChuyennganh.Text = "";
            lblDTGiangvien.Text = "";
            lblTaikhoan.Text = "";
            lblStatus.Text = "Bạn đã xóa giảng viên thành công => Click nút [Quay lại] để trở về";
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DELETE GIANGVIEN WHERE GIANGVIEN_id='" + lblGiangvienid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            LoadGVAfterRemove();
        }
    }
}