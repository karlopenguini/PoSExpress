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
                    

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
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

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
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

                    string UPDATED_TEXT_FILE_CONTENT = String.Join("\n", productList);
                    using (StreamWriter reWriter = new StreamWriter(path, false))
                    {
                        reWriter.Write(UPDATED_TEXT_FILE_CONTENT);                                          // Rewrite the whole text file
                    }
                }

                index++;                                                                                    // To know which index of the lines we are going to update
            }
        }

        public bool IsProductRegistered(List<ProductModel> listOfProducts, string productName)
        {
            List<string> productNames = new List<string>();

            foreach(ProductModel model in listOfProducts) { productNames.Add(model.productName); }
            if (productNames.Contains(productName)) { return true; }
            return false;
        }

        public virtual void AddCPU(CPU myCPU) { }
        public virtual CPU GetCPU(string productName) { return null; }
        public virtual void UpdateCPUInventory() { }

        public override virtual void AddGPU(GPU myGPU) { }
        public override virtual GPU GetGPU(string productName) { return null; }
        public override virtual List<GPU> UpdateGPUInventory() { return null; }

        public virtual void AddMOBO(MOBO myMOBO) { }
        public virtual MOBO GetMOBO(string productName) { return null; }
        public virtual List<MOBO> UpdateMOBOInventory() { return null; }

        public virtual void AddRAM(RAM myRAM) { }
        public virtual RAM GetRAM(string productName) { return null; }
        public virtual List<RAM> UpdateRAMInventory() { return null; }

        public virtual void AddSTORAGE(STORAGE mySTORAGE) { }
        public virtual STORAGE GetSTORAGE(string productName) { return null; }
        public virtual List<STORAGE> UpdateSTORAGEInventory() { return null; }


    }

    public class CPUInventoryRepository : InventoryRepository
    {
        public CPUInventoryRepository()
        {
            UpdateCPUInventory();
        }
        
        private List<CPU> _CPUInventory;
        public List<CPU> CPUInventory
        {
            get { return _CPUInventory; }
            set { _CPUInventory = value; }
        }
        
        
        public override void AddCPU(CPU myCPU)
        {
            string cpuInventoryFile = @".\repo\cpu_inventory.txt";
            string cpuProperties = myCPU.Serialize();                               // Convert CPU object properties to string

            using (StreamWriter sw = File.AppendText(cpuInventoryFile))
            {
                sw.WriteLine(cpuProperties);                                        // Write properties to string
            }
            
        }
        public override CPU GetCPU(string productName)
        {
            foreach (CPU cpu in CPUInventory)
            {
                if (productName == cpu.productName)
                {
                    return cpu;                                                     // Return CPU Object
                }
            }
            return null;
        }
        public override void UpdateCPUInventory()
        {
            string path = @".\repo\cpu_inventory.txt";
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    FileStream fs = File.Create(@".\repo\cpu_inventory.txt");
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string cpuInventoryFile = @".\repo\cpu_inventory.txt";
            string[] cpuList = File.ReadAllLines(cpuInventoryFile);
            List<CPU> CPUCatalogue = new List<CPU>();                               // Instantiate list of cpus
            foreach (string cpu in cpuList)
            {
                CPUCatalogue.Add(CPU.Deserialize(cpu));                             // Instantiate cpu from text per line and add to list
            }
            CPUInventory = CPUCatalogue;
        }
    }

    public class GPUInventoryRepository : InventoryRepository
    {
        public GPUInventoryRepository()
        {
            GPUInventory = UpdateGPUInventory();
        }

        private List<GPU> _GPUInventory;
        public List<GPU> GPUInventory
        {
            get { return _GPUInventory; }
            set { _GPUInventory = value; }
        }
        public override void AddGPU(GPU myGPU)
        {
            string gpuInventoryFile = @".\repo\gpu_inventory.txt";
            string gpuProperties = myGPU.Serialize();

            using (StreamWriter sw = File.AppendText(gpuInventoryFile))
            {
                sw.WriteLine(gpuProperties);
            }

        }
        public override GPU GetGPU(string productName)
        {
            foreach (GPU gpu in GPUInventory)
            {
                if (productName == gpu.productName)
                {
                    return gpu;
                }
            }
            return null;
        }
        public override List<GPU> UpdateGPUInventory()
        {
            string path = @".\repo\gpu_inventory.txt";
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    FileStream fs = File.Create(@".\repo\gpu_inventory.txt");
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string gpuInventoryFile = @".\repo\gpu_inventory.txt";
            string[] gpuList = File.ReadAllLines(gpuInventoryFile);
            List<GPU> GPUCatalogue = new List<GPU>();
            foreach (string gpu in gpuList)
            {
                GPUCatalogue.Add(GPU.Deserialize(gpu));
            }
            return GPUCatalogue;
        }
    }

    public class MOBOInventoryRepository : InventoryRepository
    {
        public MOBOInventoryRepository()
        {
            MOBOInventory = UpdateMOBOInventory();
        }

        private List<MOBO> _MOBOInventory;
        public List<MOBO> MOBOInventory
        {
            get { return _MOBOInventory; }
            set { _MOBOInventory = value; }
        }
        public  override void AddMOBO(MOBO myMOBO)
        {
            string moboInventoryFile = @".\repo\mobo_inventory.txt";
            string moboProperties = myMOBO.Serialize();

            using (StreamWriter sw = File.AppendText(moboInventoryFile))
            {
                sw.WriteLine(moboProperties);
            }

        }
        public override MOBO GetMOBO(string productName)
        {
            foreach (MOBO mobo in MOBOInventory)
            {
                if (productName == mobo.productName)
                {
                    return mobo;
                }
            }
            return null;
        }
        public override List<MOBO> UpdateMOBOInventory()
        {
            string path = @".\repo\mobo_inventory.txt";
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    FileStream fs = File.Create(@".\repo\mobo_inventory.txt");
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string moboInventoryFile = @".\repo\mobo_inventory.txt";
            string[] moboList = File.ReadAllLines(moboInventoryFile);
            List<MOBO> MOBOCatalogue = new List<MOBO>();
            foreach (string mobo in moboList)
            {
                MOBOCatalogue.Add(MOBO.Deserialize(mobo));
            }
            return MOBOCatalogue;
        }
    }

    public class RAMInventoryRepository : InventoryRepository
    {
        public RAMInventoryRepository()
        {
            RAMInventory = UpdateRAMInventory();
        }

        private List<RAM> _RAMInventory;
        public List<RAM> RAMInventory
        {
            get { return _RAMInventory; }
            set { _RAMInventory = value; }
        }
        public override void AddRAM(RAM myRAM)
        {
            string ramInventoryFile = @".\repo\ram_inventory.txt";
            string ramProperties = myRAM.Serialize();

            using (StreamWriter sw = File.AppendText(ramInventoryFile))
            {
                sw.WriteLine(ramProperties);
            }

        }
        public override RAM GetRAM(string productName)
        {
            foreach (RAM ram in RAMInventory)
            {
                if (productName == ram.productName)
                {
                    return ram;
                }
            }
            return null;
        }
        public override List<RAM> UpdateRAMInventory()
        {
            string path = @".\repo\ram_inventory.txt";
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    FileStream fs = File.Create(@".\repo\ram_inventory.txt");
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string ramInventoryFile = @".\repo\ram_inventory.txt";
            string[] ramList = File.ReadAllLines(ramInventoryFile);
            List<RAM> RAMCatalogue = new List<RAM>();
            foreach (string ram in ramList)
            {
                RAMCatalogue.Add(RAM.Deserialize(ram));
            }
            return RAMCatalogue;
        }
    }

    public class STORAGEInventoryRepository : InventoryRepository
    {
        public STORAGEInventoryRepository()
        {
            STORAGEInventory = UpdateSTORAGEInventory();
        }

        private List<STORAGE> _STORAGEInventory;
        public List<STORAGE> STORAGEInventory
        {
            get { return _STORAGEInventory; }
            set { _STORAGEInventory = value; }
        }
        public override void AddSTORAGE(STORAGE mySTORAGE)
        {
            string storageInventoryFile = @".\repo\storage_inventory.txt";
            string storageProperties = mySTORAGE.Serialize();

            using (StreamWriter sw = File.AppendText(storageInventoryFile))
            {
                sw.WriteLine(storageProperties);
            }

        }
        public override STORAGE GetSTORAGE(string productName)
        {
            foreach (STORAGE storage in STORAGEInventory)
            {
                if (productName == storage.productName)
                {
                    return storage;
                }
            }
            return null;
        }
        public override List<STORAGE> UpdateSTORAGEInventory()
        {
            string path = @".\repo\storage_inventory.txt";
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    FileStream fs = File.Create(@".\repo\storage_inventory.txt");
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string storageInventoryFile = @".\repo\storage_inventory.txt";
            string[] storageList = File.ReadAllLines(storageInventoryFile);
            List<STORAGE> STORAGECatalogue = new List<STORAGE>();
            foreach (string storage in storageList)
            {
                STORAGECatalogue.Add(STORAGE.Deserialize(storage));
            }
            return STORAGECatalogue;
        }
    }
}
