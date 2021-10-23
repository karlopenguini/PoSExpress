using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Inventory;
namespace PoS
{
    public class PoSInventory
    {
        public PoSInventory()
        {
            CPUInventory = new CPUInventoryRepository();
            GPUInventory = new GPUInventoryRepository();
            MOBOInventory = new MOBOInventoryRepository();
            RAMInventory = new RAMInventoryRepository();
            STORAGEInventory = new STORAGEInventoryRepository();
        }

        public CPUInventoryRepository CPUInventory { get; set; }
        public GPUInventoryRepository GPUInventory { get; set; }
        public MOBOInventoryRepository MOBOInventory { get; set; }
        public RAMInventoryRepository RAMInventory { get; set; }
        public STORAGEInventoryRepository STORAGEInventory { get; set; }
    }
}
