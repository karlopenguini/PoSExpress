using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.ProductModels;
using PoS.LocalValidator;
namespace PoS.ProductManagementModule
{
    public class ProductStockDecrease : GeneralInput
    {
        public ProductStockDecrease(PoSInventory PoSInventoryRepository)
        {
            StockInput SubtrahendEncoder = new StockInput();
            string productCategory = GeneralInput.GetProductCategory();
            string productName = GeneralInput.GetProductName(productCategory, PoSInventoryRepository);
            ProductModel product = PoSInventoryRepository.GetProduct(productCategory, productName);
            uint decrementStock = SubtrahendEncoder.GetSubtrahend(product);

            PoSInventoryRepository.STOREInventory.DecreaseStock(productCategory, productName, decrementStock);
            PoSInventoryRepository.UpdateInventory(productCategory);
        }
    }
}
