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
        public ProductRegistrar(PoSInventory PoSInventoryRepository)
        {
            RegistrarInput RegistrarEncoder = new RegistrarInput();
            string productCategory =    GeneralInput.GetProductCategory();
            string productName =        RegistrarEncoder.GetNewProductName(PoSInventoryRepository);
            string brand =              RegistrarEncoder.GetBrand();
            decimal price =             RegistrarEncoder.GetPrice();
            uint stock =                RegistrarEncoder.GetStock();
           
            switch (productCategory)
            {
                case "CPU":
                    CPURegistrar CPUEncoder = new CPURegistrar();

                    byte cpuCoreCount = CPUEncoder.GetCPUCoreCount();
                    string cpuSocket =  CPUEncoder.GetCPUSocket();
                    bool cpuCooler =    CPUEncoder.GetCPUCooler();

                    CPU newCPU = new CPU(productName, brand, price, stock, cpuCoreCount, cpuSocket, cpuCooler);
                    PoSInventoryRepository.CPUInventory.AddCPU(newCPU);
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
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Core Count\n\n" +
                    "> ");
                inputCoreCount = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUCoreCount(inputCoreCount));
            byte cpuCoreCount = byte.Parse(inputCoreCount);
            Console.Clear();
            return cpuCoreCount;
            
        }
        public string GetCPUSocket()
        {
            string inputSocket;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "> ");
                inputSocket = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUSocket(inputSocket));
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
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "1. With CPU Cooler\n" +
                    "2. No CPU Cooler\n\n" +
                    "> ");
                inputCooler = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUCooler(inputCooler));
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
