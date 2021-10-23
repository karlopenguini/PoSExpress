using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Inventory;
using PoS.ProductModels;
namespace PoS
{
    public class PoSInventory
    {
        public PoSInventory()
        {
            STOREInventory = new InventoryRepository();
            CPUInventory = new CPUInventoryRepository();
            GPUInventory = new GPUInventoryRepository();
            MOBOInventory = new MOBOInventoryRepository();
            RAMInventory = new RAMInventoryRepository();
            STORAGEInventory = new STORAGEInventoryRepository();
        }

        public void UpdateInventory(string productCategory)
        {
            switch (productCategory)
            {
                case "CPU":
                    CPUInventory.UpdateCPUInventory();
                    break;
                case "GPU":
                    GPUInventory.UpdateGPUInventory();
                    break;
                case "MOBO":
                    MOBOInventory.UpdateMOBOInventory();
                    break;
                case "RAM":
                    RAMInventory.UpdateRAMInventory();
                    break;
                case "STORAGE":
                    STORAGEInventory.UpdateSTORAGEInventory();
                    break;
            }
        }

        public ProductModel GetProduct(string productCategory, string productName)
        {
            switch (productCategory)
            {
                case "CPU":
                    return CPUInventory.GetCPU(productName);
                    
                case "GPU":
                    return GPUInventory.GetGPU(productName);
                    
                case "MOBO":
                    return MOBOInventory.GetMOBO(productName);
                    
                case "RAM":
                    return RAMInventory.GetRAM(productName);
                    
                case "STORAGE":
                    return STORAGEInventory.GetSTORAGE(productName);
            }
            return null;
        }

        
        

        public CPUInventoryRepository CPUInventory { get; set; }
        public GPUInventoryRepository GPUInventory { get; set; }
        public MOBOInventoryRepository MOBOInventory { get; set; }
        public RAMInventoryRepository RAMInventory { get; set; }
        public STORAGEInventoryRepository STORAGEInventory { get; set; }
        public InventoryRepository STOREInventory { get; set; }
    }
}
