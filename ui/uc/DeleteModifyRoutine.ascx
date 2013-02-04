<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteModifyRoutine.ascx.cs" Inherits="ui_uc_DeleteModifyRoutine" %>
<h4>Modify Routine</h4>
<style type="text/css">
    a {
        text-decoration: none;
    }

    .gv {
        font-size: medium;
        text-align: center;
    }

    .deleteBtn {
        margin-top: 10px;
        float: right;
    }
</style>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="gv">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name"></asp:BoundField>
        <asp:BoundField DataField="equipment" HeaderText="Equipment" SortExpression="equipment" />
        <asp:BoundField DataField="videoLink" HeaderText="Video Link" SortExpression="videoLink" />
        <asp:BoundField DataField="muscleGroups" HeaderText="Muscle Groups" SortExpression="muscleGroups" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id") %>'>Remove</asp:LinkButton>
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


<asp:Button ID="btnDelete" runat="server" CssClass="deleteBtn" Enabled="False" OnClick="btnDelete_Click" Text="Delete Routine" Visible="False" />



