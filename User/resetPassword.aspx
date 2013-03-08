<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="resetPassword.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>Enter user name:</td>
            <td>
                <asp:TextBox ID="username" runat="server"></asp:TextBox></td>

            <td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="username" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z0-9._\-]{3,15}$" ValidationGroup="resetPass">Invalid username</asp:RegularExpressionValidator></td>

        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="resetPass" OnClick="Button1_Click" /></td>
        </tr>
        <tr><td>
            <asp:Label ID="status" runat="server" Text=""></asp:Label></td></tr>
    </table>
</asp:Content>

