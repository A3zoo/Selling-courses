<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TrangChuKhoaHocNoiBat.aspx.cs" Inherits="Khoahoc.TrangChuKhoaHocNoiBat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="TrangChu_KhoaHocNoiBat" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="lstKHOAHOC" runat="server" DataKeyField="KHOAHOC_id" DataSourceID="srcKhoaHocNoiBat" RepeatColumns="5" Style="text-align: center" Width="650px" Font-Bold="True" Font-Size="Large" Font-Strikeout="False" ForeColor="#006600">
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
    <asp:SqlDataSource ID="srcKhoaHocNoiBat" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [KHOAHOC_id], [Ten], [Logo], [Gia] FROM [KHOAHOC1] WHERE ([DANHMUC_id] = @DANHMUC_id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="DM002" Name="DANHMUC_id" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

