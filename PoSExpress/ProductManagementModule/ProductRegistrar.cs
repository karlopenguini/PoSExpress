using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Inventory;
using PoS.ProductModels;
using Validator;

namespace PoS.ProductManagementModule
{
    public class ProductRegistrar
    {
        public ProductRegistrar(Dictionary<string, InventoryRepository> Inventory)
        {

            string inputCategory;
            string productCategory = "";
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Product Category\n\n" +
                    "\t1. CPU\n" +
                    "\t2. GPU\n" +
                    "\t3. MOTHERBOARD\n" +
                    "\t4. RAM\n" +
                    "\t5. STORAGE\n\n" +
                    "> ");
                inputCategory = Console.ReadLine();
            } while (ProductInformationValidator.IsValidCategory(inputCategory));
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
           
            string inputName;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Product Name\n\n" +
                    "> ");
                inputName = Console.ReadLine();
            } while (ProductInformationValidator.IsValidProductName(inputName));
            string productName = inputName;
            Console.Clear();
           
            string inputBrand;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Brand\n\n" +
                    "> ");
                inputBrand = Console.ReadLine();
            } while (ProductInformationValidator.IsValidBrand(inputBrand));
            string brand = inputBrand;
            Console.Clear();
           
            string inputPrice;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Price\n\n" +
                    "> ");
                inputPrice = Console.ReadLine();
            } while (ProductInformationValidator.IsValidPrice(inputPrice));
            decimal price = decimal.Parse(inputPrice);
            Console.Clear();
            
            string inputStock;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Stock\n\n" +
                    "> ");
                inputStock = Console.ReadLine();
            } while (ProductInformationValidator.IsValidStock(inputStock));
            uint stock = uint.Parse(inputStock);
            Console.Clear();
           
            switch (productCategory)
            {
                case "CPU":
                    CPURegistrar CPURegistration = new CPURegistrar();

                    byte cpuCoreCount = CPURegistration.GetCPUCoreCount();
                    string cpuSocket = CPURegistration.GetCPUSocket();
                    bool cpuCooler = CPURegistration.GetCPUCooler();

                    CPU newCPU = new CPU(productName, brand, price, stock, cpuCoreCount, cpuSocket, cpuCooler);

                    Inventory["CPU"].AddCPU(newCPU);
                    break;
            }
        }

    }
    internal class CPURegistrar
    {
        public byte GetCPUCoreCount()
        {
            string inputCoreCount;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("Core Count\n\n" +
                    "> ");
                inputCoreCount = Console.ReadLine();
            } while (CPUProductInformationValidator.IsValidCPUCoreCount(inputCoreCount));
            byte cpuCoreCount = byte.Parse(inputCoreCount);
            Console.Clear();
            return cpuCoreCount;
            
        }
        public string GetCPUSocket()
        {
            string inputSocket;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "> ");
                inputSocket = Console.ReadLine();
            } while (CPUProductInformationValidator.IsValidCPUCoreCount(inputSocket));
            string cpuSocket = inputSocket;
            Console.Clear();
            return cpuSocket;
        }

        public bool GetCPUCooler()
        {
            string inputCooler;
            bool cpuCooler = false;
            do
            {
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "1. With CPU Cooler\n" +
                    "2. No CPU Cooler\n\n" +
                    "> ");
                inputCooler = Console.ReadLine();
            } while (CPUProductInformationValidator.IsValidCPUCooler(inputCooler));
            switch (inputCooler)
            {
                case "1":
                    cpuCooler = true;
                    break;
                case "2":
                    cpuCooler = false;
                    break;
            }
            Console.Clear();
            return cpuCooler;
        }
    }
}
