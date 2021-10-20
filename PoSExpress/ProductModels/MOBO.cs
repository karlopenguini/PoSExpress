using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
	public class MOBO : ProductModel, ISerializer
	{
		public MOBO(string _productName, string _brand, decimal _price, int _stock, byte _moboRAMSlots, string _moboSize, string _moboSocket)
		{
			productName = _productName;
			brand = _brand;
			price = _price;
			stock = _stock;
			moboRAMSlots = _moboRAMSlots;
			moboSize = _moboSize;
			moboSocket = _moboSocket;
		}

		public byte moboRAMSlots
		{
			get;
			set;
		}

		public string moboSize
		{
			get;
			set;
		}

		public string moboSocket
		{
			get;
			set;
		}

		public string Serialize()
		{
			return $"{productName},{brand},{price},{stock},{moboRAMSlots},{moboSize},{moboSocket}";
		}

		public static MOBO Deserialize(string _productName, string _brand, decimal _price, int _stock, byte _moboRAMSlots, string _moboSize, string _moboSocket)
		{
			MOBO newMOBO = new MOBO(_productName, _brand, _price, _stock, _moboRAMSlots, _moboSize, _moboSocket);
			return newMOBO;
		}
	}

}
