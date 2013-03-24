<%@ Page Title="Use Case 5.7" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="leaderboards.aspx.cs" Inherits="User_leaderboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="exerciseForm">
<h2 style="text-align:center;">LimitBreaker Leaderboards</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="useCase"><h3>Use Case 5.7</h3></div>
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

    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
            AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_OnRowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="rank" HeaderText="Rank" SortExpression="rank">
                <HeaderStyle  Width="75px" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="40" Font-Size="Large" />
            <PagerStyle BackColor="#5D7B9D" ForeColor="White" HorizontalAlign="Center" />
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
    </div>
        
    <asp:MultiView ID="userRankMultiView" runat="server">
    
    <asp:View ID="unAuthenticatedView" runat="server">
        <br />
        <br />
        <p>Log in or <asp:HyperLink ID="signUpLink" runat="server" NavigateUrl="~/User/createUser.aspx">sign up</asp:HyperLink> to see where you are on the leaderboards!</p>
    </asp:View>

    <asp:View ID="authenticatedView" runat="server">
        <div>

            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                GridLines="None">
                <Columns>
                    <asp:BoundField DataField="rank" HeaderText="" 
                        SortExpression="rank" HeaderStyle-Width="75" ><HeaderStyle HorizontalAlign="Center" Width="75px" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="userName" HeaderText="" 
                        SortExpression="userName" HeaderStyle-Width="200" ><HeaderStyle Width="200px" /></asp:BoundField>
                    <asp:BoundField DataField="level" HeaderText="" SortExpression="" 
                        HeaderStyle-Width="200" ><HeaderStyle Width="200px" /></asp:BoundField>
                    <asp:BoundField DataField="experience" HeaderText="" 
                        SortExpression="experience" HeaderStyle-Width="200" ><HeaderStyle Width="200px" /></asp:BoundField>
                    <asp:BoundField DataField="numGoals" HeaderText="" 
                        SortExpression="numGoals" HeaderStyle-Width="200" ><HeaderStyle Width="200px" /></asp:BoundField>
                    <asp:BoundField DataField="numLogged" HeaderText="" 
                        SortExpression="numLogged" HeaderStyle-Width="200" ><HeaderStyle Width="200px" /></asp:BoundField>
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Large" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="35px" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </asp:View>

    </asp:MultiView>

    </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    </div>
</asp:Content>