<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="searchAndViewExercises.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="Server">
        </asp:ScriptManager>
        <label for="_Default">
            SEARCH EXERCISE FOR AN EXERCISE:
        </label>
        <asp:TextBox runat="server" ID="exerciseSearchBox" ClientIDMode="Static" />
        <juice:Autocomplete ID="exerciseAutoComplete" runat="server" TargetControlID="exerciseSearchBox" />
        <button id="exerciseSearchButton" runat="server">
            Search</button>
        <juice:Button ID="Button1" TargetControlID="exerciseSearchButton" runat="server" />
    </div>
</asp:Content>
