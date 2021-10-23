using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.ProductModels;
using System.IO;

namespace PoS.Inventory
{
    public class InventoryRepository
    {
        public InventoryRepository()
        {
            string repoDirectoryPath = @".\repo";

            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(repoDirectoryPath))
                {
                    DirectoryInfo repoDirectory = Directory.CreateDirectory(repoDirectoryPath);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
      
        public void IncreaseStock(string category,string productName, uint inc) 
        {
            string path = "";
            switch (category)                                                                               // Gets the path for the chosen category of the product you want to change the stock.
            {
                case "CPU":
                    path = ".\\repo\\cpu_inventory.txt";
                    break;
                case "GPU":
                    path = ".\\repo\\gpu_inventory.txt";
                    break;
                case "MOBO":
                    path = ".\\repo\\mobo_inventory.txt";
                    break;
                case "RAM":
                    path = ".\\repo\\ram_inventory.txt";
                    break;
                case "STORAGE":
                    path = ".\\repo\\storage_inventory.txt";
                    break;
            }

            List<string> productList = File.ReadAllLines(path).ToList();
            int index = 0;

            foreach (string product in productList.ToList())
            {
                
                string productNameToUpdate = product.Split('|')[0];                                         // Get productName
                
                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock
                    
                    productToUpdate[3] = (inc + int.Parse(productToUpdate[3])).ToString();                  // Increase the stock by inc

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock
                    

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

        public void DecreaseStock(string category, string productName, uint dec) 
        {
            string path = "";
            switch (category)                                                                               // Gets the path for the chosen category of the product you want to change the stock.
            {
                case "CPU":
                    path = ".\\repo\\cpu_inventory.txt";
                    break;
                case "GPU":
                    path = ".\\repo\\gpu_inventory.txt";
                    break;
                case "MOBO":
                    path = ".\\repo\\mobo_inventory.txt";
                    break;
                case "RAM":
                    path = ".\\repo\\ram_inventory.txt";
                    break;
                case "STORAGE":
                    path = ".\\repo\\storage_inventory.txt";
                    break;
            }

            List<string> productList = File.ReadAllLines(path).ToList();
            int index = 0;

            foreach (string product in productList.ToList())
            {

                string productNameToUpdate = product.Split('|')[0];                                         // Get productName

                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock

                    productToUpdate[3] = (int.Parse(productToUpdate[3]) - dec).ToString();                  // Decrease the stock by dec

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

        public void ChangePrice(string category, string productName, decimal newPrice)
        {
            string path = "";
            switch (category)                                                                               // Gets the path for the chosen category of the product you want to change the stock.
            {
                case "CPU":
                    path = ".\\repo\\cpu_inventory.txt";
                    break;
                case "GPU":
                    path = ".\\repo\\gpu_inventory.txt";
                    break;
                case "MOBO":
                    path = ".\\repo\\mobo_inventory.txt";
                    break;
                case "RAM":
                    path = ".\\repo\\ram_inventory.txt";
                    break;
                case "STORAGE":
                    path = ".\\repo\\storage_inventory.txt";
                    break;
            }

            List<string> productList = File.ReadAllLines(path).ToList();
            int index = 0;

            foreach (string product in productList.ToList())
            {
                
                string productNameToUpdate = product.Split('|')[0];                                         // Get productName

                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock

                    productToUpdate[2] = newPrice.ToString();                                               // Increase the stock by inc

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

    }

}
