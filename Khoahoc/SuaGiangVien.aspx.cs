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
    public partial class SuaGiangVien : System.Web.UI.Page
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
            lblTenGiangvien.Text = dt.Rows[0]["Ten"].ToString();
            lblGiangvien_id.Text = dt.Rows[0]["GIANGVIEN_id"].ToString();
            txtHoGiangvien.Text = dt.Rows[0]["Ho"].ToString();
            txtTenGiangvien.Text = dt.Rows[0]["Ten"].ToString();
            txtChuyennganh.Text = dt.Rows[0]["Chuyennganh"].ToString();
            txtDTGiangvien.Text = dt.Rows[0]["Dienthoai"].ToString();
            drpTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();
            ViewState["GIANGVIEN"] = dt;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string updateQuery = "UPDATE GIANGVIEN SET Ho=@Ho,Ten=@Ten, Chuyennganh=@Chuyennganh, Dienthoai=@Dienthoai, TAIKHOAN_id=@TAIKHOAN_id WHERE GIANGVIEN_id=@GIANGVIEN_id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Ho", txtHoGiangvien.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtTenGiangvien.Text);
                    cmd.Parameters.AddWithValue("@Chuyennganh", txtChuyennganh.Text);
                    cmd.Parameters.AddWithValue("@Dienthoai", txtDTGiangvien.Text);
                    cmd.Parameters.AddWithValue("@TAIKHOAN_id", drpTaikhoan.SelectedValue);
                    cmd.Parameters.AddWithValue("@GIANGVIEN_id", lblGiangvien_id.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            lblStatus.Text = "Sửa thành công!";
        }
    }
}