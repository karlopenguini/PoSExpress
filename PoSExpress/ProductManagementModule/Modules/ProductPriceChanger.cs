using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator;
using PoS.ProductModels;
using PoS.Inventory;

namespace PoS.ProductManagementModule
{
    public class ProductPriceChanger
    {
        public ProductPriceChanger(PoSInventory PoSInventoryRepository)
        {
            string productCategory = GetProductCategory();
            string productName = GetProductName(productCategory, PoSInventoryRepository);
        }
        public string GetProductCategory()
        {
            Console.Clear();
            string inputCategory;
            string productCategory = "";
            do
            {
                Console.Clear();
                Console.Write("Change Product Price\n\n");
                Console.Write("Product Category\n\n" +
                    "\t1. CPU\n" +
                    "\t2. GPU\n" +
                    "\t3. MOTHERBOARD\n" +
                    "\t4. RAM\n" +
                    "\t5. STORAGE\n\n" +
                    "> ");
                inputCategory = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidCategory(inputCategory));
            switch (inputCategory)
            {
                case "1":
                    productCategory = "CPU";
                    break;
                case "2":
                    productCategory = "GPU";
                    break;
                case "3":
                    productCategory = "MOTHERBOARD";
                    break;
                case "4":
                    productCategory = "RAM";
                    break;
                case "5":
                    productCategory = "STORAGE";
                    break;
            }
            Console.Clear();
            return productCategory;
        }
        public string GetProductName(string productCategory, PoSInventory PoSInventoryRepository)
        {
            string inputName;
            InventoryRepository inventory;

            switch (productCategory)
            {
                case "CPU":
                    inventory = PoSInventoryRepository.CPUInventory;
                    break;
                case "GPU":
                    inventory = PoSInventoryRepository.GPUInventory;
                    break;
                case "MOBO":
                    inventory = PoSInventoryRepository.MOBOInventory;
                    break;
                case "RAM":
                    inventory = PoSInventoryRepository.RAMInventory;
                    break;
                case "STORAGE":
                    inventory = PoSInventoryRepository.STORAGEInventory;
                    break;
            }

            do
            {
                Console.Clear();
                Console.Write("Change Product Price\n\n");
                Console.Write("Product Name\n\n" +
                    "> ");
                inputName = Console.ReadLine();

            } while ();
            string productName = inputName;
            Console.Clear();
            return productName;
        }
        public decimal GetNewPrice()
        {
            Console.Clear();
            string inputPrice;
            do
            {
                Console.Clear();
                Console.Write("Change Product Price\n\n" +
                    "New Price\n\n" +
                    ">");
                inputPrice = Console.ReadLine();

            } while (!ProductInformationValidator.IsValidPrice(inputPrice));
            decimal newPrice = decimal.Parse(inputPrice);
            Console.Clear();
            return newPrice;
        }
    }
}
