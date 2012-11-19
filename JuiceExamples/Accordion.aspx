<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accordion.aspx.cs" Inherits="Temp" %>

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
    <Juice:Accordion ID="Accordion1" runat="server">
        <Juice:AccordionPanel Title="Section 1" ID="accWTF" runat="server">
            <PanelContent>
                <p>
                    Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit  amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.
                </p>
            </PanelContent>
        </Juice:AccordionPanel>
        <Juice:AccordionPanel Title="Section 2" runat="server">
            <PanelContent>
                <p>
                    Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In suscipit faucibus urna.
                </p>
            </PanelContent>
        </Juice:AccordionPanel>
        <Juice:AccordionPanel Title="Section 3" runat="server">
            <PanelContent>
                <p>
                    Nam enim risus, molestie et, porta ac, aliquam ac, risus. Quisque lobortis. Phasellus pellentesque purus in massa. Aenean in pede. Phasellus ac libero ac tellus pellentesque semper. Sed ac felis. Sed commodo, magna quis lacinia ornare, quam ante aliquam nisi, eu iaculis leo purus venenatis dui.
                </p>
                <ul>
                    <li>List item one</li>
                    <li>List item two</li>
                    <li>List item three</li>
                </ul>
            </PanelContent>
        </Juice:AccordionPanel>
    </Juice:Accordion>
    </div>
    </form>
</body>
</html>
