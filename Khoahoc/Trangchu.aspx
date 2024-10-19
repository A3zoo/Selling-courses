<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Trangchu.aspx.cs" Inherits="Khoahoc.Trangchu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="lstKHOAHOC" runat="server" DataKeyField="KHOAHOC_id" DataSourceID="scrMain" RepeatColumns="5" Style="text-align: center; margin-right: 0px;" Width="981px" Font-Bold="True" ForeColor="#006600">
    <ItemTemplate>
        Mã khóa học:
        <asp:Label ID="KHOAHOCidLabel" runat="server" Text='<%# Eval("KHOAHOC_id") %>' />
        <br />
        <asp:Label ID="TenLabel" runat="server" Text='<%# Eval("Ten") %>' Font-Size="X-Large" />
        <br />
        Giá:
       <asp:Label ID="GiaKhoaHocLabel" runat="server" Text='<%# Eval("Gia") + " VND" %>' ForeColor="Black" />
       <br />
       <asp:Image ID="imgHinh" runat="server" Height="250px" ImageUrl='<%# Eval("Logo") %>' Width="250px" />
       <br />
       <br />
       <asp:Button ID="btnXemChiTiet" runat="server" CssClass="auto-style18" Height="80px" BackColor="#006600" PostBackUrl='<%# "ChiTietKhoaHoc.aspx?KHOAHOC_id=" +  Eval("KHOAHOC_id") %>' Text="Xem chi tiết" fore ForeColor="White" />
       <br />
       <br />
    </ItemTemplate>
    </asp:DataList>
<asp:SqlDataSource ID="scrMain" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [KHOAHOC_id], [Ten], [Logo], [Gia] FROM [KHOAHOC1]"></asp:SqlDataSource>

</asp:Content>
