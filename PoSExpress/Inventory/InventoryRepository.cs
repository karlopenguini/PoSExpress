using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.ProductModels;

namespace PoS.Inventory
{
    public class InventoryRepository
    {
        public List<CPU> listOfCPU { get; set; }
        public List<GPU> listOfGPU { get; set; }
        public List<MOBO> listOfMOBO { get; set; }
        public List<RAM> listOfRAM { get; set; }
        public List<STORAGE> listOfSTORAGE { get; set; }

        public void addCPU() { }
        public void addGPU() { }
        public void addMOBO() { }
        public void addRAM() { }
        public void addSTORAGE() { }
        public CPU getCPU(string productName) 
        {
            
        }
        public GPU getGPU(string productName) 
        {

        }
        public MOBO getMOBO(string productName) 
        { 

        }
        public RAM getRAM(string productName) 
        { 

        }
        public MOBO getSTORAGE(string productName) 
        { 

        }

        public void increaseStock(ProductModel product) { }
        public void decreaseStock(ProductModel product) { }

    }
}
