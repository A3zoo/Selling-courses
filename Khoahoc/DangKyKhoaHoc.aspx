<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DangKyKhoaHoc.aspx.cs" Inherits="Khoahoc.DangKyKhoaHoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>ĐĂNG KÝ KHÓA HỌC</h2>
        <asp:GridView ID="grdDangKyKH" runat="server" Width="1132px" Font-Size="25px" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grdDangKyKH_RowDeleting"
            OnRowEditing="grdDangKyKH_RowEditing" OnRowUpdating="grdDangKyKH_RowUpdating" OnSelectedIndexChanged="grdDangKyKH_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Khoahoc_id" HeaderText="Mã khóa học" />
                <asp:BoundField DataField="TenKhoahoc" HeaderText="Tên Khóa học" />
              
                <asp:BoundField DataField="GiaKhoahoc" HeaderText="Đơn Giá" />
                <%--<asp:BoundField DataField="SLDK" HeaderText="Số lượng đăng ký" />--%>
                <%--<asp:TemplateField HeaderText="Số lượng">
                    <%--<ItemTemplate>
                        <asp:Label ID="lblSoLuong" runat="server" Text='<%# Eval("SoLuong") %>'></asp:Label>
                    </ItemTemplate>--%>
                    
                <%--</asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Thành tiền">
                    <ItemTemplate>
                        <asp:Label ID="lblTongTien" runat="server" Text='<%# Eval("TongTien", "{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>" SelectCommand="SELECT [KHOAHOC_id], [Ten], [Gia], [Soluongdangky] FROM [KHOAHOC1]"></asp:SqlDataSource>
    </div>
    <div style="margin-top: 20px;">
        <table>
            <tr>
                <td colspan="2">
                    <span style="font-size: 25px;"><strong>Thông tin đăng ký</strong></span>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" style="font-size: 25px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Điện thoại:</td>
                <td>
                    <asp:TextBox ID="txtDT" runat="server" style="font-size: 25px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnDangKy" runat="server" Text="Đăng Ký" OnClick="btnDangKy_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnTiepTuc" runat="server" Text="Tiếp tục đăng ký" PostBackUrl="~/TrangChu.aspx" CssClass="btn btn-success" />
                </td>
            </tr>
             

        </table>
    </div>
</asp:Content>



