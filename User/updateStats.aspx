<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="updateStats.aspx.cs" Inherits="User_updateStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Update Stats</h1>
       <table>
        <tr>
            <td>Weight</td>
            <td><asp:Label ID="weight" runat="server" Text=""></asp:Label></td>
            <td>
                <asp:TextBox ID="weightInput" runat="server" ValidationGroup="updateStats"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Numbers only" ValidationExpression="^\d{2,3}$" ValidationGroup="updateStats"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Resting Metabolic Rate</td>
            <td><asp:Label ID="rmr" runat="server" Text=""></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Body Mass Index</td>
            <td><asp:Label ID="bmi" runat="server" Text=""></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>VO2 Max</td>
            <td><asp:Label ID="vmax" runat="server" Text=""></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

