using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.ProductModels;
using System.IO;

namespace PoS.Inventory
{
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
        public void AddCPU(CPU myCPU)
        {
            string cpuInventoryFile = @".\repo\cpu_inventory.txt";
            string cpuProperties = myCPU.Serialize();                               // Convert CPU object properties to string

            using (StreamWriter sw = File.AppendText(cpuInventoryFile))
            {
                sw.WriteLine(cpuProperties);                                        // Write properties to string
            }
            UpdateCPUInventory();
        }
        public CPU GetCPU(string productName)
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
        private void UpdateCPUInventory()
        {
            string path = @".\repo\cpu_inventory.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();
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
        public bool IsCPURegistered(string productName)
        {
            List<string> productNames = new List<string>();

            foreach (ProductModel model in CPUInventory) { productNames.Add(model.productName); }
            if (productNames.Contains(productName)) { return true; }
            return false;
        }
    }
}
