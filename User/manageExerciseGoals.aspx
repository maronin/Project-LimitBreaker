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
        <h4>Your Current Exercise Goals</h4>
        <div style="float: left; padding: 10px;">
            Order Goals By:
            <asp:RadioButtonList ID="orderByRbl" runat="server" AutoPostBack="True" Width="230" 
                RepeatDirection="Horizontal" TextAlign="Left" 
                onselectedindexchanged="orderByRbl_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Name</asp:ListItem>
                <asp:ListItem Value="1">ID</asp:ListItem>
            </asp:RadioButtonList>
            <asp:ListBox ID="userGoalsListBox" runat="server" AutoPostBack="True" 
                Height="400px" Width="230px" 
                onselectedindexchanged="userGoalsListBox_SelectedIndexChanged"></asp:ListBox>
        </div> 
        
        <div style="float: left; padding: 10px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="exerciseNameLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="timelbl" runat="server" Text="Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="distanceLbl" runat="server" Text="Distance"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="weightlbl" runat="server" Text="Weight"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="repLbl" runat="server" Text="Reps"></asp:Label>
                </td>
            </tr>

            <asp:MultiView ID="singleGoalAttributesMultiView" runat="server">
                <asp:View ID="viewGoalView" runat="server">   
                    <tr>
                        <td>
                            <asp:Label ID="goalTimeLbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalDistancelbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalWeightLbl" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="goalRepsLbl" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </asp:View>

                <asp:View ID="updaetGoalView" runat="server">
                    
                </asp:View>
            </asp:MultiView>
        </table>

        </div> 

        </asp:View>

        <asp:View ID="addGoalView" runat="server">

        <h4>Add A New Goal</h4>

        </asp:View>

    </asp:MultiView>
    
</div>



</asp:Content>