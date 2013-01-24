<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewExercise.ascx.cs" Inherits="ui_uc_ucViewExercise" %>

        <asp:ScriptManager ID="ScriptManager1" runat="Server">
        </asp:ScriptManager>
        <label for="_Default">
            Search for an exercise via name:
        </label>
        <asp:TextBox runat="server" ID="exerciseSearchBox" ClientIDMode="Static" AutoPostBack="False"
            ValidationGroup="Search" />
        <juice:Autocomplete ID="exerciseAutoComplete" runat="server" TargetControlID="exerciseSearchBox" />
        <asp:Button ID="exerciseSearchButton" runat="server" Text="Search" OnClick="exerciseSearchButton_Click"
            ValidationGroup="Search" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="exerciseSearchBox"
            ErrorMessage="No symbols" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$"
            Display="Dynamic" ValidationGroup="Search"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="exerciseSearchBox"
            Display="Dynamic" ErrorMessage="Need a name" ForeColor="Red" ValidationGroup="Search"></asp:RequiredFieldValidator>
        <br />
        Search via muscle groups:
        <asp:RadioButtonList ID="MuscleGroupRBL" runat="server" OnSelectedIndexChanged="MuscleGroupRBL_SelectedIndexChanged"
            AutoPostBack="True">
            <asp:ListItem>Chest</asp:ListItem>
            <asp:ListItem>Back</asp:ListItem>
            <asp:ListItem>Shoulders</asp:ListItem>
            <asp:ListItem>Arms</asp:ListItem>
            <asp:ListItem>Legs</asp:ListItem>
            <asp:ListItem>Cardio</asp:ListItem>
        </asp:RadioButtonList>
        <asp:DropDownList ID="ExerciseDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ExerciseDDL_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="exceriseNotFound" runat="server" ForeColor="Red" Text="No exercise found"
            Visible="False"></asp:Label>
        <br />
        <table>
            <tr>
                <td>
                    Exercise Name
                </td>
                <td>
                    Exercise Equipment
                </td>
                <td class="style2">
                    Exercise Video
                </td>
                <td>
                    Exercise Attributes
                </td>
                <td>
                    Enabled
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="exerciseName" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="exerciseEquipment" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="exerciseVideo" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="exerciseAttributes" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="exerciseEnabled" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
 