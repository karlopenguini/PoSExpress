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
            string cpuProperties = myCPU.Serialize();

            using(StreamWriter sw = File.AppendText(cpuInventoryFile))
            {
                sw.WriteLine(cpuProperties);
            }
        }

        public CPU GetCPU(string productName)
        {
            string cpuInventoryFile = ".\\repo\\cpu_inventory.txt";
            string[] cpuList = File.ReadAllLines(cpuInventoryFile);
            foreach (string cpu in cpuList)
            {
                string cpuProductName = cpu.Split('|')[0]; // Get productName

                if(productName == cpuProductName)
                {
                    return CPU.Deserialize(cpu);
                }
            }
            return null;
        }

        public List<CPU> CPUCatalogue()
        {
            string cpuInventoryFile = ".\\repo\\cpu_inventory.txt";
            string[] cpuList = File.ReadAllLines(cpuInventoryFile);
            List<CPU> CPUCatalogue = new List<CPU>();
            foreach (string cpu in cpuList)
            {
                CPUCatalogue.Add(CPU.Deserialize(cpu));
            }
            return null;
        }
        
        
        public void IncreaseStock(ProductModel product) { }
        public void DecreaseStock(ProductModel product) { }
        public void ChangePrice(ProductModel product, int newPrice)
        {
           product.price = newPrice;
        }
    }
}
