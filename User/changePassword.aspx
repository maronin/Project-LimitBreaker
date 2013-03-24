<%@ Page Title="Use Case 5.7" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="changePassword.aspx.cs" Inherits="User_changePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <th>Change Password</th>
        </tr>
        <tr>
            <td>Old Password:</td>
            <td>
                <asp:TextBox ID="oldPassword" runat="server" TextMode="Password" ValidationGroup="password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox ID="newPassword" runat="server" TextMode="Password" ValidationGroup="password"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Please enter a password with a number that is at least 5 characters in length" ForeColor="Red"
                    ValidationExpression="^(?=.*\d)(?=.*[a-zA-Z]).{5,}$" Display="Dynamic"
                    ControlToValidate="newPassword" ValidationGroup="password"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Confirm Password:</td>
            <td>
                <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password" ValidationGroup="password"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newPassword" ControlToValidate="confirmPassword" ErrorMessage="Passwords must match" ForeColor="Red" ValidationGroup="createUser"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="status" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>

