<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatePicker.aspx.cs" Inherits="JuiceExamples_DatePicker" %>

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
        <asp:TextBox runat="server" ID="_Default" />
    <Juice:Datepicker ID="Datepicker1" runat="server" TargetControlID="_Default" />
    </div>
    </form>
</body>
</html>
