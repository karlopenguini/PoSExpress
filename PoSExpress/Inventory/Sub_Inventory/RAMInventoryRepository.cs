using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoS.ProductModels;
namespace PoS.Inventory
{
    public class RAMInventoryRepository : InventoryRepository
    {
        public RAMInventoryRepository()
        {
            UpdateRAMInventory();
        }

        private List<RAM> _RAMInventory;
        public List<RAM> RAMInventory
        {
            get { return _RAMInventory; }
            set { _RAMInventory = value; }
        }
        public void AddRAM(RAM myRAM)
        {
            string ramInventoryFile = @".\repo\ram_inventory.txt";
            string ramProperties = myRAM.Serialize();

            using (StreamWriter sw = File.AppendText(ramInventoryFile))
            {
                sw.WriteLine(ramProperties);
            }
            UpdateRAMInventory();
        }
        public RAM GetRAM(string productName)
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

        public void UpdateRAMInventory()
        {
            string path = @".\repo\ram_inventory.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();

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
            RAMInventory = RAMCatalogue;
        }
        public bool IsRAMRegistered(string productName)
        {
            foreach (ProductModel model in RAMInventory)
            {
                if (model.productName == productName)
                {
                    return true;
                }
            }

            return false;
        }
        public void ListAllRAM()
        {
            Console.Write("RAM CATALOG:\n");
            foreach (RAM ram in RAMInventory)
            {
                Console.WriteLine($"- {ram.productName}");
            }
            Console.WriteLine("");
        }
        public void ListDetailedInformation()
        {
            foreach (RAM ram in RAMInventory)
            {
                Console.WriteLine(ram.Serialize());
            }
        }
    }
}
