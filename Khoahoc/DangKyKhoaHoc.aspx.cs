using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace Khoahoc
{
    public partial class DangKyKhoaHoc : System.Web.UI.Page
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }
        protected void LoadData()
        {
            dt = (DataTable)Session["DangKyKhoaHoc"];
            grdDangKyKH.DataSource = dt;
            grdDangKyKH.DataBind();
            
        }

        protected double TinhTongTien(DataTable dt)
        {
            if (dt == null)
                return 0;
            double sum = 0;
            foreach (DataRow row in dt.Rows)
                sum += Convert.ToDouble(row["TongTien"]);
            return sum;
        }

        protected int TinhTongSoLuong(DataTable dt)
        {
            if (dt == null)
                return 0;
            int sum = 0;
            foreach (DataRow row in dt.Rows)
                sum += Convert.ToInt32(row["SoLuong"]);
            return sum;
        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string email = txtEmail.Text.Trim();
                string dt = txtDT.Text.Trim();

                // Gửi email thông tin đăng ký
                SendEmail(email, dt);

                // Xử lý lưu thông tin đăng ký vào cơ sở dữ liệu (nếu có)

                // Xóa dữ liệu đăng ký sau khi xử lý thành công
                Session["DangKyKhoaHoc"] = null;
                LoadData();

                // Hiển thị thông báo thành công
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Đăng ký thành công!');", true);

                // Xóa nội dung textbox để chuẩn bị cho lần đăng ký tiếp theo
                txtEmail.Text = "";
                txtDT.Text = "";
            }
        }

        private void SendEmail(string recipientEmail, string phoneNumber)
        {
            MailMessage mail = new MailMessage("your-email@gmail.com", recipientEmail);
            mail.Subject = "Thông tin đăng ký khóa học";
            mail.Body = "Thông tin đăng ký khóa học của bạn:\n\n";
            mail.Body += GetGridviewData(grdDangKyKH) + "\n\n";
            mail.Body += "Điện thoại: " + phoneNumber + "\n\n";
            mail.Body += "Xin cảm ơn đã đăng ký!";
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("your-email@gmail.com", "your-password");

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi gửi email (nếu cần)
                throw ex;
            }
        }

        private string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (GridViewRow row in gv.Rows)
            {
                strBuilder.Append("Mã khóa học: " + row.Cells[0].Text);
                strBuilder.Append(", Tên khóa học: " + row.Cells[1].Text);
                strBuilder.Append(", Mô tả: " + row.Cells[2].Text);
                strBuilder.Append(", Đơn giá: " + row.Cells[3].Text);
                strBuilder.Append(", Số lượng: " + ((TextBox)row.Cells[4].FindControl("txtSoLuong")).Text);
                strBuilder.Append(", Thành tiền: " + row.Cells[5].Text + "\n");
            }
            return strBuilder.ToString();
        }
        protected void grdDangKyKH_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)Session["DangKyKhoaHoc"];
            dt.Rows.RemoveAt(e.RowIndex);
            Session["DangKyKhoaHoc"] = dt;
            LoadData();
        }

        protected void grdDangKyKH_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdDangKyKH.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void grdDangKyKH_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            dt = (DataTable)Session["DangKyKhoaHoc"];
            GridViewRow row = grdDangKyKH.Rows[e.RowIndex];
            TextBox txtSoLuong = (TextBox)row.FindControl("txtSoLuong");
            dt.Rows[row.DataItemIndex]["SoLuong"] = txtSoLuong.Text;
            dt.Rows[row.DataItemIndex]["TongTien"] = Convert.ToDouble(dt.Rows[row.DataItemIndex]["Gia"]) * Convert.ToInt32(txtSoLuong.Text);
            grdDangKyKH.EditIndex = -1;
            Session["DangKyKhoaHoc"] = dt;
            LoadData();
        }
        protected void grdDangKyKH_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdDangKyKH.EditIndex = -1;
            LoadData();
        }

        protected void grdDangKyKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Để sử dụng RenderControl, không cần base.VerifyRenderingInServerForm(control);
        }

        protected void btnDatHang_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage("lehuy@gmail.com", txtEmail.Text);
            mail.Subject = "Mua đồ uống";
            mail.Body += "- Vui lòng kiểm tra thông tin đơn hàng của bạn: <br/><br/>";
            mail.Body += GetGridviewData(grdDangKyKH) + "<br/><br/>";
            mail.Body += "- Điện thoại của bạn: " + txtDT.Text + "<br/><br/>";

            mail.Body += "- Xin cảm ơn đã mua hàng của chúng tôi!";
            mail.Body += "- Password WiFi: 29292929";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("lehuy@gmail.com", "lehuy");
            smtp.Send(mail);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email đã được gửi!');", true);
            txtEmail.Text = null;
            txtDT.Text = null;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}