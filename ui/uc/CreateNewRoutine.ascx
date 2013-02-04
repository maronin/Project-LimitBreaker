<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateNewRoutine.ascx.cs" Inherits="ui_uc_CreateNewRoutine" %>
<!-- credits to: kubben, url: http://www.codeproject.com/Articles/17241/Capturing-the-Enter-key-to-cause-a-button-click -->
<script type="text/javascript">
    function doClick(buttonName, e) {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        var key;

        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            //Get the button the user wants to have clicked
            var btn = document.getElementById(buttonName);
            if (btn != null) { //If we find the button click it
                btn.click();
                event.keyCode = 0
            }
        }
    }
</script>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    input[disabled=disabled] {
        background-color: #C0C0C0 !important;
    }

    .selectBtn {
        text-align: center;
    }

    h4 {
        margin-bottom: 10px;
    }

    td {
        padding-top: 10px;
    }
</style>
<h4>Create New Routine</h4>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Muscle Groups"></asp:Label>
                    <br />
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
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Exercise List"></asp:Label>
                    <asp:ListBox ID="lbExerciseList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" Width="100%" AutoPostBack="True"></asp:ListBox>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getExercisesByMuscleGroup" TypeName="SystemExerciseManager">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlMuscleGroups" Name="muscleGroup" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td class="selectBtn">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="&gt;&gt;" ValidationGroup="GoalValues" CssClass="selectBtn" />
                    <br />
                    <asp:Button ID="btnRemove" runat="server" Text="&lt;&lt;" OnClick="btnRemove_Click" CssClass="selectBtn" />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Selected Exercises"></asp:Label>
                    <asp:ListBox ID="lbSelected" runat="server" Width="100%" AutoPostBack="True">
                        <asp:ListItem>Selected Items</asp:ListItem>
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Routine Name" Font-Size="Medium"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbRoutineName" runat="server" ValidationGroup="RtnName" Width="100%"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbRoutineName" ErrorMessage="Alphaneumeric characters only" ForeColor="Red" ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="RtnName" Display="Dynamic" Font-Size="Medium"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbRoutineName" Display="Dynamic" ErrorMessage="Name is needed" ForeColor="Red" ValidationGroup="RtnName" Font-Size="Medium"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnConfirm" runat="server" Enabled="False" Text="Confirm" OnClick="btnConfirm_Click" PostBackUrl="~/userRoutines/Default.aspx" ValidationGroup="RtnName" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    </ContentTemplate>
</asp:UpdatePanel>
