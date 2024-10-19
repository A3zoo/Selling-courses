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
    public partial class ThemNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SELECT * FROM NHANVIEN", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            
            try
            {
                // Validate Gioitinh
                string gioitinh = txtGioitinh.Text;
                if (gioitinh != "Nam" && gioitinh != "Nu")
                {
                    lblStatus.Text = "Giới tính không hợp lệ. Vui lòng nhập 'Nam' hoặc 'Nu'.";
                    return;
                }

                // Parse Ngaysinh
                DateTime ngaysinh;
                if (!DateTime.TryParseExact(txtNgaysinh.Text, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaysinh))
                {
                    lblStatus.Text = "Ngày sinh không hợp lệ. Vui lòng nhập theo định dạng MM/dd/yyyy.";
                    return;
                }


                adapt.InsertCommand = new SqlCommand("INSERT INTO NHANVIEN (NHANVIEN_id, HoTen,Ngaysinh, Gioitinh, Diachi,Sdt,CMND_CCCD,Email, TAIKHOAN_id) VALUES " +
                    "(@NHANVIEN_id, " + "@HoTen, @Ngaysinh, @Gioitinh, @Diachi, @Sdt, @CMND_CCCD, @Email,@TAIKHOAN_id)", con);
                adapt.InsertCommand.Parameters.AddWithValue("@NHANVIEN_id", txtNhanvienid.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@HoTen", txtHoTenNV.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                adapt.InsertCommand.Parameters.AddWithValue("@Gioitinh", txtGioitinh.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Diachi", txtDCNhanvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Sdt", txtDTNhanvien.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@CMND_CCCD", txtCCCD.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@TAIKHOAN_id", Convert.ToString(drpTaikhoan.SelectedValue));


                //DataRow row = dt.NewRow();
                //row["NHANVIEN_id"] = txtNhanvienid.Text;
                //row["HoTen"] = txtHoTenNV.Text;
                //row["Ngaysinh"] = ngaysinh; // Sử dụng biến ngaysinh đã chuyển đổi
                //row["Gioitinh"] = txtGioitinh.Text;
                //row["Diachi"] = txtDCNhanvien.Text;
                //row["Sdt"] = txtDTNhanvien.Text;
                //row["CMND_CCCD"] = txtCCCD.Text;
                //row["Email"] = txtEmail.Text;
                //row["TAIKHOAN_id"] = Convert.ToString(drpTaikhoan.SelectedValue);

                DataRow row = dt.NewRow();
                row["NHANVIEN_id"] = "@NHANVIEN_id";
                row["HoTen"] = "@HoTen";
                row["Ngaysinh"] = ngaysinh;
                row["Gioitinh"] = "@Gioitinh";
                row["Diachi"] = "@Diachi";
                row["Sdt"] = "@Sdt";
                row["CMND_CCCD"] = "@CMND_CCCD";
                row["Email"] = "@Email";
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
            Response.Redirect("~/NhanVien.aspx");
        }
    }
}