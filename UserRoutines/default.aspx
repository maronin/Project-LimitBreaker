<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="userRoutines_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>List of Routines</h4>
    <asp:RadioButtonList ID="rblRoutines" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="rblRoutines_SelectedIndexChanged">
    </asp:RadioButtonList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="viewRoutines" TypeName="routineManager"></asp:ObjectDataSource>
    <p>
        <em style="font-size: medium">Note: I plan on combining several functions (e.g. View + Delete + Modify routines) in a single table so that each routine listed also has the option to be modified or deleted.</em>
    </p>
    <div id="routines">
        <h4>Create New Routine</h4>
        <h4>Modify Routine</h4>
        <h4>Delete Routine</h4>
    </div>
    <div id="loggedRoutines">
        <h4>View Logged Routine Data</h4>
        <h4>Log Routine Data</h4>
        <h4>Modify Logged Routine Data</h4>
    </div>
    <div id="testContent">
        <h4>View Details (test purposes)</h4>
        <asp:DetailsView ID="dvRoutineDetails" runat="server" Height="50px" CellPadding="5"></asp:DetailsView>
    </div>
</asp:Content>

