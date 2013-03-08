<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewExercise.ascx.cs"
    Inherits="ui_uc_ucViewExercise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table><tr>
        <td>
        <label for="_Default">
            Search via exercise name:
        </label>
        </td>
        <td>
        <asp:TextBox runat="server" ID="exerciseSearchBox" ClientIDMode="Static" AutoPostBack="False"
            ValidationGroup="Search" style="width: 160px; padding: 0px 0px 0px 4px;"/>
        <juice:Autocomplete ID="exerciseAutoComplete" runat="server" TargetControlID="exerciseSearchBox" />
        <asp:Button ID="exerciseSearchButton" runat="server" Text="Search" OnClick="exerciseSearchButton_Click"
            ValidationGroup="Search" CssClass="button" style="width: 91px;padding: 2px 0px 2px 0px;height: 24px;"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="exerciseSearchBox"
            ErrorMessage="No symbols" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9 ]+$"
            Display="Dynamic" ValidationGroup="Search"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="exerciseSearchBox"
            Display="Dynamic" ErrorMessage="Need a name" ForeColor="Red" ValidationGroup="Search"></asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
        <td>
        Search via muscle groups: 
                </td>
                <td>
        <asp:DropDownList ID="ddlMuscleGroups" runat="server" OnSelectedIndexChanged="MuscleGroupDDL_SelectedIndexChanged"
            AutoPostBack="True" style="margin-left: 0;width: 166px;">
            <asp:ListItem Value="ALL">All Groups</asp:ListItem>
            <asp:ListItem>Chest</asp:ListItem>
            <asp:ListItem>Back</asp:ListItem>
            <asp:ListItem>Shoulders</asp:ListItem>
            <asp:ListItem>Arms</asp:ListItem>
            <asp:ListItem>Legs</asp:ListItem>
            <asp:ListItem>Cardio</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="lnkButtonGo" runat="server" style="width: 91px;padding: 2px 0px 2px 0px;height: 24px;" CssClass="button" Text="Go"></asp:Button>
        </td>
        </tr>
        </table>
        <asp:Panel ID="viewExercisePanel" runat="server">
            <table>
                <tr style="vertical-align: top;">
                    <td colspan="1" style="width: 140px;">
                        <h5>
                            Exercise Name:</h5>
                        <asp:HyperLink ID="lblExerciseVideo" runat="server">[Video]</asp:HyperLink>
                    </td>
                    <td>
                        <asp:DropDownList ID="ExerciseDDL" runat="server" AutoPostBack="True" CssClass="select"
                            DataTextField="name" DataValueField="id" OnSelectedIndexChanged="ExerciseDDL_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getExercises"
                        TypeName="ExerciseManager"></asp:ObjectDataSource>
                </tr>
                <tr class="description">
                    <td colspan="3">
                        <h5>
                            Description:</h5>
                        <br />
                        <asp:TextBox ID="lblExerciseDescription" onkeypress="return false;" runat="server" Text="None" Height="211px" TextMode="MultiLine" width="511px" Font-Italic="False">None</asp:TextBox>
                        
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="rowWidth">
                        <h5>
                            Equipment</h5>
                        <br />
                        <asp:Label ID="lblExerciseEquipment" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="rowWidth">
                        <h5>
                            MuscleGroups</h5>
                        <br />
                        <asp:Label ID="lblExerciseMuscleGroups" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="exceriseNotFound" runat="server" ForeColor="Red" Text="No exercise found"
            Visible="False"></asp:Label>
        <hr />
        <br />
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
