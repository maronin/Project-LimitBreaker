﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<<<<<<< HEAD
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <h3>
            Neil's search motorbikes</h3>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="Server">
            </asp:ScriptManager>
            <label for="_Default">
                SEARCH EXERCISE:
            </label>
            <asp:TextBox runat="server" ID="autocomplete" ClientIDMode="Static" />
            <juice:Autocomplete ID="Autocomplete1" runat="server" 
                TargetControlID="autocomplete" />
        </div>
=======
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
>>>>>>> 382890b28868dc386615a4c8c995b1f1b93ed643
</asp:Content>

