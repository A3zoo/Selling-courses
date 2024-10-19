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
    public partial class XoaNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string NHANVIEN_id = "";
                if (Request.QueryString["NHANVIEN_id"] != null)
                    NHANVIEN_id = Request.QueryString["NHANVIEN_id"];
                Session["NHANVIEN_id"] = NHANVIEN_id;
                LoadNV(NHANVIEN_id);
            }
        }
        protected void LoadNV(string NHANVIEN_id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT NHANVIEN_id, HoTen, Ngaysinh, Gioitinh, Diachi, Sdt, CMND_CCCD, Email, TAIKHOAN_id FROM NHANVIEN WHERE NHANVIEN_id=" + "'" + NHANVIEN_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;
            lblTenNhanvienmain.Text = dt.Rows[0]["HoTen"].ToString();
            lblNhanvienid.Text = dt.Rows[0]["NHANVIEN_id"].ToString();
            txtHoTenNV.Text = dt.Rows[0]["HoTen"].ToString();
            txtNgaysinh.Text = dt.Rows[0]["Ngaysinh"].ToString();
            lblGioitinh.Text = dt.Rows[0]["Gioitinh"].ToString();
            lblDCNhanvien.Text = dt.Rows[0]["Diachi"].ToString();
            lblDTNhanvien.Text = dt.Rows[0]["Sdt"].ToString();
            lblCCCD.Text = dt.Rows[0]["CMND_CCCD"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();

            ViewState["NHANVIEN"] = dt;
        }
        protected void LoadGVAfterRemove()
        {
            lblFeedback.Text = "";
            lblTenNhanvienmain.Text = "";
            lblNhanvienid.Text = "";
            txtHoTenNV.Text = "";
            txtNgaysinh.Text = "";
            lblGioitinh.Text = "";
            lblDCNhanvien.Text = "";
            lblDTNhanvien.Text = "";
            lblCCCD.Text = "";
            lblEmail.Text = "";
            lblTaikhoan.Text = "";

            lblStatus.Text = "Bạn đã xóa nhân viên thành công => Click nút [Quay lại] để trở về";
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {

            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "DELETE NHANVIEN WHERE NHANVIEN_id='" + lblNhanvienid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            LoadGVAfterRemove();
        }
    }
}