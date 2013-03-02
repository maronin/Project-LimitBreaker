<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCreateRoutineLog.ascx.cs" Inherits="ui_uc_ucCreateRoutineLog" %>
<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagPrefix="uc1" TagName="ucViewExercise" %>

<style type="text/css">
    a {
        text-decoration: none;
    }

    .gv {
        font-size: medium;
        text-align: center;
        margin: 0 auto;
    }

    .auto-style1 {
        width: 100%;
    }

    #tableLog {
        text-align: center;
    }

    .auto-style2 {
        width: 478px;
    }
</style>
<h4>Log Routine Data</h4>
<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="gv" AllowPaging="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name"></asp:BoundField>
                    <asp:BoundField DataField="equipment" HeaderText="Equipment" SortExpression="equipment" />
                    <asp:BoundField DataField="videoLink" HeaderText="Video Link" SortExpression="videoLink" />
                    <asp:BoundField DataField="muscleGroups" HeaderText="Muscle Groups" SortExpression="muscleGroups" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="log" CommandArgument='<%# Eval("id") %>'>Log Data</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:Panel ID="pnlExerciseDetails" runat="server">
                <asp:Literal ID="ltlExerciseName" runat="server" Text=""></asp:Literal>
                <table class="auto-style1" id="tableLog">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label7" runat="server" Text="Weight"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbWeight" runat="server" CausesValidation="True" ValidationGroup="SaveLog"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbWeight" Display="Dynamic" ErrorMessage="Numbers Only" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfWeight" runat="server" ControlToValidate="tbWeight" Display="Dynamic" Enabled="False" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="SaveLog"></asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="4">
                            <asp:Label ID="Label3" runat="server" Text="Note"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbNotes" runat="server" CausesValidation="True" TextMode="MultiLine" ValidationGroup="SaveLog"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label4" runat="server" Text="Distance"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbDistance" runat="server" CausesValidation="True" ValidationGroup="SaveLog"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbDistance" Display="Dynamic" ErrorMessage="Numbers Only" ForeColor="Red" ValidationExpression="^[0-9]*([\.][0-9]{1,3})?$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfDistance" runat="server" ControlToValidate="tbDistance" Display="Dynamic" Enabled="False" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="SaveLog"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label5" runat="server" Text="Time"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbTime_min" runat="server" CausesValidation="True" ValidationGroup="SaveLog" Width="54px"></asp:TextBox>min
                            <asp:TextBox ID="tbTime_sec" runat="server" CausesValidation="True" ValidationGroup="SaveLog" Width="54px"></asp:TextBox>sec
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbTime_min" Display="Dynamic" ErrorMessage="Minutes have to be an Integer" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tbTime_sec" Display="Dynamic" ErrorMessage="Seconds have to be an Integer" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfMinute" runat="server" ControlToValidate="tbTime_min" Display="Dynamic" Enabled="False" ErrorMessage="Minute Required!" ForeColor="Red" ValidationGroup="SaveLog"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfSecond" runat="server" ControlToValidate="tbTime_sec" Display="Dynamic" Enabled="False" ErrorMessage="Second Required!" ForeColor="Red" ValidationGroup="SaveLog"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label6" runat="server" Text="Reps"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbRep" runat="server" CausesValidation="True" ValidationGroup="SaveLog"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbRep" Display="Dynamic" ErrorMessage="Numbers Only" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfReps" runat="server" ControlToValidate="tbRep" Display="Dynamic" Enabled="False" ErrorMessage="Required!" ForeColor="Red" ValidationGroup="SaveLog"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnLog" runat="server" Text="Add Set" OnClick="btnLog_Click" ValidationGroup="SaveLog" />
            </asp:Panel>
            <asp:Panel ID="pnlInfo" runat="server">
                <asp:Label ID="expRewardLbl" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="goalAchievedLbl" runat="server" Text=""></asp:Label>
                <asp:HyperLink ID="goalsLink" runat="server" NavigateUrl="~/LoggedExercise/manageExerciseGoals.aspx" ForeColor="#666666" Visible="False">here</asp:HyperLink>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
