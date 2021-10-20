using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
	public class STORAGE : ProductModel, ISerializer
	{
		public STORAGE(string _productName, string _brand, decimal _price, int _stock, string _storageType, string _storageCapacity, string _storageCache)
		{
			productName = _productName;
			brand = _brand;
			price = _price;
			stock = _stock;
			storageType = _storageType;
			storageCapacity = _storageCapacity;
			storageCache = _storageCache;
		}

		public string storageType
		{
			get;
			set;
		}

		public string storageCapacity
		{
			get;
			set;
		}

		public string storageCache
		{
			get;
			set;
		}

		public string Serialize()
		{
			return $"{productName},{brand},{price},{stock},{storageType},{storageCapacity},{storageCache}";
		}

		public static STORAGE Deserialize(string _productName, string _brand, decimal _price, int _stock, string _storageType, string _storageCapacity, string _storageCache)
		{
			STORAGE newSTORAGE = new STORAGE(_productName, _brand, _price, _stock, _storageType, _storageCapacity, _storageCache);
			return newSTORAGE;
		}
	}

}
