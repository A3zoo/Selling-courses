using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khoahoc
{
    public partial class SuaNhanVien : System.Web.UI.Page
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
        //protected void txtNgaysinh_TextChanged(object sender, EventArgs e)
        //{
        //    DateTime parsedDate;
        //    if (DateTime.TryParseExact(txtNgaysinh.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        //    {
        //        txtNgaysinh.Text = parsedDate.ToString("MM/dd/yyyy");
        //    }
        //}
        protected void LoadNV(string NHANVIEN_id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT NHANVIEN_id, HoTen, Ngaysinh, Gioitinh, Diachi, Sdt, CMND_CCCD, Email, TAIKHOAN_id FROM NHANVIEN WHERE NHANVIEN_id=" + "'" + NHANVIEN_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;

            lblHoTenNV.Text = dt.Rows[0]["HoTen"].ToString();
            lblNhanvien_id.Text = dt.Rows[0]["NHANVIEN_id"].ToString();
            txtHoTenNV.Text = dt.Rows[0]["HoTen"].ToString();

            DateTime ngaysinh;
            if (DateTime.TryParse(dt.Rows[0]["Ngaysinh"].ToString(), out ngaysinh))
            {
                txtNgaysinh.Text = ngaysinh.ToString("MM/dd/yyyy");
            }

            txtGioitinh.Text = dt.Rows[0]["Gioitinh"].ToString();
            txtDCNhanvien.Text = dt.Rows[0]["Diachi"].ToString();
            txtDTNhanvien.Text = dt.Rows[0]["Sdt"].ToString();
            txtCCCD.Text = dt.Rows[0]["CMND_CCCD"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            drpTaikhoan.SelectedValue = dt.Rows[0]["TAIKHOAN_id"].ToString();
        }
        //protected void LoadNV(string NHANVIEN_id)
        //{
        //    string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
        //    SqlConnection con = new SqlConnection(conStr);
        //    SqlDataAdapter adapt = new SqlDataAdapter("SELECT NHANVIEN_id, HoTen, Ngaysinh, Gioitinh, Diachi, Sdt, CMND_CCCD, Email, TAIKHOAN_id FROM NHANVIEN WHERE NHANVIEN_id=" + "'" + NHANVIEN_id + "'", con);
        //    DataTable dt = new DataTable();
        //    adapt.Fill(dt);
        //    if (dt.Rows.Count == 0)
        //        return;
        //    lblHoTenNV.Text = dt.Rows[0]["HoTen"].ToString();
        //    lblNhanvien_id.Text = dt.Rows[0]["NHANVIEN_id"].ToString();
        //    txtHoTenNV.Text = dt.Rows[0]["HoTen"].ToString();
        //    DateTime ngaysinh;

        //    DateTime ngaysinh;
        //    if (DateTime.TryParse(dt.Rows[0]["Ngaysinh"].ToString(), out ngaysinh))
        //    {
        //        txtNgaysinh.Text = ngaysinh.ToString("MM/dd/yyyy");
        //    }
        //    txtGioitinh.Text = dt.Rows[0]["Gioitinh"].ToString();
        //    txtDCNhanvien.Text = dt.Rows[0]["Diachi"].ToString();
        //    txtDTNhanvien.Text = dt.Rows[0]["Sdt"].ToString();
        //    txtCCCD.Text = dt.Rows[0]["CMND_CCCD"].ToString();
        //    txtEmail.Text = dt.Rows[0]["Email"].ToString();
        //    drpTaikhoan.Text = dt.Rows[0]["TAIKHOAN_id"].ToString();
        //    ViewState["NHANVIEN"] = dt;
        //}
        protected void txtNgaysinh_TextChanged(object sender, EventArgs e)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(txtNgaysinh.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                txtNgaysinh.Text = parsedDate.ToString("MM/dd/yyyy");
            }
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

                //DateTime ngaysinh;
                //if (!DateTime.TryParseExact(txtNgaysinh.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh))
                //{
                //    lblStatus.Text = "Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng MM/dd/yyyy.";
                //    return;
                //}
                DateTime ngaysinh;
                if (!DateTime.TryParseExact(txtNgaysinh.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh))
                {
                    lblStatus.Text = "Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng MM/dd/yyyy.";
                    return;
                }
                string updateQuery = "UPDATE NHANVIEN SET HoTen=@HoTen,Ngaysinh=@Ngaysinh, Gioitinh=@Gioitinh, Diachi=@Diachi,Sdt=@Sdt, CMND_CCCD=@CMND_CCCD, Email=@Email, TAIKHOAN_id=@TAIKHOAN_id WHERE NHANVIEN_id=@NHANVIEN_id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTenNV.Text);
                    cmd.Parameters.AddWithValue("@Ngaysinh",ngaysinh);
                    cmd.Parameters.AddWithValue("@Gioitinh", txtGioitinh.Text);
                    cmd.Parameters.AddWithValue("@Diachi", txtDCNhanvien.Text);
                    cmd.Parameters.AddWithValue("@Sdt", txtDTNhanvien.Text);
                    cmd.Parameters.AddWithValue("@CMND_CCCD", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@TAIKHOAN_id", drpTaikhoan.SelectedValue);

                    cmd.Parameters.AddWithValue("@NHANVIEN_id", lblNhanvien_id.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            lblStatus.Text = "Sửa thành công!";
        }
    }
}