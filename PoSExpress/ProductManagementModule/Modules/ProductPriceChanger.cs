using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validator;
using PoS.ProductModels;
using PoS.Inventory;

namespace PoS.ProductManagementModule
{
    public class ProductPriceChanger : GeneralInput
    {
        public ProductPriceChanger(PoSInventory PoSInventoryRepository)
        {
            PriceInput PriceEncoder = new PriceInput();
            string productCategory =    GeneralInput.GetProductCategory();
            string productName =        GeneralInput.GetProductName(productCategory, PoSInventoryRepository);
            decimal newPrice =          PriceEncoder.GetNewPrice();

            PoSInventoryRepository.STOREInventory.ChangePrice(productCategory, productName, newPrice);
            PoSInventoryRepository.UpdateInventory(productCategory);
        }
        
    }
}
