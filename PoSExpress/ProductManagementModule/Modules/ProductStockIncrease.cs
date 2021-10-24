using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.LocalValidator;
namespace PoS.ProductManagementModule
{
    public class ProductStockIncrease
    {
        public ProductStockIncrease(PoSInventory PoSInventoryRepository)
        {
            StockInput AddendEncoder = new StockInput();
            string productCategory = GeneralInput.GetProductCategory();
            string productName = GeneralInput.GetProductName(productCategory, PoSInventoryRepository);
            uint increment = AddendEncoder.GetAddend();

            PoSInventoryRepository.STOREInventory.IncreaseStock(productCategory, productName, increment);
        }
    }
}
