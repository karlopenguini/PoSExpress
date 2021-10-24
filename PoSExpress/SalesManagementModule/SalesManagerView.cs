using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PoS.SalesManagementModule
{
    public class SalesManagerView
    {
        // path for receipts = .\receipts\text files here
        // path to generate reports = .\reports
        // REWRITE REPORTS DONT CREATE NEW REPORTS

        // FORMAT OF EACH RECEIPT
        // per line = productName|brand|price

        // QPR_Report.txt = quantity per product
        // SPR_Report.txt = sales per product
        // TSR_Report.txt = total sales

        
        public SalesManagerView()
        {
            string receiptDirectoryPath = @".\reports";

            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(receiptDirectoryPath))
                {
                    DirectoryInfo repoDirectory = Directory.CreateDirectory(receiptDirectoryPath);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        public void SalesManager(PoSInventory PoSInventoryRepository)
        {
            bool ProgramLooping = true;
            string input;
            while (ProgramLooping)
            {
                ShowMainMenu();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        QuantityPerProductReporter InitQuantityPerProductReport = new QuantityPerProductReporter();
                        break;
                    case "2":
                        SalesPerProductReporter InitSalesPerProductReporter = new SalesPerProductReporter();
                        break;
                    case "3":
                        TotalSalesReporter InitTotalSalesReporter = new TotalSalesReporter();
                        break;
                    case "4":
                        ProgramLooping = false;
                        break;
                    
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.Write(
                "Sales Manager\n\n" +
                    "\t1. Generate Quantity per Product Report\n" +
                    "\t2. Generate Sales per Product Report\n" +
                    "\t3. Generate Total Sales Report\n" +
                    "\t4. Back\n\n" +
                    "> ");
        }
    }
}
