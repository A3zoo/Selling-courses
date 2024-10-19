using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Khoahoc
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-{version}.min.js",
                    DebugPath = "~/Scripts/jquery-{version}.js",
                    CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-{version}.min.js",
                    CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-{version}.js",
                    CdnSupportsSecureConnection = true,
                    LoadSuccessExpression = "window.jQuery"
                });
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    string email = Login1.UserName;
        //    string password = Login1.Password;

        //    string connectionString = ConfigurationManager.ConnectionStrings["KHOAHOCConnectionString"].ConnectionString;

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE Email = @Email AND Password = @Password";
        //            using (SqlCommand command = new SqlCommand(sql, connection))
        //            {
        //                command.Parameters.AddWithValue("@Email", email);
        //                command.Parameters.AddWithValue("@Password", password);

        //                connection.Open();
        //                int count = (int)command.ExecuteScalar();

        //                if (count > 0)
        //                {
        //                    e.Authenticated = true;
        //                    Response.Redirect("~/Trangchu.aspx"); // Redirect to homepage after successful login
        //                }
        //                else
        //                {
        //                    e.Authenticated = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hiển thị lỗi khác
        //        Response.Write("<script>alert('Đã xảy ra lỗi: " + ex.Message + "');</script>");
        //        e.Authenticated = false;
        //    }
        //}

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string email = Login1.UserName;
            string password = Login1.Password;

            string connectionString = ConfigurationManager.ConnectionStrings["KHOAHOCConnectionString2"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Role FROM TAIKHOAN WHERE Email = @Email AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        connection.Open();
                        string role = command.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(role))
                        {
                            e.Authenticated = true;
                            if (email == "admin@gmail.com" && password == "admin" && role == "Admin")
                            {
                                Response.Redirect("~/NhanVien.aspx");
                            }

                            if (email == "lehuyenlinh@gmail.com" && password == "lehuyenlinh" && role == "Giảng viên")
                            {
                                Response.Redirect("~/KhoaHoc.aspx");
                            }
                            if (email == "lehuy@gmail.com" && password == "lehuy" && role == "Học viên")
                            {
                                Response.Redirect("~/Trangchu.aspx");
                            }
                            if (email == "nguyenha@gmail.com" && password == "nguyenha" && role == "Nhân viên")
                            {
                                Response.Redirect("~/HocVien.aspx");
                            }

                        }
                        else
                        {
                            e.Authenticated = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi khác
                Response.Write("<script>alert('Đã xảy ra lỗi: " + ex.Message + "');</script>");
                e.Authenticated = false;
            }
        }
    }
    
}