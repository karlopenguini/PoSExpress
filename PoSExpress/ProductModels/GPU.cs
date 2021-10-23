using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
    public class GPU : ProductModel, ISerializer
    {
        public GPU(string _productName, string _brand, decimal _price, uint _stock, string _gpuChipset, string _gpuMemoryType, ushort _coreClock)
        {
            productName = _productName;
            brand = _brand;
            price = _price;
            stock = _stock;
            gpuChipset = _gpuChipset;
            gpuMemoryType = _gpuMemoryType;
            coreClock = _coreClock;
        }
        public string gpuChipset
        {
            get;
            set;
        }

        public string gpuMemoryType
        {
            get;
            set;
        }

        public ushort coreClock
        {
            get;
            set;
        }

        public string Serialize()
        {
            return $"{productName}|{brand}|{price}|{stock}|{gpuChipset}|{gpuMemoryType}|{coreClock}";
        }
        public static GPU Deserialize(string gpuPropertyString)
        {
            string[] gpuProperties = gpuPropertyString.Split('|');

            string _productName = gpuProperties[0];
            string _brand = gpuProperties[1];
            decimal _price = Convert.ToDecimal(gpuProperties[2]);
            uint _stock = Convert.ToUInt32(gpuProperties[3]);
            string _gpuChipset = gpuProperties[4];
            string _gpuMemoryType = gpuProperties[5];
            ushort _coreClock = Convert.ToUInt16(gpuProperties[6]);

            GPU newGPU = new GPU(_productName, _brand, _price, _stock, _gpuChipset, _gpuMemoryType, _coreClock);
            return newGPU;
        }
    }
}
