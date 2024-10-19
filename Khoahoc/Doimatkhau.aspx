<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Doimatkhau.aspx.cs" Inherits="Khoahoc.Doimatkhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-container {
            width: 300px;
            margin: 0 auto;
            text-align: center;
        }
        .form-field {
            margin-bottom: 15px;
        }
        .auto-style25 {
            width: 300px;
            margin: 0 auto 0 0px;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="auto-style25" style="font-family: 'Times New Roman', Times, serif; font-size: x-large" >
        <h2>Đổi mật khẩu</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="form-field" Font-Size="X-Large">
            <asp:Label ID="lblOldPassword" runat="server" Text="Mật khẩu cũ"></asp:Label><br />
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-field" Font-Size="X-Large">
            <asp:Label ID="lblNewPassword" runat="server" Text="Mật khẩu mới"></asp:Label><br />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-field" Font-Size="X-Large">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Xác nhận mật khẩu mới"></asp:Label><br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="btnChangePassword" runat="server" Font-Size="X-Large" Text="Đổi mật khẩu" OnClick="btnChangePassword_Click" />
    </div>
</asp:Content>