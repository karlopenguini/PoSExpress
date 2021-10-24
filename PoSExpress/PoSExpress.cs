using PoS.ProductManagementModule;
using PoS.PurchaseManagementModule;
using PoS.SalesManagementModule;
using System;


namespace PoS
{
    public class PoSExpress
    {
        public static void Main()
        {
            ProductManagerView PoSProductManager = new ProductManagerView();
            PurchaseManagerView PoSPurchaseManager = new PurchaseManagerView();
            SalesManagerView PoSSalesManager = new SalesManagerView();

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
                        PoSPurchaseManager.PurchaseManager(PoSInventoryRepository);
                        break;
                    case "3":
                        PoSSalesManager.SalesManager(PoSInventoryRepository);
                        break;
                    case "4":
                        MenuViewer.ShowAllProducts(PoSInventoryRepository);
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
                "3. Sales Analyzer\n" +
                "4. Show All Products\n\n" +
                "Type 'EXIT' to exit the program.\n\n> ");

        }

        private void ShowAllProducts(PoSInventory PoSInventoryRepository)
        {
            Console.Clear();
            PoSInventoryRepository.ShowAllProducts();
            Console.WriteLine("Press any key to exit . . . ");
            Console.ReadKey();
        }

    }
}
