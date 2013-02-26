<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="contactUs.aspx.cs" Inherits="contactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>Send us an email</h2>

<table>
    <tr>
        <td>
            Your email address:<br />
            <asp:RegularExpressionValidator ID="emailRegExpValid" runat="server" 
                ControlToValidate="eAddressTextbox" ErrorMessage="Inproper email" 
                ForeColor="Red" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator 
                ID="eAddressValid" runat="server" ControlToValidate="eAddressTextbox" 
                ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="eAddressTextbox" runat="server" Width="100%"  
                style="width:100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;Your message:<br />
            <asp:RequiredFieldValidator ID="eMessageValid" runat="server" 
                ControlToValidate="eMessageTextBox" ErrorMessage="Required" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:TextBox ID="eMessageTextBox" runat="server" rows="1" 
                cols="20" Height="100px" Width="100%" MaxLength="255" 
                TextMode="MultiLine"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <asp:Button ID="sendEmailButton" runat="server" onclick="Button1_Click" 
                Text="Send Email" />
            <br />
            <asp:Label ID="confirmLabel" runat="server" ForeColor="#66FF66"></asp:Label>
        </td>
    </tr>
</table>

</asp:Content>

