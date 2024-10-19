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
    public partial class ThemHocVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SELECT * FROM HOCVIEN", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            string strFileUpload = "";
            try
            {
                // Validate Gioitinh
                string gioitinh = txtGioitinh.Text;
                if (gioitinh != "Nam" && gioitinh != "Nu")
                {
                    lblStatus.Text = "Giới tính không hợp lệ. Vui lòng nhập 'Nam' hoặc 'Nu'.";
                    return;
                }

                adapt.InsertCommand = new SqlCommand("INSERT INTO HOCVIEN (HOCVIEN_id, Ho, Ten, Gioitinh, Diachi, TAIKHOAN_id) VALUES " +
                    "(@HOCVIEN_id, " + "@Ho, @Ten, @Gioitinh, @Diachi,@TAIKHOAN_id)", con);
                adapt.InsertCommand.Parameters.AddWithValue("@HOCVIEN_id", txtHocvienid.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ho", txtHoHocvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ten", txtTenHocvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Gioitinh", txtGioitinh.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Diachi", txtDCHocvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@TAIKHOAN_id", Convert.ToString(drpTaikhoan.SelectedValue));
       


                DataRow row = dt.NewRow();
                row["HOCVIEN_id"] = "@HOCVIEN_id";
                row["Ho"] = "@Ho";
                row["Ten"] = "@Ten";
                row["Gioitinh"] = "@Gioitinh";
                row["Diachi"] = "@Diachi";
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
            Response.Redirect("~/HocVien.aspx");
        }
    }
}