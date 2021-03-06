﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="WorkoutSchedule_Default4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #CalImage
        {
            height: 20px;
            width: 20px;
        }
        .style1
        {
            width: 38%;
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
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="multiViewCalendar" runat="server">
                        <asp:View ID="view_calendar" runat="server">
                            <asp:LinkButton ID="lnk_add_item" runat="server" Text="Add Item" OnClick="lnk_add_item_Click" />
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
                        <!------------------------------------------------------------------------------ add an item view -------------------------------------------------------------------------------------->
                        <asp:View ID="add_item" runat="server">
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
                                <!---------------------------------------------------------------------------- Schedule Exercise  --------------------------------------------------------------------------------------->
                                <asp:View ID="addExerciseView" runat="server">
                                    <h3>
                                        Schedule a new Exercise!</h3>
                                    <br />
                                    <table class="scheduleTable">
                                        <tr>
                                            <td>
                                                Step 1. Select an exercise:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dllExercises" runat="server" DataSourceID="ObjectDataSource3"
                                                    DataTextField="name" DataValueField="id">
                                                </asp:DropDownList>
                                            </td>
                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getExercises"
                                                TypeName="ExerciseManager"></asp:ObjectDataSource>
                                        </tr>
                                        <tr>
                                            <td>
                                                Step 2. Select Start Time:
                                            </td>
                                            <td>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Step 3. Select Start Date:
                                            </td>
                                            <td>
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
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Button ID="btnScheduleExercise" runat="server" Text="Schedule Exercise" OnClick="btnScheduleExercise_Click"
                                        CssClass="button" ValidationGroup="ScheduleExercise" />
                                    <br />
                                    <asp:Button ID="btnGoBack1" runat="server" Text="Back To Calendar" OnClick="goBack_Click"
                                        CssClass="button" />
                                    <asp:Label ID="lblResult_Exercise" runat="server" Text=""></asp:Label>
                                </asp:View>
                                <asp:View ID="View1" runat="server">
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
                        <asp:View ID="View3" runat="server">
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="loadingCalendar">
                        <h1>
                            Loading Calendar...</h1>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
