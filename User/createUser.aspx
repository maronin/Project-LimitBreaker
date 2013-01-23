<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="createUser.aspx.cs" Inherits="User_createUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 312px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <table>
        <tr><td>Create New User</td></tr>
        <tr><td>Username:</td><td><asp:TextBox ID="userName" runat="server"></asp:TextBox></td></tr>
        <tr><td>Password:</td><td><asp:TextBox ID="password" runat="server" EnableViewState="True" TextMode="Password"></asp:TextBox></td></tr>
        <tr><td>Email:</td><td><asp:TextBox ID="email" runat="server"></asp:TextBox></td></tr>
        <tr><td>Weight(lbs):</td><td><asp:TextBox ID="weight" runat="server"></asp:TextBox></td></tr>
        <tr><td>Height:</td><td>Feet:<asp:TextBox ID="heightFoot" runat="server"></asp:TextBox>Inches:<asp:TextBox ID="heightInch" runat="server"></asp:TextBox></td></tr>
        <tr><td>Gender:</td><td><asp:RadioButtonList ID="genderList" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList></td></tr>
        <tr><td>Age:</td><td><asp:TextBox ID="age" runat="server"></asp:TextBox></td></tr>
        </table>
        <asp:Button ID="Create" runat="server" Text="Create New User" 
            onclick="Create_Click" />
    </AnonymousTemplate>
        <LoggedInTemplate>
            You are currently logged in as: 
            <asp:LoginName ID="LoginName1" runat="server" /> <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
</asp:LoginView>
</asp:Content>

