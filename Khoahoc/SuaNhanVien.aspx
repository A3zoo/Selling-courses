<%@ Page Title="" Language="C#" MasterPageFile="~/Quanly.Master" AutoEventWireup="true" CodeBehind="SuaNhanVien.aspx.cs" Inherits="Khoahoc.SuaNhanVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <table class="auto-style6">
     <tr>
     <td class="auto-style11" colspan="2" style="width:1167px; font-family: 'Times New Roman', Times, serif; font-size: 50px; color: #000000; font-weight: normal;"><strong>SỬA NHÂN VIÊN</strong></td>
 </tr>
    <tr>
        <td>
            <asp:Label ID="lblHoTenNV" runat="server" CssClass="auto-style15" style=" font-size: 25px;"></asp:Label>
        </td>
        <td class="auto-style19"><strong>
            <asp:Label ID="lblNhanvien_id" runat="server" style=" font-size: 25px;"></asp:Label>
        </strong>
        </td>
    </tr>
                    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Họ Tên</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtHoTenNV" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
    </td>
</tr>
    <tr>
            <td class="auto-style7" style=" font-size: 25px;"><strong>Ngày sinh</strong></td>
            <td class="auto-style10">
                <asp:TextBox ID="txtNgaysinh" runat="server" style=" font-size: 25px;" Width="380px" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
  <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                function formatDate(input) {
                    var date = new Date(input);
                    if (!isNaN(date.getTime())) {
                        var month = (date.getMonth() + 1).toString().padStart(2, '0');
                        var day = date.getDate().toString().padStart(2, '0');
                        var year = date.getFullYear();
                        return month + '/' + day + '/' + year;
                    }
                    return '';
                }
                document.addEventListener('DOMContentLoaded', function () {
                    var dateInput = document.getElementById('<%= txtNgaysinh.ClientID %>');
                    if (dateInput.value) {
                        dateInput.value = formatDate(dateInput.value);
                    }
                    dateInput.addEventListener('change', function () {
                        dateInput.value = formatDate(dateInput.value);
                    });
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
                    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Giới tính</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtGioitinh" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
    </td>
</tr>
            
    <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Địa chỉ</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtDCNhanvien" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
    </td>
</tr>
                            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Điện thoại</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtDTNhanvien" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
    </td>
</tr>
                            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>CMND/CCCD</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtCCCD" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
    </td>
</tr>
                            <tr>
    <td class="auto-style7" style=" font-size: 25px;"><strong>Email</strong></td>
    <td class="auto-style10">
        <asp:TextBox ID="txtEmail" runat="server" style=" font-size: 25px;" Width="380px"></asp:TextBox>
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

            <asp:Button ID="btnQuayLai" runat="server" Text="Quay Lại" PostBackUrl="~/NhanVien.aspx" BackColor="#006600" Font-Names="Times New Roman" Font-Size="30px" ForeColor="White" Width="157px" />
            <br />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </strong></td>
    </tr>
    <tr>
        <td class="auto-style4">
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KHOAHOCConnectionString2 %>"
            SelectCommand="SELECT * FROM [NHANVIEN]"
            UpdateCommand="UPDATE NHANVIEN SET HoTen = @HoTen, Ngaysinh = @Ngaysinh,Gioitinh =@Gioitinh,Diachi=@Diachi,Sdt=@Sdt,CMND_CCCD=@CMND_CCCD,Email=@Email, TAIKHOAN_id= @TAIKHOAN_id">
            <UpdateParameters>
                <asp:Parameter Name="HoTen" />
                <asp:Parameter Name="Ngaysinh" Type="DateTime" />
                <asp:Parameter Name="Gioitinh" />
                <asp:Parameter Name="Diachi" />
                <asp:Parameter Name="Sdt" />
                <asp:Parameter Name="CMND_CCCD" />
                <asp:Parameter Name="Email" />
                <asp:Parameter Name="TAIKHOAN_id" />
          
            </UpdateParameters>
        </asp:SqlDataSource>

        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
