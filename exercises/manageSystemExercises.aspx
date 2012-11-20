<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="manageSystemExercises.aspx.cs" Inherits="Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <h3>Manage System Exercises</h3>
    <h4>Add system exercises</h4>
    <h4>Delete system exercise</h4>
    <h4>Disable system exercise</h4>
    <h4>Modify system exercise</h4>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="getAllExercises" TypeName="Layer2Manager"></asp:ObjectDataSource>
        <asp:DropDownList ID="ddlExercises" runat="server" 
            onselectedindexchanged="ddlExercises_SelectedIndexChanged" 
            DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" Visible="False">
        </asp:DropDownList>
        </div>
</asp:Content>

