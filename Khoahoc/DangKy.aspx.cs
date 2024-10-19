using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khoahoc
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                // Display error message: Passwords do not match
                Response.Write("<script>alert('Mật khẩu không khớp. Vui lòng thử lại.');</script>");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["KHOAHOCConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                Response.Write("<script>alert('Chuỗi kết nối không được cấu hình đúng.');</script>");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TAIKHOAN (Email, Password) VALUES (@Email, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Display success message
                            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Đăng ký thành công!'); window.location.href = '~/Login.aspx';", true);
                        }
                        else
                        {
                            // Display error message if registration fails
                            Response.Write("<script>alert('Đăng ký không thành công. Vui lòng thử lại sau.');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Display error message
                        Response.Write("<script>alert('Đã xảy ra lỗi: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }
    
}