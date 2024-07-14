<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerManagementApp.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/DStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
        function validateFormOnNavigation() {
           
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDOB = document.getElementById('<%= txtDOB.ClientID %>');
            var txtGender = document.getElementById('<%= txtGender.ClientID %>');
            var txtOccupation = document.getElementById('<%= txtOccupation.ClientID %>');
            var txtContactType = document.getElementById('<%= txtContactType.ClientID %>');
            var txtContactSubtype = document.getElementById('<%= txtContactSubtype.ClientID %>');
            var txtContactValue = document.getElementById('<%= txtContactValue.ClientID %>');

           
            if (txtName.value.trim() === '' ||
                txtDOB.value.trim() === '' ||
                txtGender.value.trim() === '' ||
                txtOccupation.value.trim() === '' ||
                txtContactType.value.trim() === '' ||
                txtContactSubtype.value.trim() === '' ||
                txtContactValue.value.trim() === '') {
                alert('Please fill in all fields.');
                return false; 
            }

            return true; 
        }

       
        window.onload = function () {
            var navigationElements = document.querySelectorAll('.navigate-away');
            navigationElements.forEach(function (element) {
                element.addEventListener('click', function (event) {
                    if (!validateFormOnNavigation()) {
                        event.preventDefault(); 
                    }
                });
            });
        };
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Customer Input Form -->
            <div class="header">Add Customer</div>
            <div class="form-section">
                <table>
                    <tr>
                        <td>Name:</td>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date of Birth:</td>
                        <td><input type="date" id="txtDOB" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Gender:</td>
                        <td><asp:TextBox ID="txtGender" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Occupation:</td>
                        <td><asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Type:</td>
                        <td><asp:TextBox ID="txtContactType" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Subtype:</td>
                        <td><asp:TextBox ID="txtContactSubtype" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Value:</td>
                        <td><asp:TextBox ID="txtContactValue" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="buttons">
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnAddOrUpdate_Click" CssClass="btn-save navigate-away"/>
                </div>
            </div>
            
            <!-- Customer List -->
            <div class="header">Customer List</div>
            <div class="grid-view">
                <asp:GridView ID="GridViewCustomers" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewCustomers_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" Visible="false" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <div class=".action-button">
                                    <asp:Button runat="server" Text="Edit Customer Profile" CommandName="ViewDetails" CommandArgument='<%# Eval("CustomerId") %>' CssClass="btn-details" />
                                </div>   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
