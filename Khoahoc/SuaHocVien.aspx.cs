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
    public partial class SuaHocVien : System.Web.UI.Page
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
            lblTenHocvien.Text = dt.Rows[0]["Ten"].ToString();
            lblHocvien_id.Text = dt.Rows[0]["HOCVIEN_id"].ToString();
            txtHoHocvien.Text = dt.Rows[0]["Ho"].ToString();
            txtTenHocvien.Text = dt.Rows[0]["Ten"].ToString();
            txtGioitinh.Text = dt.Rows[0]["Gioitinh"].ToString();
            txtDCHocvien.Text = dt.Rows[0]["Diachi"].ToString();
            drpTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();
  
            ViewState["HOCVIEN"] = dt;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                // Validate Gioitinh
                string gioitinh = txtGioitinh.Text;
                if (gioitinh != "Nam" && gioitinh != "Nu")
                {
                    lblStatus.Text = "Giới tính không hợp lệ. Vui lòng nhập 'Nam' hoặc 'Nu'.";
                    return;
                }

                string updateQuery = "UPDATE HOCVIEN SET Ho=@Ho,Ten=@Ten, Gioitinh=@Gioitinh, Diachi=@Diachi, TAIKHOAN_id=@TAIKHOAN_id WHERE HOCVIEN_id=@HOCVIEN_id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Ho", txtHoHocvien.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenHocvien.Text);
                    cmd.Parameters.AddWithValue("@Gioitinh", txtGioitinh.Text);
                    cmd.Parameters.AddWithValue("@Diachi", txtDCHocvien.Text);
                    cmd.Parameters.AddWithValue("@TAIKHOAN_id", drpTaikhoan.SelectedValue);
                  
                    cmd.Parameters.AddWithValue("@HOCVIEN_id", lblHocvien_id.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            lblStatus.Text = "Sửa thành công!";
        }
    }
}