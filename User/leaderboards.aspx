<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="leaderboards.aspx.cs" Inherits="User_leaderboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>LimitBreaker Leaderboards</h2>
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

    <p> See who's at the top of:
    <asp:DropDownList ID="orderByddl" runat="server" AutoPostBack="True" 
            onselectedindexchanged="orderByddl_SelectedIndexChanged">
            <asp:ListItem Value="1">Experience Gained</asp:ListItem>
            <asp:ListItem Value="2">Achieved Goals</asp:ListItem>
            <asp:ListItem Value="3">Logged Exercises</asp:ListItem>
    </asp:DropDownList>
    </p>

    <p> Results per Page:
    <asp:DropDownList ID="resultsddl" runat="server" AutoPostBack="True" 
            onselectedindexchanged="resultsddl_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
    </asp:DropDownList>
    </p>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" DataSourceID="ObjectDataSource1">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Rank" HeaderStyle-Width="60">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Width="75px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="userName" HeaderText="Username" 
                SortExpression="userName" HeaderStyle-Width="200" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="level" HeaderText="Level" SortExpression="level" 
                HeaderStyle-Width="200" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="experience" HeaderText="Current Experience" 
                SortExpression="experience" HeaderStyle-Width="200" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="numGoals" HeaderText="Achieved Goals" 
                SortExpression="numGoals" HeaderStyle-Width="200" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="numLogged" HeaderText="Logged Exercises" 
                SortExpression="numLogged" HeaderStyle-Width="200" >
            <HeaderStyle Width="200px" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="40" Font-Size="Large" BorderStyle="Solid" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="35px" />
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

    <br />
    <br />
        
    <asp:MultiView ID="userRankMultiView" runat="server">
    
    <asp:View ID="unAuthenticatedView" runat="server">
        <p>Log in or <asp:HyperLink ID="signUpLink" runat="server" NavigateUrl="~/User/createUser.aspx">sign up</asp:HyperLink> to see where you are on the leaderboards!</p>
    </asp:View>

    <asp:View ID="authenticatedView" runat="server">
        <h3><asp:Label ID="userNamelbl" runat="server" Text=""></asp:Label>'s Current Rank</h3>

        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
            GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="Rank" HeaderStyle-Width="60">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle Width="75px" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="userName" HeaderText="Username" 
                    SortExpression="userName" HeaderStyle-Width="200" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="level" HeaderText="Level" SortExpression="level" 
                    HeaderStyle-Width="200" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="experience" HeaderText="Current Experience" 
                    SortExpression="experience" HeaderStyle-Width="200" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="numGoals" HeaderText="Achieved Goals" 
                    SortExpression="numGoals" HeaderStyle-Width="200" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="numLogged" HeaderText="Logged Exercises" 
                    SortExpression="numLogged" HeaderStyle-Width="200" >
                <HeaderStyle Width="200px" />
            </asp:BoundField>
            </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

    </asp:View>

    </asp:MultiView>

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>