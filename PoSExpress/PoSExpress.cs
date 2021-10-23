using PoS.ProductManagementModule;
using System;


namespace PoS
{
    public class PoSExpress
    {
        public static void Main()
        {
            ProductManagerView PoSProductManager = new ProductManagerView();
            PoSInventory PoSInventoryRepository = new PoSInventory();

            PoSExpress MenuViewer = new PoSExpress();
            bool ProgramLooping = true;
            string input;
            while (ProgramLooping)
            {
                MenuViewer.ShowMainMenu();
                input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "1":
                        PoSProductManager.ProductManager(PoSInventoryRepository);
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
                "1. Product Manager\n" +
                "2. Order Manager\n" +
                "3. Sales Analyzer\n\n" +
                "Type 'EXIT' to exit the program.\n\n> ");

        }
    }
}
