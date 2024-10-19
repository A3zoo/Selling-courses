<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="XoaGiangVien.aspx.cs" Inherits="Khoahoc.XoaGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style21 {
            width: 1113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style21">
   <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>XÓA GIẢNG VIÊN</strong></td>
    <tr class="auto-style6">
        <td class="auto-style25">
            <br />
            <asp:Label ID="lblFeedback" runat="server" class="auto-style20" style=" font-size: 25px;" Text="Bạn có muốn xóa giảng viên "></asp:Label>
            <asp:Label ID="lblTenGiangvienmain" runat="server" CssClass="auto-style21" style=" font-size: 25px;"></asp:Label>
            <br />
        </td>
        <td class="auto-style37"><strong>
            <br />
            <asp:Label ID="lblGiangvienid" runat="server" CssClass="auto-style19" style=" font-size: 25px;" ></asp:Label>
        </strong>
        </td>
    </tr>
            <tr>
    <td class="auto-style7"style=" font-size: 25px;"><strong>Họ</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtHoGiangvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Tên</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtTenGiangvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
        <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Chuyên ngành</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblChuyennganh" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
            <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Điện thoại</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblDTGiangvien" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
    <tr>
        <td class="auto-style33" style=" font-size: 25px;"><strong>Tài khoản</strong></td>
        <td class="auto-style34">
            <asp:Label ID="lblTaikhoan" runat="server" style=" font-size: 25px;"></asp:Label>
        </td>
    </tr>
        
    
    <tr>
        <td class="auto-style23">
     <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="130px" />
     <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/GiangVien.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="130px" />
 </td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:Label ID="lblStatus" runat="server" CssClass="auto-style22"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" DeleteCommand="Delete from GIANGVIEN where GIANGVIEN_id=@GIANGVIEN_id" SelectCommand="Select *from GIANGVIEN">
    <DeleteParameters>
        <asp:Parameter Name="GIANGVIEN_id" />
    </DeleteParameters>
</asp:SqlDataSource>
 
            
        </td>
    </tr>
</table>
</asp:Content>
