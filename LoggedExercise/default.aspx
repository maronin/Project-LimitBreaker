<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="LoggedExercise_default" %>

<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagPrefix="uc1" TagName="ucViewExercise" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ucViewExercise runat="server" ID="ucViewExercise" />
    <hr />
    <table>
        <tr>
            <td>Weight: 
            </td>
            <td>
                <asp:TextBox ID="weight" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="weightRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="weight" ValidationGroup="LogExercise" ForeColor="Red">Required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="weightREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="weight" ValidationGroup="LogExercise" ValidationExpression="[0-9]{1,3}" ForeColor="Red">Invalid weight</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Distance:
                
            </td>
            <td>
                <asp:TextBox ID="distance" runat="server"></asp:TextBox>km</td>
            <td>
                <asp:RequiredFieldValidator ID="distanceRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="distance" ValidationGroup="LogExercise" ForeColor="Red">Required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="distanceREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="distance" ValidationGroup="LogExercise" ValidationExpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$" ForeColor="Red">Invalid distance</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Time:
                
            </td>
            <td>
                <asp:TextBox ID="timeMinutes" runat="server"></asp:TextBox>m</td>
            <td>
                <asp:TextBox ID="timeSeconds" runat="server"></asp:TextBox>s</td>
            <td>
                <asp:RequiredFieldValidator ID="minutesRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="timeMinutes" ValidationGroup="LogExercise" ForeColor="Red">Required</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="secondsRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="timeSeconds" ValidationGroup="LogExercise" ForeColor="Red">Required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="minutesREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="timeMinutes" ValidationGroup="LogExercise" ValidationExpression="[0-9]{1,4}" ForeColor="Red">Invalid time</asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="secondsREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="timeSeconds" ValidationGroup="LogExercise" ValidationExpression="[0-9]{0,2}" ForeColor="Red">Invalid time</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Rep:
            </td>
            <td>
                <asp:TextBox ID="rep" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="repRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="rep" ValidationGroup="LogExercise" ForeColor="Red">Required</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="repREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="rep" ValidationGroup="LogExercise" ValidationExpression="^[0-9]{1,3}" ForeColor="Red">Invalid reps</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="recordSet" runat="server" Text="Add Set" OnClick="recordSet_Click" ValidationGroup="LogExercise" /></td> 
        </tr>
                
    </table>
    <asp:Label ID="expRewardLbl" runat="server" Text=""></asp:Label>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ListBox ID="loggedExercises" runat="server" DataTextField="timeLogged" DataValueField="id" Height="150px" Width="160px" OnSelectedIndexChanged="loggedExercises_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="setsLbl" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

