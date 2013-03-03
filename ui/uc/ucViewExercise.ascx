﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewExercise.ascx.cs"
    Inherits="ui_uc_ucViewExercise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <ContentTemplate>
    <div style="max-width:900px;">
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
        <asp:DropDownList ID="ddlMuscleGroups" runat="server" OnSelectedIndexChanged="MuscleGroupDDL_SelectedIndexChanged"
            AutoPostBack="True">
            <asp:ListItem Value="ALL">All Groups</asp:ListItem>
            <asp:ListItem>Chest</asp:ListItem>
            <asp:ListItem>Back</asp:ListItem>
            <asp:ListItem>Shoulders</asp:ListItem>
            <asp:ListItem>Arms</asp:ListItem>
            <asp:ListItem>Legs</asp:ListItem>
            <asp:ListItem>Cardio</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />

        <asp:Panel ID="viewExercisePanel" runat="server">
            <table class="scheduleTable2">
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
                    <td colspan="3" style="max-width: 925px;">
                        <h5>
                            Description:</h5>
                        <br />
                        <asp:Label ID="lblExerciseDescription" runat="server" Text="None"></asp:Label>
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
            </div>
    </ContentTemplate>

</asp:UpdatePanel>
