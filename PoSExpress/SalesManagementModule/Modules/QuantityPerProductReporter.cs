using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PoS.SalesManagementModule
{
    class QuantityPerProductReporter
    {
        // path for receipts = .\receipts\text files here
        // path to generate reports = .\reports
        // REWRITE REPORTS DONT CREATE NEW REPORTS

        
        public QuantityPerProductReporter()
        {
            string path = @".\reports\QPR_Report.txt";

            // CPU -> GPU -> MOBO -> RAM -> STORAGE
            Dictionary<string, int> CPUDict = new Dictionary<string, int>();
            Dictionary<string, int> GPUDict = new Dictionary<string, int>();
            Dictionary<string, int> MOBODict = new Dictionary<string, int>();
            Dictionary<string, int> RAMDict = new Dictionary<string, int>();
            Dictionary<string, int> STORAGEDict = new Dictionary<string, int>();

            string CPUHeader = "_______________________________________________________\n" +
                "SOLD CPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SOLD");
            string GPUHeader = "_______________________________________________________\n" +
                "SOLD GPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SOLD");
            string MOBOHeader = "_______________________________________________________\n" +
                "SOLD MOBO PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SOLD");
            string RAMHeader = "_______________________________________________________\n" +
                "SOLD RAM PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SOLD");
            string STORAGEHeader = "_______________________________________________________\n" +
                "SOLD STORAGE PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SOLD");

            foreach (var file in Directory.EnumerateFiles(@".\receipts", "*.txt"))
            {
                foreach (var receiptLine in File.ReadLines(file))
                {
                    string[] splitLine = receiptLine.Split('|');

                    if (splitLine[0] == "CPU")
                    {
                        if (CPUDict.ContainsKey(splitLine[1])){
                            CPUDict[splitLine[1]]++;
                        }
                        else
                        {
                            CPUDict.Add(splitLine[1], 1);
                        }
                    }
                    else if (splitLine[0] == "GPU")
                    {
                        if (GPUDict.ContainsKey(splitLine[1]))
                        {
                            GPUDict[splitLine[1]]++;
                        }
                        else
                        {
                            GPUDict.Add(splitLine[1], 1);
                        }
                    }
                    else if (splitLine[0] == "MOBO")
                    {
                        if (MOBODict.ContainsKey(splitLine[1]))
                        {
                            MOBODict[splitLine[1]]++;
                        }
                        else
                        {
                            MOBODict.Add(splitLine[1], 1);
                        }
                    }
                    else if (splitLine[0] == "RAM")
                    {
                        if (RAMDict.ContainsKey(splitLine[1]))
                        {
                            RAMDict[splitLine[1]]++;
                        }
                        else
                        {
                            RAMDict.Add(splitLine[1], 1);
                        }
                    }
                    else if (splitLine[0] == "STORAGE")
                    {
                        if (STORAGEDict.ContainsKey(splitLine[1]))
                        {
                            STORAGEDict[splitLine[1]]++;
                        }
                        else
                        {
                            STORAGEDict.Add(splitLine[1], 1);
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(CPUHeader);
                foreach(KeyValuePair<string, int> entry in CPUDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }
                

                sw.Write(GPUHeader);
                foreach (KeyValuePair<string, int> entry in GPUDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(MOBOHeader);
                foreach (KeyValuePair<string, int> entry in MOBODict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(RAMHeader);
                foreach (KeyValuePair<string, int> entry in RAMDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(STORAGEHeader);
                foreach (KeyValuePair<string, int> entry in STORAGEDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

            }
        }
    }
}
