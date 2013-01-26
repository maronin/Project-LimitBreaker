<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="manageExerciseExperience.aspx.cs" Inherits="systemExercise_manageExerciseExperience" %>
<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagName="viewExercise" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
<asp:Panel ID="viewExercisePanel" runat="server">
<uc1:viewExercise ID="viewExerciseExp" runat="server" />
</asp:Panel>


<asp:MultiView ID="manageExperienceMultiView" runat="server">
    <asp:View ID="emptyView" runat="server"></asp:View>

    <asp:View ID="modifyExperienceView" runat="server">
        <h4>Modify Exercise Experience</h4>

        <div>
        Base Experience Value: 
        <asp:TextBox ID="baseTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="baseTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="*Required" ControlToValidate="baseTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
        <br />

        Time Modifier:
        <asp:TextBox ID="timeTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="timeTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="*Required" ControlToValidate="timeTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
        <br />

        Weight Modifier:
        <asp:TextBox ID="weightTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="weightTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="*Required" ControlToValidate="weightTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
        <br />

        Rep Modifier:
        <asp:TextBox ID="repTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="repTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="*Required" ControlToValidate="repTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
        <br />

        Distance Modifier:
        <asp:TextBox ID="distanceTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="distanceTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="modifyExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ErrorMessage="*Required" ControlToValidate="distanceTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="modifyExperience"></asp:RequiredFieldValidator>
        <br />
        <br />
        
        <asp:Button ID="saveExpBtn" runat="server" Text="Save" onclick="saveExpBtn_Click" ValidationGroup="modifyExperience" />
        <asp:Label ID="saveResultLbl" runat="server" Text=""></asp:Label>

        </div>
    </asp:View>

    <asp:View ID="setNewExperienceView" runat="server">
        <h4>Set Exercise Experience</h4>
        <asp:Label ID="noExpLbl" runat="server" Text="This exercise does not have any experience values associated with it yet.  Fill in the fields below to add an experience reward fomrula to it."></asp:Label>
        <br />
        <br />

        <div>
        Base Experience Value: 
        <asp:TextBox ID="addBaseTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="addBaseTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="addExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="*Required" ControlToValidate="addBaseTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
        <br />

        Time Modifier:
        <asp:TextBox ID="addTimeTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="addTimeTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="addExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ErrorMessage="*Required" ControlToValidate="addTimeTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
        <br />

        Weight Modifier:
        <asp:TextBox ID="addWeightTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="addWeightTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="addExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ErrorMessage="*Required" ControlToValidate="addWeightTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
        <br />

        Rep Modifier:
        <asp:TextBox ID="addRepTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="addRepTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="addExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ErrorMessage="*Required" ControlToValidate="addRepTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
        <br />

        Distance Modifier:
        <asp:TextBox ID="addDistanceTxtBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
                ErrorMessage="*Entered values must be a double or int (up to 3 decimal places)" 
                ControlToValidate="addDistanceTxtBox" Display="Dynamic" ForeColor="Red" 
                ValidationExpression="[0-9]+([\.][0-9]{1,3})?$" 
                ValidationGroup="addExperience"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ErrorMessage="*Required" ControlToValidate="addDistanceTxtBox" Display="Dynamic" 
                ForeColor="Red" ValidationGroup="addExperience"></asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Button ID="addExpBtn" runat="server" Text="Save" onclick="addExpBtn_Click" ValidationGroup="addExperience"  />
        <asp:Label ID="addResultLbl" runat="server" Text=""></asp:Label>
        </div>
    </asp:View>
    
</asp:MultiView>


</div>



</asp:Content>