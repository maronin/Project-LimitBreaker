<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="contactUs.aspx.cs" Inherits="contactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>Contact Us</h2>
<p>Here at LimitBreaker, we like to mantain a high quality system as well as good user relations. <br />If you have questions, comments, or concerns, send us an email and let us know!</p>
<table>
    <tr>
        <td>
            Your email address:
        </td>
        <td>
            <asp:TextBox ID="eAddressTextbox" runat="server" Width="250px" ValidationGroup="contactUs"></asp:TextBox>
        </td>
        <td>
            <asp:RegularExpressionValidator ID="emailRegExpValid" runat="server" 
                ControlToValidate="eAddressTextbox" ErrorMessage="*Improper Email Format" 
                ForeColor="Red" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="contactUs" Display="Dynamic"></asp:RegularExpressionValidator>   
            <asp:RequiredFieldValidator 
                ID="eAddressValid" runat="server" ControlToValidate="eAddressTextbox" 
                ErrorMessage="*Required" ForeColor="Red" ValidationGroup="contactUs" 
                Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Subject Line:
        </td>
        <td>
            <asp:TextBox ID="subjectTxtBox" runat="server" Width="250px" ValidationGroup="contactUs"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="subjectValidator" runat="server" 
                ControlToValidate="subjectTxtBox" ErrorMessage="*Required" 
                ForeColor="Red" Display="Dynamic" ValidationGroup="contactUs"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Your message:
        </td>
        <td>
            <asp:TextBox style="resize:none;" ID="eMessageTextBox" runat="server" rows="1" 
                cols="20" Height="125px" Width="250px" MaxLength="255" 
                TextMode="MultiLine" ValidationGroup="contactUs"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="eMessageValid" runat="server" 
                ControlToValidate="eMessageTextBox" ErrorMessage="*Required" 
                ForeColor="Red" Display="Dynamic" ValidationGroup="contactUs"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <asp:Button ID="sendEmailButton" runat="server" onclick="Button1_Click" 
                Text="Send Email" ValidationGroup="contactUs" CssClass="button"/>
        </td>
        <td>
            <asp:Label ID="confirmLabel" runat="server"></asp:Label>
        </td>
    </tr>
</table>

</asp:Content>

