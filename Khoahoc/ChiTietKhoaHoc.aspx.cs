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
    public partial class ChiTietKhoaHoc : System.Web.UI.Page
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
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT KHOAHOC_id, Ten, Logo, Mota, Gia, DANHMUC_id, GIANGVIEN_id, Soluongdangky FROM KHOAHOC1 WHERE KHOAHOC_id=" + "'" + KHOAHOC_id + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
                return;
            lblKhoahoc_id.Text = dt.Rows[0]["KHOAHOC_id"].ToString();
            lblTenKhoahoc.Text = dt.Rows[0]["Ten"].ToString();
            imgLogo.ImageUrl = dt.Rows[0]["Logo"].ToString();
            lblMotaKH.Text = dt.Rows[0]["Mota"].ToString();
            lblGiaKhoahoc.Text = dt.Rows[0]["Gia"].ToString();
            lblDanhmuc.Text = dt.Rows[0]["DANHMUC_id"].ToString();
            lblGiangvien.Text = dt.Rows[0]["GIANGVIEN_id"].ToString();
            lblSLDK.Text = dt.Rows[0]["Soluongdangky"].ToString();
            imgLogo.Height = 200;
            imgLogo.Width = 220;
            ViewState["KHOAHOC1"] = dt;
        }
        protected void btnDangKyKH_Click(object sender, EventArgs e)
        {
            DataTable dtKH = (DataTable)ViewState["KHOAHOC"];
            if (dtKH == null || dtKH.Rows.Count == 0)
            {
                // Handle the error, possibly display a message to the user
                return;
            }

            DataTable dtDK;     // Gio hang
                                //int Soluong = 0;
            if (Session["DangKyKhoaHoc"] == null)    // tao gio hang
            {
                dtDK = new DataTable();
                dtDK.Columns.Add("KHOAHOC_id");
                dtDK.Columns.Add("Ten");
                dtDK.Columns.Add("Gia");
                dtDK.Columns.Add("TongTien");
            }
            else // lay dang ky tu Session
            {
                dtDK = (DataTable)Session["DangKyKhoaHoc"];
            }

            string KHOAHOC_id = (string)Session["KHOAHOC_id"];
            int pos = TimKhoahoc(KHOAHOC_id, dtDK);
            if (pos != -1)  // 
            {
                //cap nhat lai cot tong tien
                dtDK.Rows[pos]["TongTien"] = Convert.ToDouble(dtKH.Rows[0]["Gia"]);
            }
            else
            {
                DataRow dr = dtDK.NewRow();
                dr["KHOAHOC_id"] = dtKH.Rows[0]["KHOAHOC_id"];
                dr["Ten"] = dtKH.Rows[0]["Ten"];
                dr["Gia"] = dtKH.Rows[0]["Gia"];
                dr["TongTien"] = Convert.ToDouble(dtKH.Rows[0]["Gia"]);
                dtDK.Rows.Add(dr);
            }

            Session["DangKyKhoaHoc"] = dtDK;
            //  Label lbSoluong = (Label)this.Master.FindControl("lbSoluong");
            //lbSoluong.Text = dtGH.Rows.Count.ToString();
            Response.Redirect("DangKyKhoaHoc.aspx");
        }

        //protected void btnDangKyKH_Click(object sender, EventArgs e)
        //{
        //    DataTable dtKH = (DataTable)ViewState["KHOAHOC"];
        //    DataTable dtDK;     // Gio hang
        //    //int Soluong = 0;
        //    if (Session["DangKyKhoaHoc"] == null)    // tao gio hang
        //    {
        //        dtDK = new DataTable();
        //        dtDK.Columns.Add("KHOAHOC_id");
        //        dtDK.Columns.Add("Ten");
        //        dtDK.Columns.Add("Gia");
        //        dtDK.Columns.Add("TongTien");
        //    }
        //    else // lay dang ky tu Session
        //        dtDK = (DataTable)Session["DangKyKhoaHoc"];
        //    string KHOAHOC_id = (string)Session["KHOAHOC_id"];
        //    int pos = TimKhoahoc(KHOAHOC_id, dtDK);      
        //    if (pos != -1)  // 
        //    {
        //        //cap nhat lai cot tong tien

        //        dtDK.Rows[pos]["TongTien"] = Convert.ToDouble(dtKH.Rows[0]["Gia"]);
        //    }
        //    else    
        //    {

        //        DataRow dr = dtDK.NewRow();

        //        dr["KHOAHOC_id"] = dtKH.Rows[0]["KHOAHOC_id"];
        //        dr["Ten"] = dtKH.Rows[0]["Ten"];
        //        dr["Gia"] = dtKH.Rows[0]["Gia"];

        //        dr["TongTien"] = Convert.ToDouble(dtKH.Rows[0]["Gia"]) ;

        //        dtDK.Rows.Add(dr);
        //    }

        //    Session["DangKyKhoaHoc"] = dtDK;
        //    //  Label lbSoluong = (Label)this.Master.FindControl("lbSoluong");
        //    //lbSoluong.Text = dtGH.Rows.Count.ToString();
        //    Response.Redirect("DangKyKhoaHoc.aspx");
        //}
        public static int TimKhoahoc(string KHOAHOC_id, DataTable dt)
        {
            int pos = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["KHOAHOC_id"].ToString().ToLower() == KHOAHOC_id.ToLower())
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {

        }
    }
}