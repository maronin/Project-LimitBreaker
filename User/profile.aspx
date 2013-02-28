<%@ Page Title="" Language="C#" MasterPageFile="~/ui/mp/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="User_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1
        {
            height: 30px;
        }
    </style>
    <%-- Chart and functionality is free curtousy of http://www.amcharts.com/ --%>
    <link rel="stylesheet" href="../ui/css/chartStyle.css" type="text/css" />
    <script src="../Scripts/amcharts.js" type="text/javascript"></script>
    <script type="text/javascript">
        var chart;
        var chartData = [];
        var chartCursor;

        AmCharts.ready(function () {
            // generate some data first
            generateChartData();

            // SERIAL CHART    
            chart = new AmCharts.AmSerialChart();
            chart.pathToImages = "../ui/images/";
            chart.zoomOutButton = {
                backgroundColor: '#000000',
                backgroundAlpha: 0.15
            };
            chart.dataProvider = chartData;
            chart.categoryField = "date";
            chart.balloon.bulletSize = 5;

            // listen for "dataUpdated" event (fired when chart is rendered) and call zoomChart method when it happens
            chart.addListener("dataUpdated", zoomChart);

            // AXES
            // category
            var categoryAxis = chart.categoryAxis;
            categoryAxis.parseDates = true; // as our data is date-based, we set parseDates to true
            categoryAxis.minPeriod = "DD"; // our data is daily, so we set minPeriod to DD
            categoryAxis.dashLength = 1;
            categoryAxis.gridAlpha = 0.15;
            categoryAxis.position = "top";
            categoryAxis.axisColor = "#DADADA";

            // value                
            var valueAxis = new AmCharts.ValueAxis();
            valueAxis.axisAlpha = 0;
            valueAxis.dashLength = 1;
            chart.addValueAxis(valueAxis);

            // GRAPH
            var graph = new AmCharts.AmGraph();
            graph.title = "red line";
            graph.valueField = "visits";
            graph.bullet = "round";
            graph.bulletBorderColor = "#FFFFFF";
            graph.bulletBorderThickness = 2;
            graph.lineThickness = 2;
            graph.lineColor = "#5fb503";
            graph.negativeLineColor = "#efcc26";
            graph.hideBulletsCount = 50; // this makes the chart to hide bullets when there are more than 50 series in selection
            chart.addGraph(graph);

            // CURSOR
            chartCursor = new AmCharts.ChartCursor();
            chartCursor.cursorPosition = "mouse";
            chartCursor.pan = true; // set it to fals if you want the cursor to work in "select" mode
            chart.addChartCursor(chartCursor);

            // SCROLLBAR
            var chartScrollbar = new AmCharts.ChartScrollbar();
            chart.addChartScrollbar(chartScrollbar);

            // WRITE
            chart.write("chartdiv");
        });

        // generate some random data, quite different range
        function generateChartData() {
            var firstDate = new Date();
            firstDate.setDate(firstDate.getDate() - 500);

            for (var i = 0; i < 365; i++) {
                var newDate = new Date(firstDate);
                newDate.setDate(newDate.getDate() + i);

                var visits = Math.round(Math.random() * 140) + 23;

                chartData.push({
                    date: newDate,
                    visits: visits
                });
            }
        }

        // this method is called when chart is first inited as we listen for "dataUpdated" event
        function zoomChart() {
            // different zoom methods can be used - zoomToIndexes, zoomToDates, zoomToCategoryValues
            chart.zoomToIndexes(chartData.length - 40, chartData.length - 1);
        }

        // changes cursor mode from pan to select
        function setPanSelect() {
            if (document.getElementById("rb1").checked) {
                chartCursor.pan = false;
                chartCursor.zoomable = true;
            } else {
                chartCursor.pan = true;
            }
            chart.validateNow();
        }   
			            
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     
    <h1>Welcome LimitBreaker</h1>

    <div style="text-align:center; float:left;">
            <h2><asp:Label ID="alias" runat="server"></asp:Label>'s User Profile</h2>
            <asp:Label ID="levelLbl" runat="server" Text=""></asp:Label>
        <br />
        <br />
            <meter runat="server" id="expBar" style="width:275px; height:19px;" min="0"></meter>
        <br />
        <br />
            <asp:Label ID="currentExpLbl" runat="server" Text=""></asp:Label>
            <asp:Label ID="reqExpLbl" runat="server" Text=""></asp:Label>
        <br />
        <br />

        <div style="text-align:left;">
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
    </div>

    <div style="width: 50%; margin-left:250px; float:left; text-align:center;"><h2>Weight Tracking</h2></div>
    
    <div id="chartdiv" style="width: 50%; height: 400px; margin-left:250px; float:left;"></div>

    <div style="width: 50%; margin-left:250px; float:left; text-align:center;">
        <input type="radio" name="group" id="rb1" onclick="setPanSelect()">Select
        <input type="radio" checked="true" name="group" id="rb2" onclick="setPanSelect()">Pan
    </div> 

    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

