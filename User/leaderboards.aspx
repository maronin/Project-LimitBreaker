<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="leaderboards.aspx.cs" Inherits="User_leaderboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>Leaderboards</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="getLeaderBoardValues" TypeName="LeaderboardManager" 
            UpdateMethod="getLeaderBoardValues">
        <SelectParameters>
            <asp:ControlParameter ControlID="orderByddl" Name="orderBy" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="orderBy" Type="Int32" />
        </UpdateParameters>
        </asp:ObjectDataSource>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" DataSourceID="ObjectDataSource1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Rank">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="userName" HeaderText="userName" 
                SortExpression="userName" />
            <asp:BoundField DataField="level" HeaderText="level" SortExpression="level" />
            <asp:BoundField DataField="experience" HeaderText="experience" 
                SortExpression="experience" />
            <asp:BoundField DataField="numGoals" HeaderText="numGoals" 
                SortExpression="numGoals" />
            <asp:BoundField DataField="numLogged" HeaderText="numLogged" 
                SortExpression="numLogged" />
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
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

        <asp:DropDownList ID="orderByddl" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">Level</asp:ListItem>
            <asp:ListItem Value="2">Achieved Goals</asp:ListItem>
            <asp:ListItem Value="3">Logged Exercises</asp:ListItem>
        </asp:DropDownList>

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>