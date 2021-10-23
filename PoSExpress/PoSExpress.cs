using System;
using System.Collections.Generic;
using PoS.Inventory;
using PoS.ProductManagementModule;

namespace PoS
{
    public class PoSExpress
    {
        public static void Main()
        {
            ProductManagerModule            PoSProductManager =         new ProductManagerModule();

            CPUInventoryRepository          CPUInventory =              new CPUInventoryRepository();
            GPUInventoryRepository          GPUInventory =              new GPUInventoryRepository();
            MOBOInventoryRepository         MOBOInventory =             new MOBOInventoryRepository();
            RAMInventoryRepository          RAMInventory =              new RAMInventoryRepository();
            STORAGEInventoryRepository      STORAGEInventory =          new STORAGEInventoryRepository();

            Dictionary<string, InventoryRepository> Inventory = new Dictionary<string, InventoryRepository>
            {
                {"CPU", CPUInventory },
                {"GPU", GPUInventory },
                {"MOBO", MOBOInventory },
                {"RAM", RAMInventory },
                {"STORAGE", STORAGEInventory }
            };
            
            PoSExpress                      MenuViewer =                new PoSExpress();

            bool ProgramLooping = true;
            string input;
            while (ProgramLooping)
            {
                MenuViewer.ShowMainMenu();
                input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "1":
                        PoSProductManager.ProductManager(Inventory);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;

                    case "EXIT":
                        ProgramLooping = false;
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.Write(
                "PoSExpress\n\n" +
                "1. Product Manager\n"+
                "2. Order Manager\n" +
                "3. Sales Analyzer\n\n" +
                "Type 'EXIT' to exit the program.\n\n> ");
            
        }
    }
}
