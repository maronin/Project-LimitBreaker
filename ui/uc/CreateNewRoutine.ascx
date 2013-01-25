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
            <asp:ListBox ID="lbExerciseList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="lbExerciseList_SelectedIndexChanged"></asp:ListBox>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getExercisesByMuscleGroup" TypeName="SystemExerciseManager">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlMuscleGroups" Name="muscleGroup" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
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
                        <asp:TextBox ID="tbRep" runat="server" Enabled="False" ValidationGroup="GoalValues"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbWeight" runat="server" Enabled="False" ValidationGroup="GoalValues"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbDistance" runat="server" Enabled="False" ValidationGroup="GoalValues"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbTime" runat="server" Enabled="False" ValidationGroup="GoalValues"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="GoalValues" />

        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbRep" ErrorMessage="Strictly numbers only (no spaces)" ForeColor="Red" ValidationExpression="[0-9]+" ValidationGroup="GoalValues"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
            <p>Selected</p>
        </td>
        <td>
            <asp:ListBox ID="lbSelected" runat="server" Width="100%" OnSelectedIndexChanged="lbSelected_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Selected Items</asp:ListItem>
            </asp:ListBox>
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" ValidationGroup="GoalValues" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td>
            <p>Routine Name</p>
        </td>
        <td>
            <asp:TextBox ID="tbRoutineName" runat="server" ValidationGroup="RtnName"></asp:TextBox>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Enabled="False" Text="Confirm" OnClientClick="return Validate()" OnClick="btnConfirm_Click" />
        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbRoutineName" ErrorMessage="Alphaneumeric characters only" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]+" ValidationGroup="RtnName" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbRoutineName" Display="Dynamic" ErrorMessage="Name is needed" ForeColor="Red" ValidationGroup="RtnName"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <!-- credit to: Mudassar Khan 2012, url: http://www.aspsnippets.com/Articles/Validate-Multiple-Validation-Groups-with-one-Button-in-ASPNet.aspx -->
    <script type="text/javascript">
        function Validate() {
            var isValid = false;
            isValid = Page_ClientValidate('GoalValues');
            if (isValid) {
                isValid = Page_ClientValidate('RtnName');
            }
            return isValid;
        }
    </script>

</table>





