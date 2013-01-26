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
        <br />

        Weight Modifier:
        <asp:TextBox ID="weightTxtBox" runat="server"></asp:TextBox>
        <br />

        Rep Modifier:
        <asp:TextBox ID="repTxtBox" runat="server"></asp:TextBox>
        <br />

        Distance Modifier:
        <asp:TextBox ID="distanceTxtBox" runat="server"></asp:TextBox>
        <br />
        <br />
        
        <asp:Button ID="saveExpBtn" runat="server" Text="Save"   
                OnClientClick="return confirm('Doing this will erase all old experience values and replace them with the new ones. Are you sure?');"
                onclick="saveExpBtn_Click" ValidationGroup="modifyExperience" />
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
        <br />

        Time Modifier:
        <asp:TextBox ID="addTimeTxtBox" runat="server"></asp:TextBox>
        <br />

        Weight Modifier:
        <asp:TextBox ID="addWeightTxtBox" runat="server"></asp:TextBox>
        <br />

        Rep Modifier:
        <asp:TextBox ID="addRepTxtBox" runat="server"></asp:TextBox>
        <br />

        Distance Modifier:
        <asp:TextBox ID="addDistanceTxtBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="addExpBtn" runat="server" Text="Save"  
            
                OnClientClick="return confirm('Doing this will add all the entered values to the exercises rewarded experience formuala. These values can be chanegd at a later date.');" 
                onclick="addExpBtn_Click"  />
        </div>
    </asp:View>
    
</asp:MultiView>


</div>



</asp:Content>