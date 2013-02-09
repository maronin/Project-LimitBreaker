<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteModifyRoutine.ascx.cs" Inherits="ui_uc_DeleteModifyRoutine" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!-- credits to: kubben, url: http://www.codeproject.com/Articles/17241/Capturing-the-Enter-key-to-cause-a-button-click -->
<script type="text/javascript">
    function doClick(buttonName, e) {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        var key;

        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            //Get the button the user wants to have clicked
            var btn = document.getElementById(buttonName);
            if (btn != null) { //If we find the button click it
                btn.click();
                event.keyCode = 0
            }
        }
    }

    function OkScript() {
        ;
    }
</script>
<style type="text/css">
    a {
        text-decoration: none;
    }

    .gv {
        font-size: medium;
        text-align: center;
        margin: 0 auto;
    }

    .deleteBtn {
        margin-top: 10px;
        margin-bottom: 10px;
        float: right;
    }

    .auto-style1 {
        width: 100%;
    }

    .selectBtn {
        text-align: center;
    }

    .auto-style2 {
        padding-top: 10px;
    }

    .deletePopupBG {
        opacity: 0.6;
        background-color: black;
    }

    .deletePopup {
        background-color: white;
        text-align: center;
        margin: 0 auto;
        padding: 10px;
    }

    .puOK, .puNO {
        margin: 10px;
    }
</style>
<h4>Modify Routine</h4>
<div id="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="gv">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name"></asp:BoundField>
                    <asp:BoundField DataField="equipment" HeaderText="Equipment" SortExpression="equipment" />
                    <asp:BoundField DataField="videoLink" HeaderText="Video Link" SortExpression="videoLink" />
                    <asp:BoundField DataField="muscleGroups" HeaderText="Muscle Groups" SortExpression="muscleGroups" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id") %>'>Remove</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

            <asp:Panel ID="Panel1" runat="server" Enabled="False" Visible="False">


                <asp:Button ID="btnDelete" runat="server" CssClass="deleteBtn" Text="Delete Routine" />
                <asp:ModalPopupExtender ID="mdeDeleteRoutine" runat="server" TargetControlID="btnDelete" PopupControlID="puDeleteRoutine" CancelControlID="btnPUNO" Enabled="True" BackgroundCssClass="deletePopupBG" DropShadow="True"></asp:ModalPopupExtender>
                <asp:Panel ID="puDeleteRoutine" runat="server" CssClass="deletePopup" style="display:none;">
                    <p>Are you sure you want to delete the routine?</p>
                    <div class="btns">
                        <asp:Button ID="btnPUOK" runat="server" Text="Confirm" CssClass="puOK" OnClick="okButton_Click" /><asp:Button ID="btnPUNO" runat="server" Text="Cancel" CssClass="puNO" /></div>
                </asp:Panel>
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Muscle Groups"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlMuscleGroups" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True">Select a muscle group</asp:ListItem>
                                <asp:ListItem>Chest</asp:ListItem>
                                <asp:ListItem>Back</asp:ListItem>
                                <asp:ListItem>Shoulder</asp:ListItem>
                                <asp:ListItem>Arms</asp:ListItem>
                                <asp:ListItem>Legs</asp:ListItem>
                                <asp:ListItem>Cardio</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Exercise List"></asp:Label>
                            <asp:ListBox ID="lbExerciseList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="id" Width="100%" AutoPostBack="True"></asp:ListBox>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getExercisesByMuscleGroup" TypeName="SystemExerciseManager">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMuscleGroups" Name="muscleGroup" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td class="auto-style2">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Exercise" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Routine Name" Font-Size="Medium"></asp:Label>
                            <br />
                            <asp:TextBox ID="tbRoutineName" runat="server" ValidationGroup="modName" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbRoutineName" ErrorMessage="Alphaneumeric characters only" ForeColor="Red" ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="modName" Display="Dynamic" Font-Size="Medium"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbRoutineName" Display="Dynamic" ErrorMessage="Name is needed" ForeColor="Red" ValidationGroup="modName" Font-Size="Medium"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirm" runat="server" Text="Change Name" OnClick="btnConfirm_Click" PostBackUrl="~/userRoutines/Default.aspx" ValidationGroup="modName" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
