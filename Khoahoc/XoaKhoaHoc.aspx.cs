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
    public partial class XoaKhoaHoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string KHOAHOC_id = "";
                if (Request.QueryString["KHOAHOC_id"] != null)
                    KHOAHOC_id = Request.QueryString["KHOAHOC_id"];
                Session["KHOAHOC_id"] = KHOAHOC_id;
                LoadKH(KHOAHOC_id);
            }
        }
        protected void LoadKH(string KHOAHOC_id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT KHOAHOC_id, Ten, Logo, Mota, Gia, DANHMUC_id, GIANGVIEN_id, NHANVIEN_id, Soluongdangky FROM KHOAHOC1 WHERE KHOAHOC_id=" + "'" + KHOAHOC_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;
            lblTenKhoahocmain.Text = dt.Rows[0]["Ten"].ToString();
            lblKhoahocid.Text = dt.Rows[0]["KHOAHOC_id"].ToString();
            txtTenKhoahoc.Text = dt.Rows[0]["Ten"].ToString();
            imgLogo.ImageUrl = dt.Rows[0]["Logo"].ToString();
            lblMotaKH.Text = dt.Rows[0]["Mota"].ToString();
            lblGiaKhoahoc.Text = dt.Rows[0]["Gia"].ToString();
            lblDanhmuc.Text = dt.Rows[0]["DANHMUC_id"].ToString();
            lblGiangvien.Text = dt.Rows[0]["GIANGVIEN_id"].ToString();
            lblNhanvien.Text = dt.Rows[0]["NHANVIEN_id"].ToString();
            lblSLDK.Text = dt.Rows[0]["Soluongdangky"].ToString();
            imgLogo.Height = 200;
            imgLogo.Width = 220;
            ViewState["KHOAHOC1"] = dt;
        }
        protected void LoadKHAfterRemove()
        {
            lblFeedback.Text = "";
            lblTenKhoahocmain.Text = "";
            lblKhoahocid.Text = "";
            txtTenKhoahoc.Text = "";
            imgLogo.ImageUrl = "";
            lblMotaKH.Text = "";
            lblGiaKhoahoc.Text = "";
            lblDanhmuc.Text = "";
            lblGiangvien.Text = "";
            lblNhanvien.Text = "";
            lblSLDK.Text = "";
            lblStatus.Text = "Bạn đã xóa khóa học thành công => Click nút [Quay lại] để trở về";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DELETE KHOAHOC1 WHERE KHOAHOC_id='" + lblKhoahocid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            LoadKHAfterRemove();
        }
    }
}