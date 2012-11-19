<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
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
            <juice:Autocomplete ID="Autocomplete1" runat="server" TargetControlID="autocomplete"
                Source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" />
        </div>
</asp:Content>
