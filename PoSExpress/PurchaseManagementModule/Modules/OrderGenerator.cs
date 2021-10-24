using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.LocalValidator;
namespace PoS.PurchaseManagementModule
{
    public class OrderGenerator
    {
        public OrderGenerator(PoSInventory PoSInventoryRepository)
        {
            CartInput CartEncoder = new CartInput();

            CustomerCart CurrentCart = new CustomerCart();

            do
            {
                string productCategory = GeneralInput.GetProductCategory();
                string productName = CartEncoder.GetProductName(productCategory, PoSInventoryRepository);

                CurrentCart.AddToCart(productCategory, productName, PoSInventoryRepository);
                CurrentCart.GenerateReceipt();
            } while (!CartEncoder.GetFlag(CurrentCart));

            string dataToWrite = CurrentCart.GenerateReceipt();
            CurrentCart.WriteReceipt(dataToWrite);
        }
    }
}
