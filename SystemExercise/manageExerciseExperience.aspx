<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="manageExerciseExperience.aspx.cs" Inherits="systemExercise_manageExerciseExperience" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagName="viewExercise" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style9
        {
            width: 175px;
            height:30px;
        }
        .style10
        {
            width: 700px;
            height:30px;
        }
        .style11
        {
            width: 250px;
            height:30px;
        }
        .style12
        {
            width: 255px;
            height:30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <hr />
    <div style="width: 50%; margin: 0px auto 0px auto">
        <asp:Button ID="mngExerciseExpBtn" runat="server" Text="Manage Exercise Experience"
            CssClass="button" OnClick="mngExerciseExpBtn_Click" />
        <asp:Button ID="mngUserExpBtn" runat="server" Text="Manage User Experience" CssClass="button"
            OnClick="mngUserExpBtn_Click" />
    </div>
    <br />
    <div>
        
        <asp:MultiView ID="functionalityMultiView" runat="server">
        <asp:View ID="exerciseExpView" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <uc1:viewExercise ID="viewExerciseExp" runat="server" />
                <hr />
                <asp:MultiView ID="manageExperienceMultiView" runat="server">
                    <asp:View ID="emptyView" runat="server">
                    </asp:View>
                    <asp:View ID="modifyExperienceView" runat="server">
                        <h4>
                            Modify Exercise Experience</h4>
                        <div>
                            <table>
                                <tr>
                                    <td class="style11">
                                        Base Experience Value:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="baseTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" TargetControlID="baseTxtBox" Width="175" Minimum="0" Step="100">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="baseTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="baseTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Time Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="timeTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" TargetControlID="timeTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="timeTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="timeTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Weight Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="weightTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" TargetControlID="weightTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="weightTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="weightTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Rep Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="repTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender4" runat="server" TargetControlID="repTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="repTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="repTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Distance Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="distanceTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender5" runat="server" TargetControlID="distanceTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="distanceTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="distanceTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="saveExpBtn" runat="server" Text="Save" OnClick="saveExpBtn_Click"
                                ValidationGroup="modifyExperience" />
                            <asp:Label ID="saveResultLbl" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:View>
                    <asp:View ID="setNewExperienceView" runat="server">
                        <h4>
                            Set Exercise Experience</h4>
                        <asp:Label ID="noExpLbl" runat="server" Text="This exercise does not have any experience values associated with it yet.  Fill in the fields below to add an experience reward fomrula to it."></asp:Label>
                        <br />
                        <br />
                        <div>
                            <table>
                                <tr>
                                    <td class="style11">
                                        Base Experience Value:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="addBaseTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender6" runat="server" TargetControlID="addBaseTxtBox" Width="175" Minimum="0" Step="100">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="addBaseTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="addExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="addBaseTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Time Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="addTimeTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender7" runat="server" TargetControlID="addTimeTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="addTimeTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="addExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="addTimeTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Weight Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="addWeightTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender8" runat="server" TargetControlID="addWeightTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="addWeightTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="addExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="addWeightTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Rep Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="addRepTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender9" runat="server" TargetControlID="addRepTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="addRepTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="addExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="addRepTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        Distance Modifier:
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="addDistanceTxtBox" runat="server" style="text-align:center"></asp:TextBox>
                                        <asp:NumericUpDownExtender ID="NumericUpDownExtender10" runat="server" TargetControlID="addDistanceTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                                    </td>
                                    <td class="style10">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                            ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)"
                                            ControlToValidate="addDistanceTxtBox" Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"
                                            ValidationGroup="addExperience"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required"
                                            ControlToValidate="addDistanceTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="addExpBtn" runat="server" Text="Save" OnClick="addExpBtn_Click" ValidationGroup="addExperience" />
                            <asp:Label ID="addResultLbl" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:View>
                </asp:MultiView>
            
            </ContentTemplate>
        </asp:UpdatePanel>
        </asp:View>
        <asp:View ID="userExpView" runat="server">
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
            
                <div>
                    <h4>
                        Modify Inactive User Experience Point Atrophy</h4>
                    <table>
                        <tr>
                            <td class="style12">
                                Days Allowed Inactive:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="inactiveTimeTxtBox" runat="server"></asp:TextBox>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender11" runat="server" TargetControlID="inactiveTimeTxtBox" Width="175" Minimum="0" >
                                        </asp:NumericUpDownExtender>
                            </td>
                            <td class="style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required"
                                    ControlToValidate="inactiveTimeTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="expAtrophy"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                    ErrorMessage="*Must be a whole number less than 100" ControlToValidate="inactiveTimeTxtBox"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="expAtrophy" ValidationExpression="[0-9]{1,2}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                Experience Loss Per Day:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="expLossTxtBox" runat="server"></asp:TextBox>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender12" runat="server" TargetControlID="expLossTxtBox" Width="175" Minimum="0" Step="500">
                                        </asp:NumericUpDownExtender>
                            </td>
                            <td class="style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required"
                                    ControlToValidate="expLossTxtBox" Display="Dynamic" ForeColor="Red" ValidationGroup="expAtrophy"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                    ErrorMessage="*Must be a whole number" ControlToValidate="expLossTxtBox" Display="Dynamic"
                                    ForeColor="Red" ValidationGroup="expAtrophy" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="saveAtrophyBtn" runat="server" Text="Save" OnClick="saveAtrophyBtn_Click"
                        ValidationGroup="expAtrophy" />
                    <asp:Label ID="saveAtrophyResultLbl" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <hr />
                <div>
                    <h4>
                        Modify Required Experience For Leveling Up</h4>

                    <table>
                        <tr>
                            <td class="style12">
                                Max Level:
                            </td>
                            <td class ="style9">
                                <asp:TextBox ID="maxLvlTxtBox" runat="server"></asp:TextBox>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender13" runat="server" TargetControlID="maxLvlTxtBox" Width="175" Minimum="0" Step="50">
                                        </asp:NumericUpDownExtender>
                            </td>
                            <td class="style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Required"
                                    ControlToValidate="maxLvlTxtBox" Display="Dynamic" ForeColor="Red" 
                                    ValidationGroup="lvlFormula"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                    ErrorMessage="*Must be a whole number" ControlToValidate="maxLvlTxtBox"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="lvlFormula" 
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                Base Required Exp:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="baseReqTxtBox" runat="server"></asp:TextBox>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender14" runat="server" TargetControlID="baseReqTxtBox" Width="175" Minimum="0" Step="500">
                                        </asp:NumericUpDownExtender>
                            </td>
                            <td class="style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Required"
                                    ControlToValidate="baseReqTxtBox" Display="Dynamic" ForeColor="Red" 
                                    ValidationGroup="lvlFormula"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                    ErrorMessage="*Must be a whole number" ControlToValidate="baseReqTxtBox"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="lvlFormula" 
                                    ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                Required Exp Modifier:
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="expModTxtBox" runat="server"></asp:TextBox>
                                <asp:NumericUpDownExtender ID="NumericUpDownExtender15" runat="server" TargetControlID="expModTxtBox" Width="175" Minimum="0" Step="0.1">
                                        </asp:NumericUpDownExtender>
                            </td>
                            <td class="style10">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required"
                                    ControlToValidate="expModTxtBox" Display="Dynamic" ForeColor="Red" 
                                    ValidationGroup="lvlFormula"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                    ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" ControlToValidate="expModTxtBox"
                                    Display="Dynamic" ForeColor="Red" ValidationGroup="lvlFormula" 
                                    ValidationExpression="[0-9]+([\.][0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="saveLvlFormulaBtn" runat="server" Text="Save" 
                        onclick="saveLvlFormulaBtn_Click" ValidationGroup="lvlFormula" />
                    <asp:Label ID="saveLvlFormulaResultLbl" runat="server" Text=""></asp:Label>
                </div>
            
            </ContentTemplate>
            </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
        
    </div>
</asp:Content>
