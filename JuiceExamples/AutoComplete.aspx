<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AutoComplete.aspx.cs" Inherits="Test_AutoComplete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <label for="_Default">
            Tags:
        </label>
        <asp:TextBox runat="server" ID="_Default" ClientIDMode="Static" />
        <juice:Autocomplete ID="Autocomplete1" runat="server" TargetControlID="_Default"
            Source="ActionScript, AppleScript, Asp, BASIC, C, C++, Clojure, COBOL, ColdFusion, Erlang, Fortran, Groovy, Haskell, Java, JavaScript, Lisp, Perl, PHP, Python, Ruby, Scala, Scheme" />
    </div>
    </form>
</body>
</html>
