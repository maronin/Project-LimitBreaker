<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="User_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
    <h1>Welcome LimitBreaker</h1>
    <h2><asp:Label ID="alias" runat="server"></asp:Label>'s User Profile</h2>

    <div style="text-align:center; float:left;">
            <asp:Label ID="levelLbl" runat="server" Text=""></asp:Label>
        <br />
        <br />
            <meter runat="server" id="expBar" style="width:275px; height:19px;" min="0"></meter>
        <br />
        <br />
            <asp:Label ID="currentExpLbl" runat="server" Text=""></asp:Label>
            <asp:Label ID="reqExpLbl" runat="server" Text=""></asp:Label>
    </div>

    <div style="clear:both; height:0; line-height:0; display:block; margin-bottom:30px;"></div>

    <div style="">
    <table>
        <tr>
            <td class="auto-style1">Weight</td>
            <td class="auto-style1">
                <asp:TextBox ID="newWeight" runat="server" ValidationGroup="profileUpdate" 
                    Width="60px"></asp:TextBox> kg</td>
            <td class="auto-style1">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ControlToValidate="newWeight" 
                    ForeColor="Red" 
                    ValidationExpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$" 
                    ValidationGroup="profileUpdate" Display="Dynamic">*Invalid weight</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="RequiredFieldValidator" Text="*Required" 
                    ControlToValidate="newWeight" Display="Dynamic" ForeColor="Red" ValidationGroup="profileUpdate"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>Height</td>
            <td class="auto-style1">
                <asp:TextBox ID="newHeight" runat="server" ValidationGroup="profileUpdate" 
                    Width="60px"></asp:TextBox> cm</td>
            <td class="auto-style1">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ControlToValidate="newHeight" 
                    ForeColor="Red" 
                    ValidationExpression="^[1-9][0-9]*(\.[0-9]+)?|0+\.[0-9]*[1-9][0-9]*$" 
                    ValidationGroup="profileUpdate" Display="Dynamic">*Invalid height</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="RequiredFieldValidator" Text="*Required" 
                    ControlToValidate="newHeight" Display="Dynamic" ForeColor="Red" ValidationGroup="profileUpdate"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="auto-style1">Resting Metabolic Rate
            <asp:Image ID="qMark1" runat="server" AlternateText="Question Mark" height="15px" Width="15px"
                    ImageUrl="~/ui/images/Icon_question_mark_30x30.png" 
                    ToolTip="The energy required to perform vital body functions such as respiration and heart beating while the body is at rest"/>
            </td>
            <td class="auto-style1">
                <asp:Label ID="rmr" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style1">Body Mass Index
                <asp:Image ID="qMark2" runat="server" AlternateText="Question Mark" height="15px" Width="15px"
                    ImageUrl="~/ui/images/Icon_question_mark_30x30.png" 
                    ToolTip="A weight-to-height ratio that is used as an indicator of obesity and underweight"/>
            </td>
            <td class="auto-style1">
                <asp:Label ID="bmi" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr><td class="auto-style1">          
                <asp:Button ID="updateStats" runat="server" Text="Update" ValidationGroup="profileUpdate" OnClick="updateStats_Click" /></td>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="updateResultLbl" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

