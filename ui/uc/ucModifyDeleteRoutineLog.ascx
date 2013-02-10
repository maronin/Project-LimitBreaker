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
        
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
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
        <h4>Delete All Logs Within Routine</h4>
        <asp:Button ID="btnDeleteAll" runat="server" Text="Delete Logs" />
        <asp:ModalPopupExtender ID="mdeDeleteLoggedExercises" runat="server" TargetControlID="btnDeleteAll" PopupControlID="puDeleteRoutine" CancelControlID="btnPUNO" Enabled="True" BackgroundCssClass="deletePopupBG" DropShadow="True"></asp:ModalPopupExtender>
        <asp:Panel ID="puDeleteRoutine" runat="server" CssClass="deletePopup" Style="display: none;">
            <p>Are you sure you want to delete all your logged exercises so far?</p>
            <div class="btns">
                <asp:Button ID="btnPUOK" runat="server" Text="Confirm" CssClass="puOK" OnClick="okButton_Click" /><asp:Button ID="btnPUNO" runat="server" Text="Cancel" CssClass="puNO" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
