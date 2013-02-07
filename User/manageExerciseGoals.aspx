<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="manageExerciseGoals.aspx.cs" Inherits="User_manageExerciseGoals" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagName="viewExercise" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height:30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<hr />
    <div style="width: 50%; margin: 0px auto 0px auto">
        <asp:Button ID="viewGoalsBtn" runat="server" Text="View Exercise Goals" 
            CssClass="button" onclick="viewGoalsBtn_Click" />
        <asp:Button ID="addGoalBtn" runat="server" Text="Add an Exercise Goal" 
            CssClass="button" onclick="addGoalBtn_Click" />
    </div>
<br />

<div>
    <asp:MultiView ID="exerciseGoalMultiView" runat="server">

        <asp:View ID="addGoalView" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            
            <h4>Add A New Goal</h4>
            <uc1:viewExercise ID="viewExercises" runat="server" />
            <hr />

            <asp:Panel ID="addGoalPanel" runat="server">
                <h4>Add your target goals for the selected exercise:</h4>
                <table>
                    <tr>
                        <td class="style1">
                            Goal Time (Minutes):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="goalTimeTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" TargetControlID="goalTimeTxtBox" Width="175" Minimum="0" Step="1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="goalTimeTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="addGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*Entered values must be a whole number" 
                                ControlToValidate="goalTimeTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="addGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="style1">
                            Goal Weight (lbs):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="goalWeightTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" TargetControlID="goalWeightTxtBox" Width="175" Minimum="0" Step="5">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="goalWeightTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="addGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ErrorMessage="*Entered values must be a whole number" 
                                ControlToValidate="goalWeightTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="addGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="style1">
                            Goal Distance (km):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="goalDistanceTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" TargetControlID="goalDistanceTxtBox" Width="175" Minimum="0" Step="0.1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="goalDistanceTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="addGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                                ControlToValidate="goalDistanceTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" ValidationGroup="addGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="style1">
                            Goal Reps:
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="goalRepsTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender4" runat="server" TargetControlID="goalRepsTxtBox" Width="175" Minimum="0" Step="1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="goalRepsTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="addGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ErrorMessage="*Entered values must be a whole number" 
                                ControlToValidate="goalRepsTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="addGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="saveNewGoalBtn" runat="server" Text="Save" 
                    onclick="saveNewGoalBtn_Click" ValidationGroup="addGoal" />
                <asp:Label ID="addGoalResultLbl" runat="server" Text=""></asp:Label>

            </asp:Panel>

        </ContentTemplate>
        </asp:UpdatePanel>
        </asp:View>

        <asp:View ID="noGoalsView" runat="server">

        <h4>You Currently Have No Goals</h4>
        <p>If you want to add a goal for an exercise you have been working on, click on the "Add an Exercise Goal" button above, and you will be directed to a page where you can add goals for yourself.</p>

        </asp:View>

        <asp:View ID="manageGoalsView" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <h4>Your Current Exercise Goals</h4>
        <div style="float: left; padding: 10px;">
            Order Goals By:
            <asp:RadioButtonList ID="orderByRbl" runat="server" AutoPostBack="True" Width="230" 
                RepeatDirection="Horizontal" TextAlign="Left" 
                onselectedindexchanged="orderByRbl_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Name</asp:ListItem>
                <asp:ListItem Value="1">ID</asp:ListItem>
            </asp:RadioButtonList>
            <asp:ListBox ID="userGoalsListBox" runat="server" AutoPostBack="True" 
                Height="400px" Width="230px" 
                onselectedindexchanged="userGoalsListBox_SelectedIndexChanged"></asp:ListBox>
        </div> 
        
        <div style="float: left; padding: 10px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="exerciseNameLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="timelbl" runat="server" Text="Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="distanceLbl" runat="server" Text="Distance"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="weightlbl" runat="server" Text="Weight"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="repLbl" runat="server" Text="Reps"></asp:Label>
                </td>
            </tr>

            <asp:MultiView ID="singleGoalAttributesMultiView" runat="server">
                <asp:View ID="viewGoalView" runat="server">   
                    <tr>
                        <td>
                            <asp:Label ID="goalTimeLbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalDistancelbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalWeightLbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalRepsLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </asp:View>

                <asp:View ID="updaetGoalView" runat="server">
                    
                </asp:View>
            </asp:MultiView>
        </table>

        </div> 
        </ContentTemplate>
        </asp:UpdatePanel>
        </asp:View>

    </asp:MultiView>
    
</div>



</asp:Content>