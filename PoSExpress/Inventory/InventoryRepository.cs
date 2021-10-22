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
        public void AddCPU(CPU myCPU) 
        {
            string cpuInventoryFile = ".\\repo\\cpu_inventory.txt";
            string cpuProperties = myCPU.Serialize();                               // Convert CPU object properties to string

            using(StreamWriter sw = File.AppendText(cpuInventoryFile))          
            {
                sw.WriteLine(cpuProperties);                                        // Write properties to string
            }
        }

        public CPU GetCPU(string productName)
        {
            string cpuInventoryFile = ".\\repo\\cpu_inventory.txt";
            string[] cpuList = File.ReadAllLines(cpuInventoryFile);

            foreach (string cpu in cpuList)
            {
                string cpuProductName = cpu.Split('|')[0];                          // Get productName

                if(productName == cpuProductName)
                {
                    return CPU.Deserialize(cpu);                                    // Return CPU Object
                }
            }
            return null;
        }

        public List<CPU> CPUCatalogue()
        {
            string cpuInventoryFile = ".\\repo\\cpu_inventory.txt";
            string[] cpuList = File.ReadAllLines(cpuInventoryFile);
            List<CPU> CPUCatalogue = new List<CPU>();                               // Instantiate list of cpus
            foreach (string cpu in cpuList)
            {
                CPUCatalogue.Add(CPU.Deserialize(cpu));                             // Instantiate cpu from text per line and add to list
            }
            return null;
        }
        
        
        public void IncreaseStock(string category,string productName, int inc) 
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

            foreach (string product in productList)
            {
                
                string productNameToUpdate = product.Split('|')[0];                                         // Get productName
                
                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock
                    
                    productToUpdate[3] = (inc + int.Parse(productToUpdate[3])).ToString();                  // Increase the stock by inc

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(productList);                                                        // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

        public void DecreaseStock(string category, string productName, int dec) 
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

            foreach (string product in productList)
            {

                string productNameToUpdate = product.Split('|')[0];                                         // Get productName

                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock

                    productToUpdate[3] = (int.Parse(productToUpdate[3]) - dec).ToString();                  // Decrease the stock by dec

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(productList);                                                        // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

        public void ChangePrice(string category, string productName, int newPrice)
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

            foreach (string product in productList)
            {

                string productNameToUpdate = product.Split('|')[0];                                         // Get productName

                if (productName == productNameToUpdate)                                                     // If productName input matched, initialize changing of stock
                {
                    string[] productToUpdate = product.Split('|');                                          // Split to update stock

                    productToUpdate[2] = newPrice.ToString();                                               // Increase the stock by inc

                    string updatedProductStock = String.Join("|", productToUpdate);                         // Revert list of the product you want to change back to a string
                    productList[index] = updatedProductStock;                                               // Replace old product details with new product details with increased stock
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(productList);                                                        // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

    }
}
