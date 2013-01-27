<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="createUser.aspx.cs" Inherits="User_createUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" 
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" 
            Width="437px">
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        ForeColor="#284775" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        ForeColor="#284775" />
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" >
                    <ContentTemplate>
                        <table style="font-family:Verdana;font-size:100%;width:437px;">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" 
                                    style="color:White;background-color:#6B696B;font-weight:bold;">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Confirm Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmPassword" 
                                        ErrorMessage="Confirm Password is required." 
                                        ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Security Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                        ControlToValidate="Question" ErrorMessage="Security question is required." 
                                        ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                        ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                        Display="Dynamic" 
                                        ErrorMessage="The Password and Confirmation Password must match." 
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                        ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                        ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" 
        HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        ForeColor="#284775" />
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" 
        ForeColor="White" />
            <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" 
        VerticalAlign="Top" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
    </AnonymousTemplate>
        <LoggedInTemplate>
            You are currently logged in as: 
            <asp:LoginName ID="LoginName1" runat="server" /> <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
</asp:LoginView>
</asp:Content>

