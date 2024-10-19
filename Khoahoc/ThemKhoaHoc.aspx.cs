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
    public partial class ThemKhoaHoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SELECT * FROM KHOAHOC1", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            string strFileUpload = "";
            try
            {
                if (upLogo.HasFile)
                {
                    strFileUpload = "~/image/" + upLogo.FileName;
                    string path = MapPath("~/image/") + upLogo.FileName;
                    upLogo.PostedFile.SaveAs(path);
                }
                adapt.InsertCommand = new SqlCommand("INSERT INTO KHOAHOC1 (KHOAHOC_id, Ten, Logo, Mota, Gia, DANHMUC_id, GIANGVIEN_id, NHANVIEN_id, Soluongdangky) VALUES " +
                    "(@KHOAHOC_id, " + "@Ten, @Logo, @Mota, @Gia,@DANHMUC_id, @GIANGVIEN_id, @NHANVIEN_id, @Soluongdangky)", con);
                adapt.InsertCommand.Parameters.AddWithValue("@KHOAHOC_id", txtKhoahocid.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Ten", txtTenKhoahoc.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Logo", strFileUpload);
                adapt.InsertCommand.Parameters.AddWithValue("@Mota", txtMotaKH.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@Gia", Convert.ToDouble(txtGiaKhoahoc.Text));
                adapt.InsertCommand.Parameters.AddWithValue("@DANHMUC_id", Convert.ToString(drpDanhmuc.SelectedValue));
                adapt.InsertCommand.Parameters.AddWithValue("@GIANGVIEN_id", Convert.ToString(drpGiangvien.SelectedValue));
                adapt.InsertCommand.Parameters.AddWithValue("@NHANVIEN_id", Convert.ToString(drpNhanvien.SelectedValue));
                adapt.InsertCommand.Parameters.AddWithValue("@Soluongdangky", Convert.ToDouble(txtSLDK.Text));


                DataRow row = dt.NewRow();
                row["KHOAHOC_id"] = "@KHOAHOC_id";
                row["Ten"] = "@Ten";
                row["Logo"] = "@Logo";
                row["Mota"] = "@Mota";
                row["Gia"] = Convert.ToDouble(txtGiaKhoahoc.Text);
                row["DANHMUC_id"] = Convert.ToString(drpDanhmuc.SelectedValue);
                row["GIANGVIEN_id"] = Convert.ToString(drpGiangvien.SelectedValue);
                row["NHANVIEN_id"] = Convert.ToString(drpNhanvien.SelectedValue);
                row["Soluongdangky"] = Convert.ToDouble(txtSLDK.Text);
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

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}