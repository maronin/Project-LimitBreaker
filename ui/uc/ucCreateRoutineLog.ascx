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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="gv">
                <AlternatingRowStyle BackColor="White" />
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
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
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
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label6" runat="server" Text="Reps"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbRep" runat="server" CausesValidation="True" ValidationGroup="SaveLog"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tbRep" Display="Dynamic" ErrorMessage="Numbers Only" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="SaveLog"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnLog" runat="server" Text="Add Set" OnClick="btnLog_Click" ValidationGroup="SaveLog" />
            </asp:Panel>
            <asp:Panel ID="pnlInfo" runat="server">
                <asp:Label ID="expRewardLbl" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
