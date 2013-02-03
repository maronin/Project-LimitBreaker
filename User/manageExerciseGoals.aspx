<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="manageExerciseGoals.aspx.cs" Inherits="User_manageExerciseGoals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<hr />
    <div style="width: 50%; margin: 0px auto 0px auto">
        <asp:Button ID="viewGoalsBtn" runat="server" Text="View Exercise Goals" 
            CssClass="button" onclick="viewGoalsBtn_Click" />
        <asp:Button ID="addGoalBtn" runat="server" Text="Add an Exercise Goal" 
            CssClass="button" onclick="addGoalBtn_Click" />
    </div>
<br />

<div>
    <!--add an update panel when the add ne exercise goal issue is tackled-->
    <asp:MultiView ID="exerciseGoalMultiView" runat="server">

        <asp:View ID="noGoalsView" runat="server">

        <h4>You Currently Have No Goals</h4>
        <p>If you want to add a goal for an exercise you have been working on, click on the "Add an Exercise Goal" button above, and you will be directed to a page where you can add goals for yourself.</p>

        </asp:View>

        <asp:View ID="manageGoalsView" runat="server">
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="getAllExerciseGoalsFromUser" TypeName="GoalManager">
                <SelectParameters>
                    <asp:QueryStringParameter Name="userName" QueryStringField="User.Identity.Name" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        <h4>Your Current Exercise Goals</h4>
        
        <div style="float: left;">
            <asp:ListBox ID="userGoalsListBox" runat="server" AutoPostBack="True" 
                DataSourceID="ObjectDataSource1" DataTextField="Exercise" DataValueField="id" 
                Height="400px" Width="230px"></asp:ListBox>
        </div> 

        <div style="float: left;">
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                SelectMethod="getExerciseGoalById" TypeName="GoalManager">
                <SelectParameters>
                    <asp:ControlParameter ControlID="userGoalsListBox" Name="id" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="exerciseGoalDetailsGridView" runat="server" 
                AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                    <asp:BoundField DataField="weight" HeaderText="weight" 
                        SortExpression="weight" />
                    <asp:BoundField DataField="distance" HeaderText="distance" 
                        SortExpression="distance" />
                    <asp:BoundField DataField="time" HeaderText="time" SortExpression="time" />
                    <asp:BoundField DataField="reps" HeaderText="reps" SortExpression="reps" />
                </Columns>
            </asp:GridView>
        </div> 

        </asp:View>

        <asp:View ID="addGoalView" runat="server">

        <h4>Add A New Goal</h4>

        </asp:View>

    </asp:MultiView>
    
</div>



</asp:Content>