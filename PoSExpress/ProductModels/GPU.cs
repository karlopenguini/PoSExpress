using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
    public class GPU : ProductModel, ISerializer
    {
        public GPU(string _productName, string _brand, decimal _price, int _stock, string _gpuChipset, string _gpuMemoryType, ushort _coreClock)
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
            return $"{productName},{brand},{price},{stock},{gpuChipset},{gpuMemoryType},{coreClock}";
        }

        public static GPU Deserialize(string _productName, string _brand, decimal _price, int _stock, string _gpuChipset, string _gpuMemoryType, ushort _coreClock)
        {
            GPU newGPU = new GPU(_productName, _brand, _price, _stock, _gpuChipset, _gpuMemoryType, _coreClock);
            return newGPU;
        }
    }
}
