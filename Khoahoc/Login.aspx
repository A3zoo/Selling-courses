<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Khoahoc.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div style="text-align:center; margin: 0 auto;">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [Password], [Email] FROM [TAIKHOAN]"></asp:SqlDataSource>

            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Trangchu.aspx"
                BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderStyle="Groove" BorderWidth="5"
                LoginButtonText="Đăng nhập" Font-Names="Verdana" Font-Size="Medium" Height="400" Width="500"
                CreateUserText="Đăng ký" CreateUserUrl="~/DangKy.aspx"
                PasswordRecoveryText="Quên mật khẩu" PasswordRecoveryUrl="~/QuenMatKhau.aspx"
                BorderPadding="4" CssClass="auto-style8" ForeColor="#333333" TextLayout="TextOnLeft" OnAuthenticate="Login1_Authenticate" UserNameLabelText="Email:">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="#7CFC00" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="3"
                    Font-Size="Large" ForeColor="#1C5E55" Height="60" />
                <TextBoxStyle Font-Size="Large" Height="40" Width="350" />
                <TitleTextStyle BackColor="#7CFC00" Font-Bold="True" ForeColor="#FFFFFF" Font-Size="Large" />
            </asp:Login>
        </div>
 
</asp:Content>

<%--<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:Login ID="Login1" runat="server" CreateUserText="Đăng Ký" CreateUserUrl="~/DangKy.aspx" DestinationPageUrl="~/Admin/KhoaHoc.aspx" LoginButtonText="Đăng nhập" PasswordLabelText="Mật khẩu:" PasswordRecoveryText="Quên mật khẩu" PasswordRecoveryUrl="~/QuenMatKhau.aspx" RememberMeText="Nhớ mật khẩu cho lần tiếp theo" TitleText="ĐĂNG NHẬP" UserNameLabelText="Tên đăng nhập:" FailureText="Đăng nhập không thành công! Vui lòng thử lại." PasswordRequiredErrorMessage="Mật khẩu là bắt buộc." UserNameRequiredErrorMessage="Tên đăng nhập là bắt buộc." BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
    <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle Font-Bold="True" Font-Size="0.9em" BackColor="#1C5E55" ForeColor="White" />
            </asp:Login>
</asp:Content>--%>

