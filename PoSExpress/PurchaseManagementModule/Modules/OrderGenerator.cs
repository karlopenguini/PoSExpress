using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.LocalValidator;
using System.Windows.Forms;
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
                if(PoSInventoryRepository.GetProduct(productCategory,productName).stock != 0)
                {
                    CurrentCart.AddToCart(productCategory, productName, PoSInventoryRepository);
                    CurrentCart.GenerateReceipt();
                }
                else
                {
                    MessageBox.Show($"{productName} is out of Stock!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                
            } while (!CartEncoder.GetFlag(CurrentCart));

            string dataToWrite = CurrentCart.GenerateReceipt();
            CurrentCart.WriteReceipt(dataToWrite);
        }
    }
}
