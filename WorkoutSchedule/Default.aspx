<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="WorkoutSchedule_Default4" %>

<%@ Register Src="~/ui/uc/ucViewExercise.ascx" TagName="viewExercises" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #CalImage
        {
            height: 20px;
            width: 20px;
        }
        .rowWidth
        {
            vertical-align: top;
            width: 100px;
            height: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <p>
                You need to log in first before you can manage your schedule.</p>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h1>
                Schedule Calendar</h1>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-----------------------------------------------------------------Multiview Calendar ------------------------------------------------------------------------>
                    <asp:MultiView ID="multiViewCalendar" runat="server">
                        <asp:View ID="view_calendar" runat="server">
                            <asp:LinkButton ID="lnk_add_item" runat="server" Text="Add Item" OnClick="lnk_add_item_Click" />
                            <asp:LinkButton ID="lnk_remove_item" runat="server" Text="Remove/Modify Item" OnClick="lnk_remove_item_Click" />
                            <br />
                            <br />
                            <asp:Label ID="exercises" runat="server" Text="Exercises" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="routines" runat="server" Text="Routines" Font-Bold="True"></asp:Label>
                            <asp:Panel ID="pnl_calendar" runat="server" CssClass="calendar">
                                <asp:DropDownList ID="ddl_month" runat="server" />
                                <asp:DropDownList ID="ddl_year" runat="server" />
                                <asp:LinkButton ID="lnk_loadCalendar" runat="server" Text="Go" OnClick="lnk_loadCalendar_Click"
                                    CssClass="buttonGo" />
                                <asp:Panel ID="pnl_monthSelector" runat="server" CssClass="calendarMonthSelector">
                                    <asp:LinkButton ID="lnkBtnPrevMonth" runat="server" OnClick="prevMonth" CssClass="PrevMonth"><<</asp:LinkButton>
                                    <asp:LinkButton ID="lnkBtnNextMonth" runat="server" OnClick="nextMonth" CssClass="NextMonth">>></asp:LinkButton>
                                    <div class="today">
                                        <asp:LinkButton ID="lnkBtnToday" runat="server" OnClick="today">Today</asp:LinkButton>
                                        <br />
                                        <asp:Label ID="lblToday" runat="server" Text=""></asp:Label></div>
                                </asp:Panel>
                                <asp:Panel ID="pnl_days" runat="server" CssClass="DaysOfWeek">
                                    <table id="week">
                                        <tr>
                                            <td>
                                                Sun
                                            </td>
                                            <td>
                                                Mon
                                            </td>
                                            <td>
                                                Tue
                                            </td>
                                            <td>
                                                Wed
                                            </td>
                                            <td>
                                                Thu
                                            </td>
                                            <td>
                                                Fri
                                            </td>
                                            <td>
                                                Sat
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Repeater ID="rpt_emptyDates" runat="server" OnItemDataBound="rpt_emptyDates_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Panel ID="pnl_emptyDate" runat="server" CssClass="calendarDay" ScrollBars="Auto">
                                            <asp:Label ID="lblEmpty" runat="server" Text=""></asp:Label>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater ID="rpt_calendar" runat="server" OnItemDataBound="rpt_calendar_ItemDataBound"
                                    OnItemCommand="ItemCommand">
                                    <ItemTemplate>
                                        <!-- onMouseOver ="this.style.backgroundImage='url(http://www.yellowcalx.com/wp-content/uploads/2012/04/yellow.png)'" onMouseOut ="this.style.backgroundImage='url(http://www.takenseriouslyamusing.com/wp-content/uploads/2012/08/Blue.png)'" -->
                                        <asp:Panel ID="pnl_calendarDay" runat="server" CssClass="calendarDay" ScrollBars="Auto">
                                            <asp:LinkButton ID="lnk_dayLink" runat="server" CommandName="ButtonEvent" CssClass="date"
                                                CommandArgument="<%# Container.DataItem %>" Text="<%#Container.DataItem %>" />
                                            <br />
                                            <asp:Label ID="lbl_dayEvents" CssClass="events" runat="server" Text=""></asp:Label>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div style="clear: both; height: 0; overflow: hidden">
                                    &nbsp;</div>
                                <!-- This is needed to force the container (inc. background) around all the days if Days are floated with CSS -->
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="add_item" runat="server">
                            <!------------------------------------------------------------------------------------------------------- MultiView Add Item ----------------------------------------------------------------------------------->
                            <asp:MultiView ID="addItemView" runat="server">
                                <asp:View ID="choiceView" runat="server">
                                    <h3>
                                        Add a routine or exercise</h3>
                                    <div id="scheduleChoice">
                                        <asp:Button ID="addRoutine" runat="server" Text="Routine" OnClick="addRoutine_Click"
                                            CssClass="button" />
                                        <asp:Button ID="addExercise" runat="server" Text="Exercise" OnClick="addExercise_Click"
                                            CssClass="button" />
                                        <br />
                                        <asp:Button ID="goBack" runat="server" Text="Back" OnClick="goBack_Click" CssClass="button" />
                                    </div>
                                </asp:View>
                                <!---------------------------------------------------------------------------- Schedule Exercise view[0] --------------------------------------------------------------------------------------->
                                <asp:View ID="addExerciseView" runat="server">
                                    <h3>
                                        Schedule a new Exercise!</h3>
                                    <br />
                                    <uc1:viewExercises ID="viewExercises" runat="server" />
                                    <asp:Panel ID="TimeSelectPanel" runat="server">
                                        Time:
                                        <asp:DropDownList ID="ddlHours_exercise" runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="ddlMinutes_exercise" runat="server">
                                            <asp:ListItem Value="00"></asp:ListItem>
                                            <asp:ListItem Value="05"></asp:ListItem>
                                            <asp:ListItem Value="10"></asp:ListItem>
                                            <asp:ListItem Value="15"></asp:ListItem>
                                            <asp:ListItem Value="20"></asp:ListItem>
                                            <asp:ListItem Value="25"></asp:ListItem>
                                            <asp:ListItem Value="30"></asp:ListItem>
                                            <asp:ListItem Value="35"></asp:ListItem>
                                            <asp:ListItem Value="40"></asp:ListItem>
                                            <asp:ListItem Value="45"></asp:ListItem>
                                            <asp:ListItem Value="50"></asp:ListItem>
                                            <asp:ListItem Value="55"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlAmPm_exercise" runat="server">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        Date:
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtenderExercise" runat="server"
                                            TargetControlID="tbDate_exercise" FilterType="Custom" ValidChars='()1234567890-/'>
                                        </asp:FilteredTextBoxExtender>
                                        <asp:TextBox ID="tbDate_exercise" runat="server" Enabled="true" ReadOnly="False"
                                            AutoCompleteType="Disabled"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorExercise" runat="server"
                                            ErrorMessage="Invalid Date" ControlToValidate="tbDate_exercise" Font-Size="Medium"
                                            ForeColor="Red" ValidationExpression="(((0?[1-9]|1[012])[/.](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])[/.](29|30)|(0?[13578]|1[02])/31)[/.](19|[2-9]\d)\d{2}|0?2[/.]29[/.]((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))"
                                            ValidationGroup="ScheduleExercise" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ControlToValidate="tbDate_exercise" ValidationGroup="ScheduleExercise"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CalendarExtender ID="CalendarExtenderExercise" runat="server" TargetControlID="tbDate_exercise">
                                        </asp:CalendarExtender>
                                        <br />
                                        <asp:CheckBox ID="cbRepeat" runat="server" OnCheckedChanged="reaptClicked" AutoPostBack="true"/>
                                        Repeat...
                                        
                                        
                                        <asp:Panel ID="pnlRepeatItem" runat="server" Visible="false">
                                            <asp:Panel ID="pnlDim" runat="server" Visible="false">
                                                <div class="dim">
                                                </div>
                                            </asp:Panel>
                                            <div class="repeatForm">
                                                <h3>
                                                    Repeat</h3>
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: right;">
                                                            Repeats:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRepeatType" runat="server" OnSelectedIndexChanged="ddlRepeatType_indexChanged" AutoPostBack="true">
                                                                <asp:ListItem Text="Daily"></asp:ListItem>
                                                                <asp:ListItem Text="Weekly"></asp:ListItem>
                                                                <asp:ListItem Text="Monthly"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: right;">
                                                            Repeat Every:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRepeatEvery" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblDayType" runat="server" Text="days"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="repeatOn" runat="server" visible="false">
                                                        <td style="vertical-align: middle; text-align: right;">
                                                            Repeat on:
                                                        </td>
                                                        <td>
                                                            <asp:CheckBoxList ID="cblDayOfWeek" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="S"></asp:ListItem>
                                                                <asp:ListItem Text="M"></asp:ListItem>
                                                                <asp:ListItem Text="T"></asp:ListItem>
                                                                <asp:ListItem Text="W"></asp:ListItem>
                                                                <asp:ListItem Text="T"></asp:ListItem>
                                                                <asp:ListItem Text="F"></asp:ListItem>
                                                                <asp:ListItem Text="S"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: middle; text-align: right;">
                                                            Starts on:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbStartsOnDate" runat="server" Enabled="false" Width="180px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: right;">
                                                            Ends:
                                                        </td>
                                                        <td>
                                                            <table >
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblEnd" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblEnd_IndexChanged" style="width: 70px;">
                                                                            <asp:ListItem Text="After" Selected="True">After </asp:ListItem>
                                                                            <asp:ListItem Text="On" >On </asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbEndAfter" runat="server" Width="40px" MaxLength="1">5</asp:TextBox>
                                                                        occurances
                                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" 
                                                                         TargetControlID="tbEndOnDate"
                                                                         FilterType="Custom" 
                                                                         ValidChars='()1234567890-/'>
                                                                        </asp:FilteredTextBoxExtender>

                                                                    <asp:TextBox ID="tbEndOnDate" runat="server" Enabled="false" ReadOnly="False" AutoCompleteType="Disabled" Width="88px" ></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                        ErrorMessage="Invalid Date" ControlToValidate="tbEndOnDate" Font-Size="Medium"
                                                                        ForeColor="Red" ValidationExpression="(((0?[1-9]|1[012])[/.](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])[/.](29|30)|(0?[13578]|1[02])/31)[/.](19|[2-9]\d)\d{2}|0?2[/.]29[/.]((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))"
                                                                        ValidationGroup="EndOnRepeat" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                            ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                                            ControlToValidate="tbEndOnDate" ValidationGroup="EndOnRepeat" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:CalendarExtender ID="calendarEndsOnRepeat" runat="server" TargetControlID="tbEndOnDate">
                                                                    </asp:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnDoneRepeat" runat="server" Text="Done"  OnClick="btnDoneRepeat_Clicked"/>
                                                            <asp:Button ID="btnCancelRepeat" runat="server" Text="Cancel"  OnClick="btnCancelRepeat_Clicked"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <hr />
                                    </asp:Panel>
                                    <asp:Button ID="btnGoBack1" runat="server" Text="Back To Calendar" OnClick="goBack_Click"
                                        CssClass="button" />
                                    <asp:Button ID="btnScheduleExercise" runat="server" Text="Schedule Exercise" OnClick="btnScheduleExercise_Click"
                                        CssClass="button" ValidationGroup="ScheduleExercise" />
                                    <br />
                                    <asp:Label ID="lblResult_Exercise" runat="server" Text=""></asp:Label>
                                </asp:View>
                                <!---------------------------------------------------------------------------- Schedule Routine  --------------------------------------------------------------------------------------->
                                <asp:View ID="addRoutineView" runat="server">
                                    <h3>
                                        Schedule a new Routine!</h3>
                                    <table class="scheduleTable">
                                        <tr>
                                            <td>
                                                Step 1. Select a routine:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRoutines" runat="server" DataTextField="name" DataValueField="id">
                                                </asp:DropDownList>
                                                <asp:LinkButton ID="lnkNotHaveRoutines" runat="server" Visible="False" OnClick="changeToRoutine">Click here to add a new routine</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Step 2. Select Start Time:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlHours_routine" runat="server">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                </asp:DropDownList>
                                                :
                                                <asp:DropDownList ID="ddlMinutes_routine" runat="server">
                                                    <asp:ListItem Value="00"></asp:ListItem>
                                                    <asp:ListItem Value="05"></asp:ListItem>
                                                    <asp:ListItem Value="10"></asp:ListItem>
                                                    <asp:ListItem Value="15"></asp:ListItem>
                                                    <asp:ListItem Value="20"></asp:ListItem>
                                                    <asp:ListItem Value="25"></asp:ListItem>
                                                    <asp:ListItem Value="30"></asp:ListItem>
                                                    <asp:ListItem Value="35"></asp:ListItem>
                                                    <asp:ListItem Value="40"></asp:ListItem>
                                                    <asp:ListItem Value="45"></asp:ListItem>
                                                    <asp:ListItem Value="50"></asp:ListItem>
                                                    <asp:ListItem Value="55"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlAmPm_routine" runat="server">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Step 3. Select Start Date:
                                            </td>
                                            <td>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtenderRoutine" runat="server" TargetControlID="tbDate_routine"
                                                    FilterType="Custom" ValidChars='()1234567890-/'>
                                                </asp:FilteredTextBoxExtender>
                                                <asp:TextBox ID="tbDate_routine" runat="server" Enabled="true" ReadOnly="False" AutoCompleteType="Disabled"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRoutine" runat="server"
                                                    ErrorMessage="Invalid Date" ControlToValidate="tbDate_routine" Font-Size="Medium"
                                                    ForeColor="Red" ValidationExpression="(((0?[1-9]|1[012])[/.](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])[/.](29|30)|(0?[13578]|1[02])/31)[/.](19|[2-9]\d)\d{2}|0?2[/.]29[/.]((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))"
                                                    ValidationGroup="ScheduleRoutine" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                        ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                        ControlToValidate="tbDate_routine" ValidationGroup="ScheduleRoutine" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CalendarExtender ID="CalendarExtenderRoutine" runat="server" TargetControlID="tbDate_routine">
                                                </asp:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btnScheduleRoutine" runat="server" Text="Schedule Routine" OnClick="btnScheduleRoutine_Click"
                                        CssClass="button" ValidationGroup="ScheduleRoutine" />
                                    <br />
                                    <asp:Button ID="btnGoBack2" runat="server" Text="Back To Calendar" OnClick="goBack_Click"
                                        CssClass="button" />
                                    <asp:Label ID="lblResult_Routine" runat="server" Text=""></asp:Label>
                                </asp:View>
                            </asp:MultiView>
                        </asp:View>
                        <asp:View ID="removeItemView" runat="server">
                            <h3>
                                Remove/Modify Items</h3>
                            Select a date to view scheduled items for that date:
                            <br />
                            
                            
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbRemoveDate"
                                FilterType="Custom" ValidChars='()1234567890-/'>
                            </asp:FilteredTextBoxExtender>
                            
                            <asp:LinkButton ID="lnkPrevMonthForRemove" runat="server" OnClick="prevRemoveMonth"><<</asp:LinkButton>
                            <asp:TextBox ID="tbRemoveDate" runat="server" Enabled="true" ReadOnly="False" AutoCompleteType="Disabled"
                                AutoPostBack="True" OnTextChanged="tbRemoveDate_TextChanged" ValidationGroup="RemoveItem"></asp:TextBox>
                            <asp:LinkButton ID="lnkNextMonthForRemove" runat="server" OnClick="nextRemoveMonth">>></asp:LinkButton>
                            <br />
                           or <asp:LinkButton ID="lnkButtonViewAll" runat="server" OnClick="lnkButtonViewAll_Click">View All</asp:LinkButton> for this month
                            <hr />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Date"
                                ControlToValidate="tbRemoveDate" Font-Size="Medium" ForeColor="Red" ValidationExpression="(((0?[1-9]|1[012])[/.](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])[/.](29|30)|(0?[13578]|1[02])/31)[/.](19|[2-9]\d)\d{2}|0?2[/.]29[/.]((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))"
                                ValidationGroup="RemoveItem" Display="Dynamic"></asp:RegularExpressionValidator><%--<asp:RequiredFieldValidator
                                    ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="tbRemoveDate" ValidationGroup="RemoveItem" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            <asp:CalendarExtender ID="calendarRemoveItem" runat="server" TargetControlID="tbRemoveDate">
                            </asp:CalendarExtender>
                            <asp:GridView ID="GridViewScheduledItems" runat="server" AutoGenerateColumns="False"
                                OnRowCommand="GridView1_RowCommand" OnRowDeleted="GridView1_RowDeleted" BackColor="White"
                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                GridLines="Vertical" CssClass="gv" AllowPaging="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="itemName" HeaderText="Scheduled Item" SortExpression="itemName">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="startTime" HeaderText="Start Time" SortExpression="startTime" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkModify" runat="server" CommandName="modify" CommandArgument='<%# Eval("id") + ";" +Eval("isExericse")%>'>Modify</asp:LinkButton>
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandName="del" OnClientClick="return confirm('Doing this will irreversibly remove the scheduled item from the system. Are you sure?');"
                                                CommandArgument='<%# Eval("id") + ";" +Eval("isExericse")%>'>Remove</asp:LinkButton>
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
                            <asp:Label ID="lblRemoveResult" runat="server" Text="There are no items scheduled for this day!"
                                ForeColor="Red" Visible="False"></asp:Label>
                            <asp:ObjectDataSource ID="ScheduledItems" runat="server"></asp:ObjectDataSource>
                            <br />
                            <asp:Panel ID="pnlModifyItem" runat="server" Visible="False">
                                <h5>
                                    Description:</h5>
                                <br />
                                <asp:Label ID="lblDescriptionModify" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Panel ID="pnlEquipmentMuscle" runat="server">
                                    <h5>
                                        Muscle Groups</h5>
                                    <br />
                                    <asp:Label ID="lblMuscleGroupsModify" runat="server" Text=""></asp:Label>
                                    <br />
                                    <h5>
                                        Equipment</h5>
                                    <br />
                                    <asp:Label ID="lblEquipmentModify" runat="server" Text=""></asp:Label>
                                </asp:Panel>
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            Change item to:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlModifyItems" runat="server" DataTextField="name" DataValueField="id"
                                                Visible="False" Width="155px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Select a new time:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlHoursModify" runat="server">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                            </asp:DropDownList>
                                            :
                                            <asp:DropDownList ID="ddlMinutesModify" runat="server">
                                                <asp:ListItem Value="00"></asp:ListItem>
                                                <asp:ListItem Value="05"></asp:ListItem>
                                                <asp:ListItem Value="10"></asp:ListItem>
                                                <asp:ListItem Value="15"></asp:ListItem>
                                                <asp:ListItem Value="20"></asp:ListItem>
                                                <asp:ListItem Value="25"></asp:ListItem>
                                                <asp:ListItem Value="30"></asp:ListItem>
                                                <asp:ListItem Value="35"></asp:ListItem>
                                                <asp:ListItem Value="40"></asp:ListItem>
                                                <asp:ListItem Value="45"></asp:ListItem>
                                                <asp:ListItem Value="50"></asp:ListItem>
                                                <asp:ListItem Value="55"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlAmPmModify" runat="server">
                                                <asp:ListItem>AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Select a new date:
                                        </td>
                                        <td>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tbRemoveDate"
                                                FilterType="Custom" ValidChars='()1234567890-/'>
                                            </asp:FilteredTextBoxExtender>
                                            <asp:TextBox ID="tbDateModify" runat="server" Enabled="true" ReadOnly="False" AutoCompleteType="Disabled"
                                                AutoPostBack="True" ValidationGroup="ModifyItem" OnTextChanged="tbDateModify_textChanged"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="modifyDateValidator" runat="server" ErrorMessage="Invalid Date"
                                                ControlToValidate="tbDateModify" Font-Size="Medium" ForeColor="Red" ValidationExpression="(((0?[1-9]|1[012])[/.](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])[/.](29|30)|(0?[13578]|1[02])/31)[/.](19|[2-9]\d)\d{2}|0?2[/.]29[/.]((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))"
                                                ValidationGroup="ModifyItem" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ForeColor="Red" ID="modifyDateRequired" runat="server"
                                                ErrorMessage="*" ControlToValidate="tbDateModify" ValidationGroup="ModifyItem"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:CalendarExtender ID="calendarModify" runat="server" TargetControlID="tbDateModify">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <br />
                            <asp:Button ID="btnBackToCalendar" runat="server" Text="Back to Calendar" OnClick="goBack_Click"
                                CssClass="button" />
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="button" OnClick="btnModify_Click"
                                ValidationGroup="ModifyItem" Visible="False" />
                            <br />
                            <asp:Label ID="lblResultModify" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="loadingCalendar">
                        <h1>
                            Loading...</h1>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
