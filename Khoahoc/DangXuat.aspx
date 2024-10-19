<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DangXuat.aspx.cs" Inherits="Khoahoc.DangXuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            font-size: medium;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center; margin: 0 auto;">
        <!-- Nội dung trang chủ của bạn -->
        <h1>Xin chào! Đây là trang chủ của bạn.</h1>
        
        <!-- Nút đăng xuất -->
        <asp:Button ID="btnLogout" runat="server" Text="Đăng xuất" OnClick="btnLogout_Click" CssClass="auto-style8" />
    </div>
</asp:Content>
