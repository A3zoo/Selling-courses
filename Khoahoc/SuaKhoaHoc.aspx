<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="SuaKhoaHoc.aspx.cs" Inherits="Khoahoc.SuaKhoaHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="auto-style6">
     <tr>
     <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>SỬA KHÓA HỌC</strong></td>
 </tr>
    <tr>
        <td>
            <asp:Label ID="lblTenKhoahoc" runat="server" CssClass="auto-style15" style=" font-size: 25px;"></asp:Label>
        </td>
        <td class="auto-style19"><strong>
            <asp:Label ID="lblKhoahoc_id" runat="server" style=" font-size: 25px;"></asp:Label>
        </strong>
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
    <td><strong><em>
        <asp:Image ID="imgLogo" runat="server" Height="200px" ImageUrl='<%# Eval("Logo") %>' Width="200px" />
        <asp:FileUpload ID="upLogo" runat="server" CssClass="auto-style14" style=" font-size: 25px;" />
    </em></strong></td>
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
        <td class="auto-style4">&nbsp;</td>
        <td><strong>
            <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="149px" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/KhoaHoc.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="157px" />
            <br />
            <asp:Label ID="lblStatus" runat="server" style=" font-size: 25px;"></asp:Label>
        </strong></td>
    </tr>
    <tr>
        <td class="auto-style4">
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>"
            SelectCommand="SELECT * FROM [KHOAHOC1]"
            UpdateCommand="UPDATE KHOAHOC1 SET Ten = @Ten,Mota =@Mota,Gia=@Gia, DANHMUC_id= @DANHMUC_id, GIANGVIEN_id=@GIANGVIEN_id,Soluongdangky=@Soluongdangky">
            <UpdateParameters>
                <asp:Parameter Name="Ten" />
                <asp:Parameter Name="Mota" />
                <asp:Parameter Name="Gia" />
                <asp:Parameter Name="DANHMUC_id" />
                <asp:Parameter Name="GIANGVIEN_id" />
                <asp:Parameter Name="Soluongdangky" />
            </UpdateParameters>
        </asp:SqlDataSource>

        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
