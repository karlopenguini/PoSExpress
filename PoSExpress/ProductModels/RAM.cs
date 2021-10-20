using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
	public class RAM : ProductModel, ISerializer
	{
		public RAM(string _productName, string _brand, decimal _price, int _stock, string _ramSize, int _ramSpeed, byte _ramModule)
		{
			productName = _productName;
			brand = _brand;
			price = _price;
			stock = _stock;
			ramSize = _ramSize;
			ramSpeed = _ramSpeed;
			ramModule = _ramModule;
		}

		public string ramSize
		{
			get;
			set;
		}

		public int ramSpeed
		{
			get;
			set;
		}

		public byte ramModule
		{
			get;
			set;
		}

		public string Serialize()
		{
			return $"{productName},{brand},{price},{stock},{ramSize},{ramSpeed},{ramModule}";
		}

		public static RAM Deserialize(string _productName, string _brand, decimal _price, int _stock, string _ramSize, int _ramSpeed, byte _ramModule)
		{
			RAM newRAM = new RAM(_productName, _brand, _price, _stock, _ramSize, _ramSpeed, _ramModule);
			return newRAM;
		}
	}

}
