<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="User_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Welcome LimitBreaker</h1>
    <h2>User Profile</h2>
    <table>
        <tr>
            <td>Alias:</td>
            <td>
                <asp:Label ID="alias" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>Level</td>
            <td>
                <asp:Label ID="level" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Total Experience</td>
            <td><asp:Label ID="exp" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style1">Weight</td>
            <td class="auto-style1"><asp:Label ID="weight" runat="server" Text=""></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="newWeight" runat="server" ValidationGroup="profileUpdate"></asp:TextBox></td>
            <td class="auto-style1">
                <asp:Button ID="updateWeight" runat="server" Text="Update" ValidationGroup="profileUpdate" OnClick="updateWeight_Click"/></td>
            <td class="auto-style1"><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="newWeight" ForeColor="Red" ValidationExpression="^\d{2,3}$" ValidationGroup="profileUpdate">Invalid weight</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Height</td>
            <td><asp:Label ID="height" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Resting Metabolic Rate</td>
            <td><asp:Label ID="rmr" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Body Mass Index</td>
            <td><asp:Label ID="bmi" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>

</asp:Content>

