using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductManagementModules
{
    public class ProductManagerModule
    {
        public void ProductManager()
        {
            bool ProgramLooping = true;
            string input;
            while (ProgramLooping)
            {
                ShowMainMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        ProgramLooping = false;
                        break;

                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.Write(
                "Product Manager\n\n" +
                    "\t1. Add new Product Model\n" +
                    "\t2. Change Product Model's Price\n" +
                    "\t3. Increase Stock of Product Model\n" +
                    "\t4. Decrease Stock of Product Model\n" +
                    "\t5. Back\n\n" +
                    "> ");
        }
        
    }
}
