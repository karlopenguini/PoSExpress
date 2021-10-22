using System;
using PoS.Inventory;
using PoS.ProductManagementModules;

namespace PoS
{
    public class PoSExpress
    {
        public static void Main()
        {
            ProductManagerModule PoSProductManager = new ProductManagerModule();


            bool ProgramLooping = true;
            string input;
            while (ProgramLooping)
            {
                ShowMainMenu();
                input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "1":
                        PoSProductManager.ProductManager();
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

        static void ShowMainMenu()
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
