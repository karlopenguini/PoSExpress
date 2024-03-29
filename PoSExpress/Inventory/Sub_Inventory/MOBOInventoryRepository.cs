﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PoS.ProductModels;
namespace PoS.Inventory
{
    public class MOBOInventoryRepository : InventoryRepository
    {
        public MOBOInventoryRepository()
        {
            UpdateMOBOInventory();
        }

        private List<MOBO> _MOBOInventory;
        public List<MOBO> MOBOInventory
        {
            get { return _MOBOInventory; }
            set { _MOBOInventory = value; }
        }
        public void AddMOBO(MOBO myMOBO)
        {
            string moboInventoryFile = @".\repo\mobo_inventory.txt";
            string moboProperties = myMOBO.Serialize();

            using (StreamWriter sw = File.AppendText(moboInventoryFile))
            {
                sw.WriteLine(moboProperties);
            }
            UpdateMOBOInventory();
        }
        public MOBO GetMOBO(string productName)
        {
            foreach (MOBO mobo in MOBOInventory)
            {
                if (productName == mobo.productName)
                {
                    return mobo;
                }
            }
            return null;
        }
        public void UpdateMOBOInventory()
        {
            string path = @".\repo\mobo_inventory.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string moboInventoryFile = @".\repo\mobo_inventory.txt";
            string[] moboList = File.ReadAllLines(moboInventoryFile);
            List<MOBO> MOBOCatalogue = new List<MOBO>();
            foreach (string mobo in moboList)
            {
                MOBOCatalogue.Add(MOBO.Deserialize(mobo));
            }
            MOBOInventory = MOBOCatalogue;
        }
        public bool IsMOBORegistered(string productName)
        {
            foreach (ProductModel model in MOBOInventory)
            {
                if (model.productName == productName)
                {
                    return true;
                }
            }

            return false;
        }

        public void ListAllMOBO()
        {
            Console.Write("MOTHERBOARD CATALOG:\n");
            foreach (MOBO mobo in MOBOInventory)
            {
                Console.WriteLine($"- {mobo.productName}");
            }
            Console.WriteLine("");
        }
        public void ListDetailedInformation()
        {
            foreach (MOBO mobo in MOBOInventory)
            {
                Console.WriteLine(mobo.Serialize());
            }
        }
    }
}
