<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Button.aspx.cs" Inherits="JuiceExamples_Button" %>

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
        <button id="_DefaultButton" runat="server">
            A Button Element</button>
        <juice:Button ID="Button1" TargetControlID="_DefaultButton" runat="server" />
        <input type="submit" value="An Input Element" id="_DefaultInput" runat="server" />
        <juice:Button ID="Button2" TargetControlID="_DefaultInput" runat="server" />
        <a href="http://appendto.com" id="_Default" runat="server">An Anchor Element</a>
        <juice:Button ID="Button3" TargetControlID="_Default" runat="server" />
        <div id="_RadioButtons" runat="server">
            <asp:RadioButton ID="_Radio1" Text="Choice 1" runat="server" />
            <asp:RadioButton ID="_Radio2" Text="Choice 2" Checked="true" runat="server" />
            <asp:RadioButton ID="_Radio3" Text="Choice 3" runat="server" />
        </div>
        <juice:Buttonset ID="Buttonset1" TargetControlID="_RadioButtons" runat="server" />
    </div>
    </form>
</body>
</html>
