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
    public partial class SuaKhoaHoc : System.Web.UI.Page
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
            lblTenKhoahoc.Text = dt.Rows[0]["Ten"].ToString();
            lblKhoahoc_id.Text = dt.Rows[0]["KHOAHOC_id"].ToString();
            txtTenKhoahoc.Text = dt.Rows[0]["Ten"].ToString();
            imgLogo.ImageUrl = dt.Rows[0]["Logo"].ToString();
            txtMotaKH.Text = dt.Rows[0]["Mota"].ToString();
            txtGiaKhoahoc.Text = dt.Rows[0]["Gia"].ToString();
            drpDanhmuc.SelectedValue = dt.Rows[0]["DANHMUC_id"].ToString();
            drpGiangvien.SelectedValue = dt.Rows[0]["GIANGVIEN_id"].ToString();
            drpNhanvien.SelectedValue = dt.Rows[0]["NHANVIEN_id"].ToString();
            txtSLDK.Text = dt.Rows[0]["Soluongdangky"].ToString();
            imgLogo.Height = 200;
            imgLogo.Width = 220;
            ViewState["KHOAHOC1"] = dt;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string strFileUpload = "";
                if (upLogo.HasFile)
                {
                    strFileUpload = "~/image/" + upLogo.FileName;
                    string path = MapPath(strFileUpload);
                    upLogo.SaveAs(path);
                }

                string updateQuery = "UPDATE KHOAHOC1 SET Ten=@Ten, Logo=@Logo, Mota=@Mota, Gia=@Gia, DANHMUC_id=@DANHMUC_id, GIANGVIEN_id=@GIANGVIEN_id, NHANVIEN_id=@NHANVIEN_id, Soluongdangky=@Soluongdangky WHERE KHOAHOC_id=@KHOAHOC_id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Ten", txtTenKhoahoc.Text);
                    cmd.Parameters.AddWithValue("@Logo", strFileUpload);
                    cmd.Parameters.AddWithValue("@Mota", txtMotaKH.Text);
                    cmd.Parameters.AddWithValue("@Gia", txtGiaKhoahoc.Text);
                    cmd.Parameters.AddWithValue("@DANHMUC_id", drpDanhmuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@GIANGVIEN_id", drpGiangvien.SelectedValue);
                    cmd.Parameters.AddWithValue("@NHANVIEN_id", drpNhanvien.SelectedValue);
                    cmd.Parameters.AddWithValue("@Soluongdangky", txtSLDK.Text);
                    cmd.Parameters.AddWithValue("@KHOAHOC_id", lblKhoahoc_id.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            lblStatus.Text = "Sửa thành công!";
        }
        //protected void btnLuu_Click(object sender, EventArgs e)
        //{
        //    string conStr = WebConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;
        //    SqlConnection con = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();

        //    string strFileUpload = "";
        //    if (upLogo.HasFile)
        //    {
        //        strFileUpload = "~/image/" + upLogo.FileName;
        //        string path = MapPath("~/image/") + upLogo.FileName;
        //        upLogo.PostedFile.SaveAs(path);
        //    }
        //    con.ConnectionString = conStr;
        //    cmd.Connection = con;
        //    con.Open();

        //    cmd.CommandText = "UPDATE KHOAHOC1 " +
        //        "SET Ten='" + txtTenKhoahoc.Text
        //        + ", Logo='" + strFileUpload + "'"
        //        + "', Mota='" + txtMotaKH.Text
        //        + "', Gia='" + txtGiaKhoahoc.Text
        //        + "', DANHMUC_id='" + drpDanhmuc.SelectedValue + "'"
        //        + "', GIANGVIEN_id='" + drpGiangvien.SelectedValue + "'"

        //        //+ ", HinhSP='" + strFileUpload + "'"
        //        + " WHERE KHOAHOC_id='" + lblKhoahoc_id.Text + "'";
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    lblStatus.Text = "Sửa thành công!";
        //}

    }
}