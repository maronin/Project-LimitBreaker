<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="User_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            <td>Weight</td>
            <td><asp:Label ID="weight" runat="server" Text=""></asp:Label></td>
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
        <tr>
            <td>VO2 Max</td>
            <td><asp:Label ID="vmax" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>

</asp:Content>

