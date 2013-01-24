<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateNewRoutine.ascx.cs" Inherits="ui_uc_CreateNewRoutine" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    input[disabled=disabled] {
        background-color: #C0C0C0 !important;
    }
</style>
<h4>Create New Routine</h4>
<table class="auto-style1">
    <tr>
        <td>
            <p>Muscle Groups</p>
        </td>
        <td>
            <asp:DropDownList ID="ddlMuscleGroups" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True">Select a muscle group</asp:ListItem>
                <asp:ListItem>Chest</asp:ListItem>
                <asp:ListItem>Back</asp:ListItem>
                <asp:ListItem>Shoulder</asp:ListItem>
                <asp:ListItem>Arms</asp:ListItem>
                <asp:ListItem>Legs</asp:ListItem>
                <asp:ListItem>Cardio</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <p>Exercise List</p>
        </td>
        <td>
            <asp:ListBox ID="lbExerciseList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" SelectionMode="Multiple" Width="100%" AutoPostBack="True"></asp:ListBox>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getExercisesByMuscleGroup" TypeName="SystemExerciseManager">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlMuscleGroups" Name="muscleGroup" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <p>Selected</p>
        </td>
        <td>
            <asp:ListBox ID="lbSelected" runat="server" Width="100%" OnSelectedIndexChanged="lbSelected_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>
                        <p>Rep</p>
                    </td>
                    <td>
                        <p>Weight</p>
                    </td>
                    <td>
                        <p>Distance</p>
                    </td>
                    <td>
                        <p>Time</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbRep" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbWeight" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDistance" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbTime" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <p>Routine Name</p>
        </td>
        <td>
            <asp:TextBox ID="tbRoutineName" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Enabled="False" Text="Confirm" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>





