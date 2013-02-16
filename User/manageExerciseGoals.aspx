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
                                ErrorMessage="*Entered values must be a non 0 whole number" 
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
                                ErrorMessage="*Entered values must be a non 0 whole number" 
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
                                ErrorMessage="*Entered values must be a non 0 double or int (up to 3 decimal places)" 
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
                                ErrorMessage="*Entered values must be a non 0 whole number" 
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
        
        <h4>Your Current Exercise Goals</h4>
        <div style="float: left; padding: 10px;">
            Order Goals By:
            <asp:RadioButtonList ID="orderByRbl" runat="server" AutoPostBack="True" Width="230" 
                RepeatDirection="Horizontal" TextAlign="Left" 
                onselectedindexchanged="orderByRbl_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Name</asp:ListItem>
                <asp:ListItem Value="1">ID</asp:ListItem>
            </asp:RadioButtonList>
            
            <asp:RadioButtonList ID="achievedRbl" runat="server" 
                RepeatDirection="Horizontal" TextAlign="Left" AutoPostBack="True" Width="230"
                onselectedindexchanged="achievedRbl_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Unachieved</asp:ListItem>
                <asp:ListItem Value="1">Achieved</asp:ListItem>
            </asp:RadioButtonList>
            <asp:ListBox ID="userGoalsListBox" runat="server" AutoPostBack="True" 
                Height="400px" Width="230px" 
                onselectedindexchanged="userGoalsListBox_SelectedIndexChanged"></asp:ListBox>
        </div>

        
        <div style="padding: 10px; width: 60%; margin: 0px auto 0px auto">
        <asp:Panel ID="noAchievedPanel" runat="server">
        <table>
            <tr>
                <td class="style1">
                    Exercise Name:
                </td>
                <td class="style1">
                    <asp:Label ID="exerciseNameLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <asp:MultiView ID="singleGoalAttributesMultiView" runat="server">
                <asp:View ID="viewGoalView" runat="server">
                    <asp:Panel ID="goalTimePanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Time (Minutes):
                        </td>
                        <td class="style1">
                            <asp:Label ID="goalTimeLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="goalDistancePanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Distance (km):
                        </td>
                        <td class="style1">
                            <asp:Label ID="goalDistancelbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="goalWeightPanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Weight (lbs):
                        </td>
                        <td class="style1">
                            <asp:Label ID="goalWeightLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="goalRepsPanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Reps:
                        </td>
                        <td class="style1">
                            <asp:Label ID="goalRepsLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    </asp:Panel>
           
                </asp:View>

                <asp:View ID="updateGoalView" runat="server">
                    <asp:Panel ID="modGoalTimePanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Time (Minutes):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="modGoalTimeTxtBox" runat="server"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender5" runat="server" TargetControlID="modGoalTimeTxtBox" Width="175" Minimum="0" Step="1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="modGoalTimeTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="modifyGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                ErrorMessage="*Entered values must be a non 0 whole number" 
                                ControlToValidate="modGoalTimeTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="modifyGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="modGoalDistancePanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Distance (km):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="modGoalDistanceTxtBox" runat="server"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender6" runat="server" TargetControlID="modGoalDistanceTxtBox" Width="175" Minimum="0" Step="0.1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="modGoalDistanceTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="modifyGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                ErrorMessage="*Entered values must be a non 0 double or int (up to 3 decimal places)" 
                                ControlToValidate="modGoalDistanceTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" ValidationGroup="modifyGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="modGoalWeightPanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Weight (lbs):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="modGoalWeightTxtBox" runat="server"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender7" runat="server" TargetControlID="modGoalWeightTxtBox" Width="175" Minimum="0" Step="5">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="modGoalWeightTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="modifyGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                ErrorMessage="*Entered values must be a non 0 whole number" 
                                ControlToValidate="modGoalWeightTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="modifyGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    </asp:Panel>
                    <asp:Panel ID="modGoalRepsPanel" runat="server">
                    <tr>
                        <td class="style1">
                            Goal Reps:
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="modGoalRepsTxtBox" runat="server"></asp:TextBox>
                            <asp:NumericUpDownExtender ID="NumericUpDownExtender8" runat="server" TargetControlID="modGoalRepsTxtBox" Width="175" Minimum="0" Step="1">
                            </asp:NumericUpDownExtender>
                        </td>
                        <td class="style1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ErrorMessage="*Required" ControlToValidate="modGoalRepsTxtBox" Display="Dynamic" 
                                ForeColor="Red" ValidationGroup="modifyGoal"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                                ErrorMessage="*Entered values must be a non 0 whole number" 
                                ControlToValidate="modGoalRepsTxtBox" Display="Dynamic" ForeColor="Red" 
                                ValidationExpression="[0-9]+" ValidationGroup="modifyGoal"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    </asp:Panel>
                    
                </asp:View>
            </asp:MultiView>

            <tr>
                <td class="style1">
                    <asp:Button ID="updateGoalbtn" runat="server" Text="Update" 
                        onclick="updateGoalbtn_Click" />
                </td>
                <td class="style1">
                    <asp:Button ID="deleteGoalBtn" runat="server" Text="Delete" OnClientClick="return confirm('Doing this will irreversibly remove your goal from the system. Are you sure?');"
                        onclick="deleteGoalBtn_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="saveModifyGoalBtn" runat="server" Text="Save" Visible="false" 
                        onclick="saveModifyGoalBtn_Click" ValidationGroup="modifyGoal"/>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Label ID="deleteGoalResultLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="modifyGoalResultlbl" runat="server" Text=""></asp:Label>
        </div> 
        

        </asp:View>

    </asp:MultiView>
    
</div>



</asp:Content>