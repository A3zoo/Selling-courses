<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="ThemKhoaHoc.aspx.cs" Inherits="Khoahoc.ThemKhoaHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style7 {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style3">
    <tr>
        <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>THÊM KHÓA HỌC</strong></td>
    </tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Khoahoc_id</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="txtKhoahocid" runat="server" style=" font-size: 25px;"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Tên khóa học</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="txtTenKhoahoc" runat="server" style=" font-size: 25px;"></asp:TextBox>
        </td>
    </tr>
             <tr>
     <td class="auto-style7" style=" font-size: 25px;"><strong>Logo</strong></td>
     <td class="auto-style10">
         <asp:FileUpload ID="upLogo" runat="server" style=" font-size: 25px;" />
     </td>
 </tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Mô tả</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="txtMotaKH" runat="server" style=" font-size: 25px;"></asp:TextBox>
        </td>
    </tr>
     <tr>
     <td class="auto-style7" style=" font-size: 25px;"><strong>Giá</strong></td>
     <td class="auto-style10">
         <asp:TextBox ID="txtGiaKhoahoc" runat="server" style=" font-size: 25px;"></asp:TextBox>
     </td>
 </tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Mã danh mục</strong></td>
        <td class="auto-style10">
            <asp:DropDownList ID="drpDanhmuc" runat="server" DataSourceID="SqlDataSource1" DataTextField="DANHMUC_id" DataValueField="DANHMUC_id" Height="70px" Width="150px" style=" font-size: 25px;">
            </asp:DropDownList>
        </td>
    </tr>
            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Mã giảng viên</strong></td>
    <td class="auto-style10">
        <asp:DropDownList ID="drpGiangvien" runat="server" DataSourceID="SqlDataSource1" DataTextField="GIANGVIEN_id" DataValueField="GIANGVIEN_id" Height="70px" Width="150px" style=" font-size: 25px;">
        </asp:DropDownList>
    </td>
</tr>
               <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Mã nhân viên</strong></td>
    <td class="auto-style10">
        <asp:DropDownList ID="drpNhanvien" runat="server" DataSourceID="SqlDataSource1" DataTextField="NHANVIEN_id" DataValueField="NHANVIEN_id" Height="70px" Width="150px" style=" font-size: 25px;">
        </asp:DropDownList>
    </td>
</tr>
                <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Số lượng đăng ký</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtSLDK" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
    <tr>
        <td class="auto-style14" colspan="2">
            <strong>
                <asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Height="42px" Width="150px" />
            </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong>
            <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/KhoaHoc.aspx" CssClass="auto-style7" OnClick="btnQuayLai_Click" BackColor="#006600" Font-Names="Times New Roman" ForeColor="White" Font-Size="30px" Height="43px" Width="150px" />
        </strong>
            <br />
            <br />
            <em>
                <asp:Label ID="lblStatus" runat="server" CssClass="auto-style18"></asp:Label>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [KHOAHOC_id], [Ten], [Logo], [Mota], [Gia], [DANHMUC_id], [GIANGVIEN_id],[NHANVIEN_id], [Soluongdangky] FROM [KHOAHOC1]"></asp:SqlDataSource>
            </em>
        </td>
    </tr>
</table>
</asp:Content>
