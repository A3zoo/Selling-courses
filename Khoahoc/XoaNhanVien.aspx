<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="XoaNhanVien.aspx.cs" Inherits="Khoahoc.XoaNhanVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table class="auto-style22">
   <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>XÓA NHÂN VIÊN</strong></td>
    <tr class="auto-style6">
        <td class="auto-style25">
            <br />
            <asp:Label ID="lblFeedback" runat="server" class="auto-style20" style=" font-size: 25px;" Text="Bạn có muốn xóa nhân viên "></asp:Label>
            <asp:Label ID="lblTenNhanvienmain" runat="server" CssClass="auto-style21" style=" font-size: 25px;"></asp:Label>
            <br />
        </td>
        <td class="auto-style37"><strong>
            <br />
            <asp:Label ID="lblNhanvienid" runat="server" CssClass="auto-style19" style=" font-size: 25px;"></asp:Label>
        </strong>
        </td>
    </tr>
            <tr>
    <td class="auto-style7"style=" font-size: 25px;"><strong>Họ tên</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtHoTenNV" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Ngày sinh</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtNgaysinh" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
        <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Giới tính</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblGioitinh" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
            <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Điạ chỉ</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblDCNhanvien" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
                            <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Điện thoại</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblDTNhanvien" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
                            <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>CMND/CCCD</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblCCCD" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
                            <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Email</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblEmail" runat="server" style=" font-size: 25px;"></asp:Label>
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
     <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/NhanVien.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="130px" />
 </td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:Label ID="lblStatus" runat="server" CssClass="auto-style22" style=" font-size: 25px;"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" DeleteCommand="Delete from NHANVIEN where NHANVIEN_id=@NHANVIEN_id" SelectCommand="Select *from NHANVIEN">
    <DeleteParameters>
        <asp:Parameter Name="NHANVIEN_id" />
    </DeleteParameters>
</asp:SqlDataSource>
 
            
        </td>
    </tr>
</table>
</asp:Content>
