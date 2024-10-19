<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="XoaKhoaHoc.aspx.cs" Inherits="Khoahoc.XoaKhoaHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style21 {
            height: 27px;
        }
        .auto-style22 {
            width: 931px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style22">
   <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>XÓA KHÓA HỌC</strong></td>
    <tr class="auto-style6">
        <td class="auto-style25">
            <br />
            <asp:Label ID="lblFeedback" runat="server" class="auto-style20" style=" font-size: 25px;" Text="Bạn có muốn xóa khóa học "></asp:Label>
            <asp:Label ID="lblTenKhoahocmain" runat="server" CssClass="auto-style21" style=" font-size: 25px;"></asp:Label>
            <br />
        </td>
        <td class="auto-style37"><strong>
            <br />
            <asp:Label ID="lblKhoahocid" runat="server" CssClass="auto-style19" style=" font-size: 25px;" ></asp:Label>
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
    <td class="auto-style35" style=" font-size: 25px;"><strong>Logo</strong></td>
    <td class="auto-style36"><strong><em>
        <asp:Image ID="imgLogo" runat="server" Height="200px" ImageUrl='<%# Eval("Logo") %>' Width="200px" />
    </em></strong></td>
</tr>
        <tr>
    <td class="auto-style21" style=" font-size: 25px;"><strong>Mô tả</strong></td>
    <td class="auto-style21">
        <asp:Label ID="lblMotaKH" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
    <tr>
        <td class="auto-style21" style=" font-size: 25px;"><strong>Giá</strong></td>
        <td class="auto-style21">
            <asp:Label ID="lblGiaKhoahoc" runat="server" style=" font-size: 25px;"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style33" style=" font-size: 25px;"><strong>Mã danh mục</strong></td>
        <td class="auto-style34">
            <asp:Label ID="lblDanhmuc" runat="server" style=" font-size: 25px;"></asp:Label>
        </td>
    </tr>
        <tr>
    <td class="auto-style33" style=" font-size: 25px;"><strong>Mã giảng viên</strong></td>
    <td class="auto-style34">
        <asp:Label ID="lblGiangvien" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
                <tr>
    <td class="auto-style33" style=" font-size: 25px;"><strong>Mã nhân viên</strong></td>
    <td class="auto-style34">
        <asp:Label ID="lblNhanvien" runat="server" style=" font-size: 25px;"></asp:Label>
    </td>
</tr>
         <tr>
     <td class="auto-style21" style=" font-size: 25px;"><strong>Số lượng đăng ký</strong></td>
     <td class="auto-style21">
         <asp:Label ID="lblSLDK" runat="server" style=" font-size: 25px;"></asp:Label>
     </td>
 </tr>
    
    <tr>
        <td class="auto-style23">
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="130px" />
            <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/KhoaHoc.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="130px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:Label ID="lblStatus" runat="server" CssClass="auto-style22" style=" font-size: 25px;"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style23">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" DeleteCommand="Delete from KHOAHOC1 where KHOAHOC_id=@KHOAHOC_id" SelectCommand="Select *from KHOAHOC1">
    <DeleteParameters>
        <asp:Parameter Name="KHOAHOC_id" />
    </DeleteParameters>
</asp:SqlDataSource>
 
            
        </td>
    </tr>
</table>
</asp:Content>
