using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Inventory;

namespace PoS.ProductManagementModule
{
    public class ProductManagerView
    {
        public void ProductManager(PoSInventory PoSInventoryRepository)
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
                        ProductRegistrar InitProductRegistration = new ProductRegistrar(PoSInventoryRepository);
                        break;
                    case "2":
                        ProductPriceChanger InitProductPriceChanger = new ProductPriceChanger(PoSInventoryRepository);
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
