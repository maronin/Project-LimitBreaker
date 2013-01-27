<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="userRoutines_Default" %>

<%@ Register Src="~/ui/uc/CreateNewRoutine.ascx" TagPrefix="uc1" TagName="CreateNewRoutine" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4>List of Routines</h4>
    <asp:RadioButtonList ID="rblRoutines" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="rblRoutines_SelectedIndexChanged">
            </asp:RadioButtonList>
    <p>
        <em style="font-size: medium">Note: I plan on combining several functions (e.g. View + Delete + Modify routines) in a single table so that each routine listed also has the option to be modified or deleted.</em>
    </p>
    <div id="routines">
        <div id="create">
            <uc1:CreateNewRoutine runat="server" ID="CreateNewRoutine"/>
        </div>
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
        <p>
            User:
            <asp:LoginName ID="LoginName1" runat="server" Visible="False" />
        </p>
        <asp:DetailsView ID="dvRoutineDetails" runat="server" Height="50px" CellPadding="5"></asp:DetailsView>
    </div>
</asp:Content>

