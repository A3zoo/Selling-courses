﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="ThemNhanVien.aspx.cs" Inherits="Khoahoc.ThemNhanVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <table class="auto-style3">
    <tr>
        <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>THÊM NHÂN VIÊN</strong></td>
    </tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Mã nhân viên</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="txtNhanvienid" runat="server" style=" font-size: 25px;"></asp:TextBox>
        </td>
    </tr>
     <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Họ Tên</strong></td>
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
        <td class="auto-style7" style=" font-size: 25px;"><strong>Giới tính</strong></td>
        <td class="auto-style10">
            <asp:TextBox ID="txtGioitinh" runat="server" style=" font-size: 25px;"></asp:TextBox>
        </td>
    </tr>
     <tr>
     <td class="auto-style7" style=" font-size: 25px;"><strong>Địa chỉ</strong></td>
     <td class="auto-style10">
         <asp:TextBox ID="txtDCNhanvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
     </td>
 </tr>
                        <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Điện thoại</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtDTNhanvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
                                            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>CMND/CCCD</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtCCCD" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
                                            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Email</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtEmail" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
    <tr>
        <td class="auto-style7" style=" font-size: 25px;"><strong>Mã tài khoản</strong></td>
        <td class="auto-style10">
            <asp:DropDownList ID="drpTaikhoan" runat="server" DataSourceID="SqlDataSource1" DataTextField="TAIKHOAN_id" DataValueField="TAIKHOAN_id" Height="70px" Width="150px" style=" font-size: 25px;">
            </asp:DropDownList>
        </td>
    </tr>
            
   
               
    <tr>
        <td class="auto-style14" colspan="2">
     <strong>
    <asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Height="42px" Width="150px" />
     </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong>
    <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/NhanVien.aspx" CssClass="auto-style7" OnClick="btnQuayLai_Click" BackColor="#006600" Font-Names="Times New Roman" ForeColor="White" Font-Size="30px" Height="43px" Width="150px" />
</strong>
            <br />
            <br />
            <em>
                <asp:Label ID="lblStatus" runat="server" CssClass="auto-style18"></asp:Label>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT * FROM [NHANVIEN]"></asp:SqlDataSource>
            </em>
        </td>
    </tr>
</table>
</asp:Content>
