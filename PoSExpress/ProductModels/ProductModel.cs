using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
    public class ProductModel
    {
        public string productName { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public uint stock { get; set; }

    }
}
