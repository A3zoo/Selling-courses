<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="Khoahoc.DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div {
            margin-bottom: 10px;
        }

        label, input {
            display: block;
        }

        h2 {
            margin-bottom: 20px;
        }
    </style>

    <h2>ĐĂNG KÝ</h2>

    <div>
        <asp:Label ID="Label4" runat="server" style="font-size: 25px;" Text="Email đăng nhập:" />
        <asp:TextBox ID="txtEmail" runat="server" style="font-size: 25px;"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" style="font-size: 25px;" Text="Mật khẩu:" />
        <asp:TextBox ID="txtPassword" runat="server" style="font-size: 25px;" TextMode="Password"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label ID="Label3" runat="server" style="font-size: 25px;" Text="Xác nhận mật khẩu:" />
        <asp:TextBox ID="txtConfirmPassword" runat="server" style="font-size: 25px;" TextMode="Password"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Button ID="btnRegister" runat="server" style="font-size: 30px;" Text="Đăng Ký" OnClick="btnRegister_Click" />
    </div>
    <br />
    <div>
        <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx" style="font-size: 20px;">Quay lại đăng nhập</asp:HyperLink>
    </div>
</asp:Content>
