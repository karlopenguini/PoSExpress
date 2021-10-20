using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
    public class CPU : ProductModel, ISerializer
    {
        public CPU(string _productName, string _brand, decimal _price, int _stock, byte _cpuCoreCount, string _cpuSocket, bool _cpuCooler) 
        {
            productName = _productName;
            brand = _brand;
            price = _price;
            stock = _stock;
            cpuCoreCount = _cpuCoreCount;
            cpuSocket = _cpuSocket;
            cpuCooler = _cpuCooler;
        }
       
        public byte cpuCoreCount
        {
            get;
            set;
        }
        
        public string cpuSocket
        {
            get;
            set;
        }
        
        public bool cpuCooler
        {
            get;
            set;
        }

        
        public string Serialize()
        {
            return $"{productName},{brand},{price},{stock},{cpuCoreCount},{cpuSocket},{cpuCooler}";
        }
        public static CPU Deserialize(string _productName, string _brand, decimal _price, int _stock, byte _cpuCoreCount, string _cpuSocket, bool _cpuCooler)
        {
            CPU newCPU = new CPU(_productName, _brand, _price, _stock, _cpuCoreCount, _cpuSocket, _cpuCooler);
            return newCPU;
        }
    }
}
