using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ProductModels
{
	public class MOBO : ProductModel, ISerializer
	{
		public MOBO(string _productName, string _brand, decimal _price, uint _stock, byte _moboRAMSlots, string _moboSize, string _moboSocket)
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
			return $"{productName}|{brand}|{price}|{stock}|{moboRAMSlots}|{moboSize}|{moboSocket}";
		}
		public static MOBO Deserialize(string moboPropertyString)
		{
			string[] moboProperties = moboPropertyString.Split('|');

			string _productName = moboProperties[0];
			string _brand = moboProperties[1];
			decimal _price = Convert.ToDecimal(moboProperties[2]);
			uint _stock = Convert.ToUInt32(moboProperties[3]);
			byte _moboRAMSlots = Convert.ToByte(moboProperties[4]);
			string _moboSize = moboProperties[5];
			string _moboSocket = moboProperties[6];

			MOBO newMOBO = new MOBO(_productName, _brand, _price, _stock, _moboRAMSlots, _moboSize, _moboSocket);
			return newMOBO;
		}
	}
}
