using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoS.ProductModels;
using Validator;
using PoS.PurchaseManagementModule;

namespace PoS.LocalValidator
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
                Console.Write("Enter Product Category\n\n");
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
;                    productCategory = "STORAGE";
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
                        PoSInventoryRepository.CPUInventory.ListAllCPU();
                        Console.Write("Enter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.CPUInventory.IsCPURegistered(inputName));
                    break;
                case "GPU":
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.GPUInventory.ListAllGPU();
                        Console.Write("Enter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.GPUInventory.IsGPURegistered(inputName));
                    break;
                case "MOBO":
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.MOBOInventory.ListAllMOBO();
                        Console.Write("Enter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.MOBOInventory.IsMOBORegistered(inputName));
                    break;
                case "RAM":
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.RAMInventory.ListAllRAM();
                        Console.Write("Enter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                    } while (!PoSInventoryRepository.RAMInventory.IsRAMRegistered(inputName));
                    break;
                case "STORAGE":
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.STORAGEInventory.ListAllSTORAGE();
                        Console.Write("Enter Product Name\n\n");
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
            bool ValidName;
            do
            {
                Console.Clear();
                PoSInventoryRepository.ShowAllProducts();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Product Name\n\n" +
                    "> ");
                inputName = Console.ReadLine();

                ValidName = PoSInventoryRepository.DoesProductExist(inputName);
                if (ValidName)
                {
                    MessageBox.Show($"{inputName} already exists! Please enter a product that does not exist yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            } while (ValidName);

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
            //bool ValidStock
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
            bool ValidAddendInput = false;
            do
            {
                Console.Write("Increase Stock\n\n" +
                    "Increase Stock by\n\n" +
                    ">  ");
                inputAddend = Console.ReadLine();

                ValidAddendInput = !BasicDataInput.IsValidPositivieInteger(inputAddend);
                if (ValidAddendInput)
                {
                    MessageBox.Show($"{inputAddend} is not a valid input! Please enter a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            } while (ValidAddendInput);
            uint addend = uint.Parse(inputAddend);
            return addend;
        }
    }
    public class CartInput
    {
        
        public bool GetFlag(CustomerCart customerCart)
        {
            Console.Clear();
            string inputFlag;
            do
            {
                Console.Write("Finalize Cart?\n\n");
                Console.Write(
                    "\t1. Yes\n" +
                    "\t2. No\n\n" +
                    "> ");
                inputFlag = Console.ReadLine();
            } while (!(inputFlag == "1" || inputFlag == "2"));
            
            if(inputFlag == "1")
            {
                return true;
            }
            return false;
        }
        public string GetProductName(string productCategory, PoSInventory PoSInventoryRepository)
        {
            string inputName = "";


            switch (productCategory)
            {
                case "CPU":

                    bool ValidCPUInput = false;
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.CPUInventory.ListDetailedInformation();
                        Console.Write("\n\nEnter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                        ValidCPUInput = !PoSInventoryRepository.CPUInventory.IsCPURegistered(inputName);

                        if (ValidCPUInput)
                        {
                            MessageBox.Show($"{inputName} is not registered! Please enter a registered CPU.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    } while (ValidCPUInput);
                    break;

                case "GPU":

                    bool ValidGPUInput = false;
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.GPUInventory.ListDetailedInformation();
                        Console.Write("\n\nEnter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                        ValidGPUInput = !PoSInventoryRepository.GPUInventory.IsGPURegistered(inputName) && !ValidGPUInput;
                        if (ValidGPUInput)
                        {
                            MessageBox.Show($"{inputName} is not registered! Please enter a registered GPU.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    } while (ValidGPUInput) ;
                    break;

                case "MOBO":

                    bool ValidMOBOInput = false;
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.MOBOInventory.ListDetailedInformation();
                        Console.Write("\n\nEnter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                        ValidMOBOInput = !PoSInventoryRepository.MOBOInventory.IsMOBORegistered(inputName) && !ValidMOBOInput;
                        if (ValidMOBOInput)
                        {
                            MessageBox.Show($"{inputName} is not registered! Please enter a registered motherboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    } while (ValidMOBOInput);
                    break;

                case "RAM":

                    bool ValidRAMInput = false;
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.RAMInventory.ListDetailedInformation();
                        Console.Write("\n\nEnter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                        ValidRAMInput = !PoSInventoryRepository.RAMInventory.IsRAMRegistered(inputName) && !ValidRAMInput;
                        if (ValidRAMInput)
                        {
                            MessageBox.Show($"{inputName} is not registered! Please enter a registered RAM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    } while (ValidRAMInput);
                    break;

                case "STORAGE":

                    bool ValidSTORAGEInput = false;
                    do
                    {
                        Console.Clear();
                        PoSInventoryRepository.STORAGEInventory.ListDetailedInformation();
                        Console.Write("\n\nEnter Product Name\n\n");
                        Console.Write("Product Name\n\n" +
                            "> ");
                        inputName = Console.ReadLine();

                        ValidSTORAGEInput = !PoSInventoryRepository.STORAGEInventory.IsSTORAGERegistered(inputName) && !ValidSTORAGEInput;
                        if (ValidSTORAGEInput)
                        {
                            MessageBox.Show($"{inputName} is not registered! Please enter a registered storage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    } while (ValidSTORAGEInput);
                    break;
            }

            string productName = inputName;
            Console.Clear();
            return productName;
        }
    }
}
