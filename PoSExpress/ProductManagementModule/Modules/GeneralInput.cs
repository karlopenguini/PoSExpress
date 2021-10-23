﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.ProductModels;
using Validator;

namespace PoS.ProductManagementModule
{
    public class GeneralInput
    {
        public static string GetProductCategory()
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
                    productCategory = "MOBO";
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
        public static string GetProductName(string productCategory, PoSInventory PoSInventoryRepository)
        {
            string inputName = "";


            switch (productCategory)
            {
                case "CPU":

                    do
                    {
                        Console.Clear();
                        Console.Write("Change Product Price\n\n");
                        PoSInventoryRepository.CPUInventory.ListAllCPU();
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.CPUInventory.IsCPURegistered(inputName));

                    break;
                case "GPU":
                    do
                    {
                        Console.Clear();
                        Console.Write("Change Product Price\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.GPUInventory.IsGPURegistered(inputName));
                    break;
                case "MOBO":
                    do
                    {
                        Console.Clear();
                        Console.Write("Change Product Price\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.MOBOInventory.IsMOBORegistered(inputName));
                    break;
                case "RAM":
                    do
                    {
                        Console.Clear();
                        Console.Write("Change Product Price\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.RAMInventory.IsRAMRegistered(inputName));
                    break;
                case "STORAGE":
                    do
                    {
                        Console.Clear();
                        Console.Write("Change Product Price\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.STORAGEInventory.IsSTORAGERegistered(inputName));
                    break;
            }

            string productName = inputName;
            Console.Clear();
            return productName;
        }
    }
    public class RegistrarInput
    {
        public string GetNewProductName(PoSInventory PoSInventoryRepository)
        {
            string inputName;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Product Name\n\n" +
                    "> ");
                inputName = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidProductName(inputName) &&
            PoSInventoryRepository.CPUInventory.IsCPURegistered(inputName) &&
            PoSInventoryRepository.GPUInventory.IsGPURegistered(inputName) &&
            PoSInventoryRepository.MOBOInventory.IsMOBORegistered(inputName) &&
            PoSInventoryRepository.RAMInventory.IsRAMRegistered(inputName) &&
            PoSInventoryRepository.STORAGEInventory.IsSTORAGERegistered(inputName));

            string productName = inputName;
            Console.Clear();
            return productName;
        }
        public string GetBrand()
        {
            string inputBrand;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Brand\n\n" +
                    "> ");
                inputBrand = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidBrand(inputBrand));
            string brand = inputBrand;
            Console.Clear();
            return brand;
        }
        public decimal GetPrice()
        {
            string inputPrice;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Price\n\n" +
                    "> ");
                inputPrice = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidPrice(inputPrice));
            decimal price = decimal.Parse(inputPrice);
            Console.Clear();
            return price;
        }
        public uint GetStock()
        {
            string inputStock;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Stock\n\n" +
                    "> ");
                inputStock = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidStock(inputStock));
            uint stock = uint.Parse(inputStock);
            Console.Clear();
            return stock;
        }
    }
    public class PriceInput
    {
        public decimal GetNewPrice()
        {
            Console.Clear();
            string inputPrice;
            do
            {
                Console.Clear();
                Console.Write("Change Product Price\n\n" +
                    "New Price\n\n" +
                    "> ");
                inputPrice = Console.ReadLine();

            } while (!ProductInformationValidator.IsValidPrice(inputPrice));
            decimal newPrice = decimal.Parse(inputPrice);
            Console.Clear();
            return newPrice;
        }
    }
    public class StockInput
    {
        public uint GetSubtrahend(ProductModel product)
        {
            Console.Clear();
            string inputSubtrahend;
            uint originalStock = product.stock;
            do
            {
                Console.Write("Decrease Stock\n\n" +
                    "Decrease Stock by\n\n" +
                    "> ");
                inputSubtrahend = Console.ReadLine();
            } while (!ProductInformationValidator.IsValidStock(inputSubtrahend) && originalStock - uint.Parse(inputSubtrahend) < 0);
            uint subtrahend = uint.Parse(inputSubtrahend);
            Console.Clear();
            return subtrahend;
        }

        public uint GetAddend()
        {
            Console.Clear();
            string inputAddend;
            do
            {
                Console.Write("Increase Stock\n\n" +
                    "Increase Stock by\n\n" +
                    ">  ");
                inputAddend = Console.ReadLine();
            } while (!BasicDataInput.IsValidPositivieInteger(inputAddend));
            uint addend = uint.Parse(inputAddend);
            return addend;
        }
    }
}
