<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/default.aspx" BackColor="#F7F7DE"
                BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                Font-Size="10pt">
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>
            Logged in as:
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
