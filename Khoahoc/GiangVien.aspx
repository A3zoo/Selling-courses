﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="GiangVien.aspx.cs" Inherits="Khoahoc.GiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="box-sizing: border-box; margin: 0px 0px 20px; padding: 0px; border: 0px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-variant-alternates: inherit; font-variant-position: inherit; font-weight: 400; font-stretch: inherit; font-size: 20px; line-height: inherit; font-family: 'Times New Roman', Times, serif; font-optical-sizing: inherit; font-kerning: inherit; font-feature-settings: inherit; font-variation-settings: inherit; vertical-align: baseline; color: rgb(23, 23, 23); letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; text-align: justify;">
<span style="box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; font: inherit; vertical-align: baseline; color: rgb(0, 128, 0);"><span style="box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: inherit; font-stretch: inherit; font-size: 20px; line-height: inherit; font-family: inherit; font-optical-sizing: inherit; font-kerning: inherit; font-feature-settings: inherit; font-variation-settings: inherit; vertical-align: baseline;"><strong style="box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; font-style: inherit; font-variant: inherit; font-weight: 700; font-stretch: inherit; font-size: 50px; line-height: inherit; font-family: 'Times New Roman', Times, serif; font-optical-sizing: inherit; font-kerning: inherit; font-feature-settings: inherit; font-variation-settings: inherit; vertical-align: baseline; color: #000000;">DANH MỤC GIẢNG VIÊN</strong></span></span></p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ThemGiangVien.aspx" CssClass="auto-style3" style="font-size: 35px; color: #FF0000" BackColor="White" BorderColor="White" ForeColor="#006600">Thêm Giảng Viên </asp:HyperLink>
    <p class="auto-style11">
        <strong>&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [GIANGVIEN_id], [Ho], [Ten], [Chuyennganh], [Dienthoai], [TAIKHOAN_id] FROM [GIANGVIEN]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="GIANGVIEN_id" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#006600" CssClass="auto-style20"  style=" font-size: 25px;" Width="100%" BackColor="White" >
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:BoundField DataField="GIANGVIEN_id" HeaderText="Mã giảng viên" ReadOnly="True" SortExpression="GIANGVIEN_id" />
                 <asp:BoundField DataField="Ho" HeaderText="Họ" SortExpression="Ho" />
                 <asp:BoundField DataField="Ten" HeaderText="Tên" SortExpression="Ten" />
                 <asp:BoundField DataField="ChuyenNganh" HeaderText="Chuyên Ngành" SortExpression="ChuyenNganh" />
                 <asp:BoundField DataField="DienThoai" HeaderText="Điện Thoại" SortExpression="DienThoai" />
                 <asp:BoundField DataField="TAIKHOAN_id" HeaderText="Mã tài khoản" SortExpression="TAIKHOAN_id" />
                 
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemTemplate>
                            <asp:HyperLink ID="Sua" runat="server" Text="Sửa" NavigateUrl='<%# "SuaGiangVien.aspx?GIANGVIEN_id=" + Eval("GIANGVIEN_id") %>'></asp:HyperLink>
                            <asp:HyperLink ID="Xoa" runat="server" Text="Xóa" NavigateUrl='<%# "XoaGiangVien.aspx?GIANGVIEN_id=" + Eval("GIANGVIEN_id") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>


             </Columns>
             <EditRowStyle BackColor="#7C6F57" />
             <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White " />
             <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#E3EAEB" />
             <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F8FAFA" />
             <SortedAscendingHeaderStyle BackColor="#246B61" />
             <SortedDescendingCellStyle BackColor="#D4DFE1" />
             <SortedDescendingHeaderStyle BackColor="#15524A" />
         </asp:GridView>
     </strong>
 </p>
 </asp:Content>
