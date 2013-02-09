<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="userRoutines_Default" %>

<%@ Register Src="~/ui/uc/CreateNewRoutine.ascx" TagPrefix="uc1" TagName="CreateNewRoutine" %>
<%@ Register Src="~/ui/uc/DeleteModifyRoutine.ascx" TagPrefix="uc1" TagName="DeleteModifyRoutine" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content {
            padding-bottom: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <p>You need to log in first before you can manage your routines.</p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h4>List of Routines</h4>
            <div id="content">
                <asp:RadioButtonList ID="rblRoutines" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="rblRoutines_SelectedIndexChanged" Font-Size="Medium" Width="100%">
                </asp:RadioButtonList>
            </div>
            <div id="routines">
                <div id="create">
                    <uc1:CreateNewRoutine runat="server" ID="CreateNewRoutine" />
                </div>
                <div id="deleteModify">
                    <uc1:DeleteModifyRoutine runat="server" ID="DeleteModifyRoutine" />
                </div>
            </div>
            <div id="loggedRoutines">
                <h4>View Logged Routine Data</h4>
                <h4>Log Routine Data</h4>
                <h4>Modify Logged Routine Data</h4>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

