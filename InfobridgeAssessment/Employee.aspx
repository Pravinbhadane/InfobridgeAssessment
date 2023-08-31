<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="InfobridgeAssessment.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Form</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 443px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtId" runat="server" Width="228px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="ADD" Width="81px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtName" runat="server" Width="230px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtDob" runat="server" Width="232px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="EDIT" Width="80px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtSex" runat="server" Width="231px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPhone" runat="server" Width="232px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="VIEW" Width="80px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtAdd" runat="server" Width="229px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Image"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:FileUpload ID="txtUploadImg" runat="server"  onchange="ImagePreview(this);"/>
                </td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="DELETE" Width="78px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
       <td width="30%" class="auto-style15" style="border: thin outset #3498DB" colspan="2">

                                   
                                    <asp:GridView ID="GridView1" runat="server"  ForeColor="#333333" Width="768px" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="Sex" HeaderText="Sex" />
                                            <%--<asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />--%>
                                            <asp:TemplateField HeaderText="Date Of Birth">
                                            <ItemTemplate >
                                                <asp:Label Id="labl" runat="server" DataFormateString="{0:dd/MM/yyyy}" HtmlEncode="false"
                                                    Text='<%#Eval("DateOfBirth","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemTemplate>
                                                    <img src="Images/<%#Eval("Image") %>" style="width:100px;height:100px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#FFCC66" ForeColor="#333333" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
                                    </asp:GridView>
                                </td>
                    <asp:Label ID="msgBox" runat="server"></asp:Label>
    </form>
</body>
</html>
