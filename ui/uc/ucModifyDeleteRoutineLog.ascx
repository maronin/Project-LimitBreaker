<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucModifyDeleteRoutineLog.ascx.cs" Inherits="ui_uc_ucModifyDeleteRoutineLog" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style type="text/css">
    .deletePopupBG {
        opacity: 0.6;
        background-color: black;
    }

    .deletePopup {
        background-color: white;
        text-align: center;
        margin: 0 auto;
        padding: 10px;
    }

    .puOK, .puNO {
        margin: 10px;
    }
</style>
<h4>View Logged Data</h4>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Exercise Name">
                    <ItemTemplate>
                        <asp:Label ID="lblExName" Text='<%# Bind("Exercise.name") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="timeLogged" HeaderText="Time Logged" SortExpression="timeLogged" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="view" CommandArgument='<%# Eval("id") %>'>View Sets</asp:LinkButton>
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
        <br />
        <asp:Panel ID="pnlSets" runat="server">
            <h4>List of Sets</h4>
            <asp:Label ID="lblSets" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <br />
        <h4>Delete All Logs Within Routine</h4>
        <asp:Button ID="btnDeleteAll" runat="server" Text="Delete Logs" CssClass="button" />
        <asp:ModalPopupExtender ID="mdeDeleteLoggedExercises" runat="server" TargetControlID="btnDeleteAll" PopupControlID="puDeleteRoutine" CancelControlID="btnPUNO" Enabled="True" BackgroundCssClass="deletePopupBG" DropShadow="True"></asp:ModalPopupExtender>
        <asp:Panel ID="puDeleteRoutine" runat="server" CssClass="deletePopup" Style="display: none;">
            <p>Are you sure you want to delete all your logged exercises so far?</p>
            <div class="btns">
                <asp:Button ID="btnPUOK" runat="server" Text="Confirm" CssClass="puOK" OnClick="okButton_Click" /><asp:Button ID="btnPUNO" runat="server" Text="Cancel" CssClass="puNO" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
