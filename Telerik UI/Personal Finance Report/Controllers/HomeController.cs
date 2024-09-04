using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PersonalFinanceReport.Models;
using Telerik.Web.Mvc.UI;
using Telerik.Web.Mvc.Extensions;

namespace PersonalFinanceReport.Controllers
{
    public class HomeController : Controller
    {
        // Display form for entering financial data
        public ActionResult Index()
        {
            return View(new FinanceModel());
        }

        // Handle form submission and generate the report
        [HttpPost]
        public ActionResult GenerateReport(FinanceModel model)
        {
            if (ModelState.IsValid)
            {
                var netWorth = model.Assets - model.Liabilities;
                var financialHealth = GetFinancialHealth(model.Salary, netWorth);

                // Store the values to pass to the view
                ViewBag.NetWorth = netWorth;
                ViewBag.FinancialHealth = financialHealth;

                // Prepare the data for the Telerik Grid and Chart
                var financeData = new List<FinanceReport>
                {
                    new FinanceReport { Category = "Salary", Value = model.Salary },
                    new FinanceReport { Category = "Assets", Value = model.Assets },
                    new FinanceReport { Category = "Liabilities", Value = model.Liabilities },
                    new FinanceReport { Category = "Net Worth", Value = netWorth }
                };

                return View("Report", financeData);
            }

            return View("Index", model);
        }

        // Helper method to determine financial health
        private string GetFinancialHealth(decimal salary, decimal netWorth)
        {
            if (netWorth > salary * 5)
            {
                return "Excellent";
            }
            else if (netWorth > salary * 2)
            {
                return "Good";
            }
            else
            {
                return "Needs Improvement";
            }
        }
    }

    // Class to hold report data for the Telerik Grid and Chart
    public class FinanceReport
    {
        public string Category { get; set; }
        public decimal Value { get; set; }
    }

    
    /*
    public ActionResult _ChartBinding()
    {
        // Sample data to bind to the Telerik Chart
        var financeData = new List<FinanceReport>
        {
            new FinanceReport { Category = "Salary", Value = 50000 },
            new FinanceReport { Category = "Assets", Value = 200000 },
            new FinanceReport { Category = "Liabilities", Value = 50000 },
            new FinanceReport { Category = "Net Worth", Value = 150000 }
        };

        return Json(financeData, JsonRequestBehavior.AllowGet);
    }
    */
}

