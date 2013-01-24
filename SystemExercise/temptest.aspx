<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="temptest.aspx.cs" Inherits="SystemExercise_temptest" %>

<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagName="viewExercise" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<uc1:viewExercise ID="viewTest" runat="server" />

    <asp:TextBox ID="TextBox1" runat="server" Width="449px"></asp:TextBox>

    <asp:Button ID="Button9" runat="server" onclick="Button9_Click" Text="Test" />

</asp:Content>

