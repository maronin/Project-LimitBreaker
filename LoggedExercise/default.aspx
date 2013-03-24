<%@ Page Title="Use Case 5.4" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="LoggedExercise_default" %>

<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagPrefix="uc1" TagName="ucViewExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                    <div class="useCase"><h3>Use Case 5.4</h3></div>
            <div class="exerciseForm">
                <h2 style="text-align: center;">
                    Logging Exercises</h2>
                <uc1:ucViewExercise runat="server" ID="ucViewExercise" />
                <table>
                    <tr>
                        <td>
                            Weight:
                        </td>
                        <td>
                            <asp:TextBox ID="weight" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator ID="weightRF" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="weight" ValidationGroup="LogExercise" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            
                            <asp:RegularExpressionValidator ID="weightREV" runat="server" ErrorMessage="RegularExpressionValidator"
                                ControlToValidate="weight" ValidationGroup="LogExercise" ValidationExpression="[0-9]{1,3}"
                                ForeColor="Red">Invalid weight</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Distance:
                        </td>
                        <td>
                            <asp:TextBox ID="distance" runat="server" Width="120px"></asp:TextBox>km<asp:RequiredFieldValidator
                                ID="distanceRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="distance"
                                ValidationGroup="LogExercise" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="distanceREV" runat="server" ErrorMessage="RegularExpressionValidator"
                                ControlToValidate="distance" ValidationGroup="LogExercise" ValidationExpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$"
                                ForeColor="Red">Invalid distance</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Time:
                        </td>
                        <td>
                            <asp:TextBox ID="timeMinutes" runat="server" Width="120px"></asp:TextBox>m<asp:RequiredFieldValidator
                                ID="minutesRF" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="timeMinutes"
                                ValidationGroup="LogExercise" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="timeSeconds" runat="server" Width="120px"></asp:TextBox>s
                            <asp:RequiredFieldValidator ID="secondsRF" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="timeSeconds" ValidationGroup="LogExercise" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="minutesREV" runat="server" ErrorMessage="RegularExpressionValidator"
                                ControlToValidate="timeMinutes" ValidationGroup="LogExercise" ValidationExpression="[0-9]{1,4}"
                                ForeColor="Red">Invalid time</asp:RegularExpressionValidator><asp:RegularExpressionValidator
                                    ID="secondsREV" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="timeSeconds"
                                    ValidationGroup="LogExercise" ValidationExpression="[0-9]{0,2}" ForeColor="Red" Display="None">Invalid time</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Rep:
                        </td>
                        <td>
                            <asp:TextBox ID="rep" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator ID="repRF" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="rep" ValidationGroup="LogExercise" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <asp:RegularExpressionValidator ID="repREV" runat="server" ErrorMessage="RegularExpressionValidator"
                                ControlToValidate="rep" ValidationGroup="LogExercise" ValidationExpression="^[0-9]{1,3}"
                                ForeColor="Red">Invalid reps</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
                <asp:Button ID="recordSet" runat="server" Text="Add Set" OnClick="recordSet_Click"
                    ValidationGroup="LogExercise" CssClass="button" />
                <br />
                <asp:Label ID="successLbl" runat="server" Text="Exercise logged!" ForeColor="Green"
                    Enabled="False" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="expRewardLbl" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="goalAchievedLbl" runat="server" Text=""></asp:Label>
                <asp:HyperLink ID="goalsLink" runat="server" NavigateUrl="~/LoggedExercise/manageExerciseGoals.aspx"
                    ForeColor="#666666" Visible="False">here</asp:HyperLink>
                <hr />
                <asp:ListBox ID="loggedExercises" runat="server" DataTextField="timeLogged" DataValueField="id"
                    Height="150px" Width="160px" OnSelectedIndexChanged="loggedExercises_SelectedIndexChanged"
                    AutoPostBack="True"></asp:ListBox>
                <br />
                <br />
                <asp:Label ID="setsLbl" runat="server" Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
