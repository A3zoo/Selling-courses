﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="SuaGiangVien.aspx.cs" Inherits="Khoahoc.SuaGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table class="auto-style6">
     <tr>
     <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>SỬA GIẢNG VIÊN</strong></td>
 </tr>
    <tr>
        <td>
            <asp:Label ID="lblTenGiangvien" runat="server" CssClass="auto-style15" style=" font-size: 25px;"></asp:Label>
        </td>
        <td class="auto-style19"><strong>
            <asp:Label ID="lblGiangvien_id" runat="server" style=" font-size: 25px;"></asp:Label>
        </strong>
        </td>
    </tr>
                    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Họ</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtHoGiangvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Tên </strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtTenGiangvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
                    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Chuyên ngành</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtChuyennganh" runat="server" style=" font-size: 25px;"></asp:TextBox>
    </td>
</tr>
            
    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Điện thoại</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtDTGiangvien" runat="server" style=" font-size: 25px;"></asp:TextBox>
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
        <td class="auto-style4">&nbsp;</td>
        <td><strong>
            <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="149px" />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/GiangVien.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="157px" />
            <br />
            <asp:Label ID="lblStatus" runat="server" style=" font-size: 25px;"></asp:Label>
        </strong></td>
    </tr>
    <tr>
        <td class="auto-style4">
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>"
            SelectCommand="SELECT * FROM [GIANGVIEN]"
            UpdateCommand="UPDATE GIANGVIEN SET Ho = @Ho, Ten = @Ten,Chuyennganh =@Chuyennganh,Dienthoai=@Dienthoai, TAIKHOAN_id= @TAIKHOAN_id">
            <UpdateParameters>
                <asp:Parameter Name="Ho" />
                <asp:Parameter Name="Ten" />
                <asp:Parameter Name="Chuyennganh" />
                <asp:Parameter Name="Dienthoai" />
                <asp:Parameter Name="TAIKHOAN_id" />
            </UpdateParameters>
        </asp:SqlDataSource>

        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
