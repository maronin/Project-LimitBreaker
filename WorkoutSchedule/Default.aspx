<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WorkoutSchedule_Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <h1>Schedule Calendar</h1>
        <asp:Literal runat="server" ID="ltl_output" />
        <asp:Panel ID="pnl_calendar" runat="server" CssClass="calendar">
            <asp:Panel ID="pnl_monthSelector" runat="server" CssClass="calendarMonthSelector">
                <asp:DropDownList ID="ddl_month" runat="server" />
                <asp:DropDownList ID="ddl_year" runat="server" />
                <asp:LinkButton ID="lnk_loadCalendar" runat="server" Text="Go" 
                    onclick="lnk_loadCalendar_Click" />
            </asp:Panel>
            <asp:Repeater ID="rpt_calendar" runat="server" 
                onitemdatabound="rpt_calendar_ItemDataBound">

                <ItemTemplate>
                    <asp:Panel ID="pnl_calendarDay" runat="server" CssClass="calendarDay" ScrollBars="Auto" >
                        <asp:LinkButton ID="lnk_dayLink" runat="server" />
                        <asp:Literal ID="ltl_dayEvents" runat="server" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>

            <div style="clear:both; height:0; overflow:hidden">&nbsp;</div> <!-- This is needed to force the container (inc. background) around all the days if Days are floated with CSS -->
        </asp:Panel>

</asp:Content>

