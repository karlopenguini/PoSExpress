using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoS.ProductModels;

namespace PoS.Inventory
{
    public class STORAGEInventoryRepository : InventoryRepository
    {
        public STORAGEInventoryRepository()
        {
            UpdateSTORAGEInventory();
        }

        private List<STORAGE> _STORAGEInventory;
        public List<STORAGE> STORAGEInventory
        {
            get { return _STORAGEInventory; }
            set { _STORAGEInventory = value; }
        }
        public void AddSTORAGE(STORAGE mySTORAGE)
        {
            string storageInventoryFile = @".\repo\storage_inventory.txt";
            string storageProperties = mySTORAGE.Serialize();

            using (StreamWriter sw = File.AppendText(storageInventoryFile))
            {
                sw.WriteLine(storageProperties);
            }
            UpdateSTORAGEInventory();
        }
        public STORAGE GetSTORAGE(string productName)
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
        public void UpdateSTORAGEInventory()
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
            STORAGEInventory = STORAGECatalogue;
        }
        public bool IsSTORAGERegistered(string productName)
        {
            List<string> productNames = new List<string>();

            foreach (ProductModel model in STORAGEInventory) { productNames.Add(model.productName); }
            if (productNames.Contains(productName)) { return true; }
            return false;
        }
    }
}
