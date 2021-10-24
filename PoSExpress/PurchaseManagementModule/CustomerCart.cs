using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoS.ProductModels;

namespace PoS.PurchaseManagementModule
{
    public class CustomerCart
    {
        public CustomerCart()
        {
            string receiptDirectoryPath = @".\receipts";

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

            Cart = new List<List<string>>();
        }
        public string GenerateReceipt()
        {
            string receipt = "";
            string ReceiptTXT = "";

            decimal total = 0;
            foreach(List<string> productLine in Cart)
            {
                total += decimal.Parse(productLine[3]);
                receipt += string.Format("{0, -30}{1, -30}{2, -30}{3, -30}\n",productLine[0],productLine[1],productLine[2],productLine[3]);
                ReceiptTXT += $"{productLine[0]}|{productLine[1]}|{productLine[2]}|{productLine[3]}\n";
            }
            receipt+=$"\n\n{Math.Round(total)}\n\n";
            ReceiptTXT += $"{Math.Round(total)}";
            Console.Write(receipt);
            return ReceiptTXT;
        }

        public void WriteReceipt(string data)
        {
            var fileName = $@"{Guid.NewGuid()}.txt";
            File.WriteAllText($@".\receipts\{fileName}", data);
        }
        public List<List<string>> Cart { get; set; }

        public void AddToCart(string productCategory, string productName, PoSInventory PoSInventoryRepository)
        {

            PoSInventoryRepository.STOREInventory.DecreaseStock(productCategory, productName, 1);
            PoSInventoryRepository.UpdateInventory(productCategory);

            Cart.Add(PoSInventoryRepository.GetProductInformation(productCategory, productName));
        }
    }
}
