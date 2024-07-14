<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="CustomerManagementApp.Pages.CustomerDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var originalValues = {};

        
        function initializeOriginalValues() {
            originalValues['txtName'] = document.getElementById('<%= txtName.ClientID %>').value.trim();
            originalValues['txtDOB'] = document.getElementById('<%= txtDOB.ClientID %>').value.trim();
            originalValues['txtGender'] = document.getElementById('<%= txtGender.ClientID %>').value.trim();
            originalValues['txtOccupation'] = document.getElementById('<%= txtOccupation.ClientID %>').value.trim();
            originalValues['TextBox1'] = document.getElementById('<%= TextBox1.ClientID %>').value.trim();
            originalValues['TextBox2'] = document.getElementById('<%= TextBox2.ClientID %>').value.trim();
            originalValues['TextBox3'] = document.getElementById('<%= TextBox3.ClientID %>').value.trim();
        }

        
        function checkForChanges() {
            var currentValues = {
                'txtName': document.getElementById('<%= txtName.ClientID %>').value.trim(),
                'txtDOB': document.getElementById('<%= txtDOB.ClientID %>').value.trim(),
                'txtGender': document.getElementById('<%= txtGender.ClientID %>').value.trim(),
                'txtOccupation': document.getElementById('<%= txtOccupation.ClientID %>').value.trim(),
                'TextBox1': document.getElementById('<%= TextBox1.ClientID %>').value.trim(),
                'TextBox2': document.getElementById('<%= TextBox2.ClientID %>').value.trim(),
                'TextBox3': document.getElementById('<%= TextBox3.ClientID %>').value.trim()
            };

            for (var key in currentValues) {
                if (currentValues[key] !== originalValues[key]) {
                    return true; 
                }
            }

            return false;
        }

       
        function updateModifyButtonState() {
            var btnModify = document.getElementById('<%= btnUpdate.ClientID %>');
            if (checkForChanges()) {
                btnModify.disabled = false; 
            } else {
                btnModify.disabled = true; 
            }
        }

       
        function validateForm() {
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDOB = document.getElementById('<%= txtDOB.ClientID %>');
            var txtGender = document.getElementById('<%= txtGender.ClientID %>');
            var txtOccupation = document.getElementById('<%= txtOccupation.ClientID %>');
            var txtContactType = document.getElementById('<%= TextBox1.ClientID %>');
            var txtContactSubtype = document.getElementById('<%= TextBox2.ClientID %>');
            var txtContactValue = document.getElementById('<%= TextBox3.ClientID %>');

           
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
            initializeOriginalValues(); 
            updateModifyButtonState(); 

            
            var formElements = document.querySelectorAll('input[type=text], input[type=date], textarea');
            formElements.forEach(function (element) {
                element.addEventListener('change', function () {
                    updateModifyButtonState(); 
                });
            });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <div class="profile-header">Customer Profile</div>
            <img src="<%= ResolveUrl("~/Images/logo.jpg") %>" alt="Profile Picture" class="profile-pic" />
            <div class="profile-details">
                <table>
                    <asp:Label ID="lblCustomerId" runat="server" Visible="false"></asp:Label>
                    <tr>
                        <td>Name:</td>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date of Birth:</td>
                        <td><input type="date" id="txtDOB" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>Gender:</td>
                        <td><asp:TextBox ID="txtGender" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Age:</td>
                        <td><asp:Label ID="lblAge" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Occupation:</td>
                        <td><asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="contact-info">Contact</div>
            <div class="profile-details">
                <table>
                    <tr>
                        <td>Contact Type:</td>
                        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Subtype:</td>
                        <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Value:</td>
                        <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="buttons">
                <asp:Button ID="btnBackToDefault" runat="server" Text="Back" CssClass="back-button" OnClick="btnBackToDefault_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Modify" CssClass="modify navigate-away" OnClick="btnUpdate_Click" OnClientClick="return validateForm();" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this customer?');" />
            </div>
        </div>
    </form>
</body>
</html>
