using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khoahoc
{
    public partial class Doimatkhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu mới và xác nhận mật khẩu không khớp.";
                return;
            }

            // Giả sử bạn có một phương thức để kiểm tra mật khẩu cũ và cập nhật mật khẩu mới
            bool isOldPasswordValid = ValidateOldPassword(oldPassword);
            if (!isOldPasswordValid)
            {
                lblMessage.Text = "Mật khẩu cũ không đúng.";
                return;
            }

            bool isPasswordChanged = ChangePassword(newPassword);
            if (isPasswordChanged)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Đổi mật khẩu thành công.";
            }
            else
            {
                lblMessage.Text = "Đã xảy ra lỗi trong quá trình đổi mật khẩu.";
            }
        }

        private bool ValidateOldPassword(string oldPassword)
        {
            // Giả sử bạn có logic để kiểm tra mật khẩu cũ ở đây
            // Ví dụ: Kiểm tra mật khẩu cũ từ cơ sở dữ liệu
            string storedPassword = "123456"; // Mật khẩu giả định lưu trong cơ sở dữ liệu
            return oldPassword == storedPassword;
        }

        private bool ChangePassword(string newPassword)
        {
            // Giả sử bạn có logic để cập nhật mật khẩu mới vào cơ sở dữ liệu
            // Ví dụ: Cập nhật mật khẩu trong cơ sở dữ liệu
            try
            {
                // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                return true; // Trả về true nếu cập nhật thành công
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
    }
}