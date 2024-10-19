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
    public partial class ThemGiangVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SELECT * FROM GIANGVIEN", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            string strFileUpload = "";
            try
            {
                
                adapt.InsertCommand = new SqlCommand("INSERT INTO GIANGVIEN (GIANGVIEN_id, Ho, Ten, Chuyennganh, Dienthoai, TAIKHOAN_id) VALUES " +
                    "(@GIANGVIEN_id, " + "@Ho, @Ten, @Chuyennganh, @Dienthoai,@TAIKHOAN_id)", con);
                adapt.InsertCommand.Parameters.AddWithValue("@GIANGVIEN_id", txtGiangvienid.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ho", txtHoGiangvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ten", txtTenGiangvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Chuyennganh", txtChuyennganh.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Dienthoai", txtDTGiangvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@TAIKHOAN_id", Convert.ToString(drpTaikhoan.SelectedValue));



                DataRow row = dt.NewRow();
                row["GIANGVIEN_id"] = "@GIANGVIEN_id";
                row["Ho"] = "@Ho";
                row["Ten"] = "@Ten";
                row["Chuyennganh"] = "@Chuyennganh";
                row["Dienthoai"] = "@Dienthoai";
                row["TAIKHOAN_id"] = Convert.ToString(drpTaikhoan.SelectedValue);
                dt.Rows.Add(row);
                adapt.Update(dt);
                lblStatus.Text = "Thêm thành công!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GiangVien.aspx");
        }
    }
}