using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoS.ProductModels;
namespace PoS.Inventory
{
    public class GPUInventoryRepository : InventoryRepository
    {
        public GPUInventoryRepository()
        {
            UpdateGPUInventory();
        }
        private List<GPU> _GPUInventory;
        public List<GPU> GPUInventory
        {
            get { return _GPUInventory; }
            set { _GPUInventory = value; }
        }
        public void AddGPU(GPU myGPU)
        {
            string gpuInventoryFile = @".\repo\gpu_inventory.txt";
            string gpuProperties = myGPU.Serialize();

            using (StreamWriter sw = File.AppendText(gpuInventoryFile))
            {
                sw.WriteLine(gpuProperties);
            }
            UpdateGPUInventory();
        }
        public GPU GetGPU(string productName)
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
        public void UpdateGPUInventory()
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
            GPUInventory = GPUCatalogue;
        }

        public bool IsGPURegistered(string productName)
        {
            List<string> productNames = new List<string>();

            foreach (ProductModel model in GPUInventory) { productNames.Add(model.productName); }
            if (productNames.Contains(productName)) { return true; }
            return false;
        }
    }
}
