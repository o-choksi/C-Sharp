// Scripts/financeReport.js

$(document).ready(function () {
    // Initialize any Telerik UI components that need JavaScript initialization
    $("#FinanceReportGrid").data("tGrid").dataSource.read();  // Reload the grid if needed
    $("#FinanceChart").data("tChart").refresh();  // Refresh the chart

    // Add custom event handling if needed
    $("#generateReportButton").on("click", function () {
        console.log("Generating report...");
        // Additional JS logic for client-side validation or actions
    });
});
