<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="userRoutines_Default" %>

<%@ Register Src="~/ui/uc/CreateNewRoutine.ascx" TagPrefix="uc1" TagName="CreateNewRoutine" %>
<%@ Register Src="~/ui/uc/DeleteModifyRoutine.ascx" TagPrefix="uc1" TagName="DeleteModifyRoutine" %>
<%@ Register Src="~/ui/uc/ucCreateRoutineLog.ascx" TagPrefix="uc1" TagName="ucCreateRoutineLog" %>
<%@ Register Src="~/ui/uc/ucModifyDeleteRoutineLog.ascx" TagPrefix="uc1" TagName="ucModifyDeleteRoutineLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .content {
            padding-bottom: 15px;
        }

        #buttons {
            width: 250px;
            margin: 0 auto;
        }

        .button {
            margin: 10px;
            float: right;
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
            <div class="content">
                <asp:RadioButtonList ID="rblRoutines" runat="server" AutoPostBack="True" DataTextField="name" DataValueField="id" Font-Size="Medium" Width="100%">
                </asp:RadioButtonList>
            </div>
            <asp:Panel ID="pnlButtons" runat="server">

                <div id="buttons">
                    <asp:Button ID="btnModifyRoutines" runat="server" Text="Modify Routines" CssClass="button" OnClick="btnModifyRoutines_Click" />
                    <asp:Button ID="btnCreateRoutines" runat="server" Text="Create Routine" CssClass="button" OnClick="btnCreateRoutines_Click" />
                    <asp:Button ID="btnViewLogs" runat="server" Text="View Logs" CssClass="button" OnClick="btnViewLogs_Click" />
                    <asp:Button ID="btnCreateLogs" runat="server" Text="Create Logs" CssClass="button" OnClick="btnCreateLogs_Click" />
                </div>
            </asp:Panel>

            <asp:MultiView ID="mvRoutine" runat="server">
                <asp:View ID="ViewRoutines" runat="server">
                    <div id="deleteModify">
                        <uc1:DeleteModifyRoutine runat="server" ID="DeleteModifyRoutine" />
                    </div>
                </asp:View>
                <asp:View ID="CreateRoutines" runat="server">
                    <div id="create">
                        <uc1:CreateNewRoutine runat="server" ID="CreateNewRoutine" />
                    </div>
                </asp:View>
                <asp:View ID="ViewLoggedData" runat="server">
                    <uc1:ucModifyDeleteRoutineLog runat="server" ID="ucModifyDeleteRoutineLog" />
                </asp:View>
                <asp:View ID="LogRoutineData" runat="server">
                    <uc1:ucCreateRoutineLog runat="server" ID="ucCreateRoutineLog" />
                </asp:View>
            </asp:MultiView>
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" />
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

