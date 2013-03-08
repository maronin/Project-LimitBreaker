<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="User_changePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>Old Password</td>
            <td>
                <asp:TextBox ID="oldPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:Label ID="oldPassLbl" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td>New Password</td>
            <td>
                <asp:TextBox ID="newPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Please enter a password with a number that is at least 5 characters in length" ForeColor="Red"
                    ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z]).{5,}$" Display="Dynamic"
                    ControlToValidate="newPass" ValidationGroup="changePassword"></asp:RegularExpressionValidator></td>
            </td>
        </tr>
        <tr>
            <td>New Password</td>
            <td>
                <asp:TextBox ID="confirmPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newPass" ControlToValidate="confirmPass" ErrorMessage="Paasswords must match" ForeColor="Red" ValidationGroup="changePassword"></asp:CompareValidator></td>

        </tr>
        <tr>
            <td><asp:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="newPass"></asp:PasswordStrength></td>
        </tr>
        <tr><td>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></td></tr>
        <tr><td>
            <asp:Label ID="status" runat="server" Text=""></asp:Label></td></tr>

    </table>
</asp:Content>

