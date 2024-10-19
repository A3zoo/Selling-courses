<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChiTietKhoaHoc.aspx.cs" Inherits="Khoahoc.ChiTietKhoaHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style26 {
            height: 162px;
            width: 452px;
        }
        .auto-style27 {
            width: 452px;
        }
        .auto-style28 {
            width: 1193px;
        }
        .auto-style29 {
            width: 184px;
        }
        .auto-style30 {
            width: 184px;
            height: 162px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style28">
    <tr>
        <td class="auto-style11" colspan="2" style="font-size: 40px;"><strong>CHI TIẾT KHÓA HỌC </strong></td>
    </tr>
        <tr>
    <td class="auto-style29" style="font-size: 25px;"><strong>Mã Khóa Học: </strong></td>
    <td class="auto-style27">
        <strong>
        <asp:Label ID="lblKhoahoc_id" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
        </strong>
    </td>
</tr>
    <tr>
        <td class="auto-style29" style="font-size: 25px;"><strong>Tên Khóa Học: </strong></td>
        <td class="auto-style27">
            <strong>
            <asp:Label ID="lblTenKhoahoc" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
            </strong>
        </td>
    </tr>
   
    <tr>
        <td class="auto-style29" style="font-size: 25px;"><strong>Giá Khóa Học: </strong></td>
        <td class="auto-style27">
            <strong>
            <asp:Label ID="lblGiaKhoahoc" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td class="auto-style29" style="font-size: 25px;"><strong>Mô tả:</strong></td>
        <td class="auto-style27">
            <strong>
            <asp:Label ID="lblMotaKH" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
            </strong>
        </td>
    </tr>
            <tr>
    <td class="auto-style29" style="font-size: 25px;"><strong>Danh mục:</strong></td>
    <td class="auto-style27">
        <strong>
        <asp:Label ID="lblDanhmuc" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
        </strong>
    </td>
</tr>
    <tr>
    <td class="auto-style29" style=" font-size: 25px;"><strong>Giảng viên:</strong></td>
    <td class="auto-style27">
        <strong>
        <asp:Label ID="lblGiangvien" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
        </strong>
    </td>
</tr>
    <tr>
        <td class="auto-style29">&nbsp;</td>
        <td class="auto-style27">
            <asp:Image ID="imgLogo" runat="server" Height="96px" Width="107px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style29" style="font-size: 25px;"><strong>Số lượng đăng ký: </strong></td>
        <td class="auto-style27">
            <strong>
             <asp:Label ID="lblSLDK" runat="server" CssClass="auto-style14" Font-Size="X-Large"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td class="auto-style30"></td>
        <td class="auto-style26"><strong>
            <asp:Button ID="btnDangKyKH" runat="server" CssClass="auto-style21" PostBackUrl="~/DangKyKhoaHoc.aspx" OnClick="btnDangKyKH_Click" Text="Đăng ký" BackColor="#006600" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="White" Height="58px" Width="198px" />
        </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><asp:Button ID="btnQuayLai" runat="server" CssClass="auto-style21" PostBackUrl="~/TrangChu.aspx" Text="Quay lại" BackColor="#006600" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="White" Height="56px" Width="207px" OnClick="btnQuayLai_Click" />
            </strong>&nbsp;<strong><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [KHOAHOC_id], [Ten], [Logo], [Mota], [Gia], [DANHMUC_id], [GIANGVIEN_id], [Soluongdangky] FROM [KHOAHOC1]" />
</asp:Content>
