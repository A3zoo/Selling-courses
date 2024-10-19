using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khoahoc
{
    public partial class DangXuat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (Session["LoggedInUser"] == null)
            {
                // Nếu chưa đăng nhập, chuyển hướng về trang đăng nhập
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Xóa session đăng nhập và chuyển hướng về trang đăng nhập
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}