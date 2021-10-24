using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.PurchaseManagementModule
{
    class PurchaseManagerView
    {
        public void PurchaseManager(PoSInventory PoSInventoryRepository)
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
                        OrderGenerator InitOrderGenerator = new OrderGenerator(PoSInventoryRepository);
                        break;
                    case "2":
                        ProgramLooping = false;
                        break;
                    
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.Write(
                "Purchase Manager\n\n" +
                    "\t1. Create Order\n" +
                    "\t2. Back\n\n" +
                    "> ");
        }
    }
}
