using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PoS.SalesManagementModule
{
    class SalesPerProductReporter
    {
        // path for receipts = .\receipts\text files here
        // path to generate reports = .\reports
        // REWRITE REPORTS DONT CREATE NEW REPORTS


        public SalesPerProductReporter()
        {
            string path = @".\reports\SPR_Report.txt";

            // CPU -> GPU -> MOBO -> RAM -> STORAGE
            Dictionary<string, decimal> CPUDict = new Dictionary<string, decimal>();
            Dictionary<string, decimal> GPUDict = new Dictionary<string, decimal>();
            Dictionary<string, decimal> MOBODict = new Dictionary<string, decimal>();
            Dictionary<string, decimal> RAMDict = new Dictionary<string, decimal>();
            Dictionary<string, decimal> STORAGEDict = new Dictionary<string, decimal>();

            string CPUHeader = "_______________________________________________________\n" +
                "SOLD CPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SALES");
            string GPUHeader = "_______________________________________________________\n" +
                "SOLD GPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SALES");
            string MOBOHeader = "_______________________________________________________\n" +
                "SOLD MOBO PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SALES");
            string RAMHeader = "_______________________________________________________\n" +
                "SOLD RAM PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SALES");
            string STORAGEHeader = "_______________________________________________________\n" +
                "SOLD STORAGE PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}\n", "PRODUCT NAME", "SALES");

            foreach (var file in Directory.EnumerateFiles(@".\receipts", "*.txt"))
            {
                foreach (var receiptLine in File.ReadLines(file))
                {
                    string[] splitLine = receiptLine.Split('|');

                    if (splitLine[0] == "CPU")
                    {
                        if (CPUDict.ContainsKey(splitLine[1]))
                        {
                            CPUDict[splitLine[1]] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            CPUDict.Add(splitLine[1], decimal.Parse(splitLine[3]));
                        }
                    }
                    else if (splitLine[0] == "GPU")
                    {
                        if (GPUDict.ContainsKey(splitLine[1]))
                        {
                            GPUDict[splitLine[1]] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            GPUDict.Add(splitLine[1], decimal.Parse(splitLine[3]));
                        }
                    }
                    else if (splitLine[0] == "MOBO")
                    {
                        if (MOBODict.ContainsKey(splitLine[1]))
                        {
                            MOBODict[splitLine[1]] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            MOBODict.Add(splitLine[1], decimal.Parse(splitLine[3]));
                        }
                    }
                    else if (splitLine[0] == "RAM")
                    {
                        if (RAMDict.ContainsKey(splitLine[1]))
                        {
                            RAMDict[splitLine[1]] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            RAMDict.Add(splitLine[1], decimal.Parse(splitLine[3]));
                        }
                    }
                    else if (splitLine[0] == "STORAGE")
                    {
                        if (STORAGEDict.ContainsKey(splitLine[1]))
                        {
                            STORAGEDict[splitLine[1]] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            STORAGEDict.Add(splitLine[1], decimal.Parse(splitLine[3]));
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(CPUHeader);
                foreach (KeyValuePair<string, decimal> entry in CPUDict)
                {
                    
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }


                sw.Write(GPUHeader);
                foreach (KeyValuePair<string, decimal> entry in GPUDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(MOBOHeader);
                foreach (KeyValuePair<string, decimal> entry in MOBODict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(RAMHeader);
                foreach (KeyValuePair<string, decimal> entry in RAMDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

                sw.Write(STORAGEHeader);
                foreach (KeyValuePair<string, decimal> entry in STORAGEDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}", entry.Key, entry.Value);
                }

            }
        }
    }
}