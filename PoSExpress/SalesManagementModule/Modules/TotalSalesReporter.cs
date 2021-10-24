using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PoS.SalesManagementModule
{
    class TotalSalesReporter
    {
        // path for receipts = .\receipts\text files here
        // path to generate reports = .\reports
        // REWRITE REPORTS DONT CREATE NEW REPORTS


        public TotalSalesReporter()
        {
            string path = @".\reports\TSPR_Report.txt";

            // CPU -> GPU -> MOBO -> RAM -> STORAGE
            Dictionary<string, decimal[]> CPUDict = new Dictionary<string, decimal[]>();
            Dictionary<string, decimal[]> GPUDict = new Dictionary<string, decimal[]>();
            Dictionary<string, decimal[]> MOBODict = new Dictionary<string, decimal[]>();
            Dictionary<string, decimal[]> RAMDict = new Dictionary<string, decimal[]>();
            Dictionary<string, decimal[]> STORAGEDict = new Dictionary<string, decimal[]>();

            string CPUHeader = "_______________________________________________________\n" +
                "SOLD CPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "PRODUCT NAME", "SOLD", "SALES");
            string GPUHeader = "_______________________________________________________\n" +
                "SOLD GPU PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "PRODUCT NAME", "SOLD", "SALES");
            string MOBOHeader = "_______________________________________________________\n" +
                "SOLD MOBO PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "PRODUCT NAME", "SOLD", "SALES");
            string RAMHeader = "_______________________________________________________\n" +
                "SOLD RAM PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "PRODUCT NAME", "SOLD", "SALES");
            string STORAGEHeader = "_______________________________________________________\n" +
                "SOLD STORAGE PER PRODUCT\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "PRODUCT NAME", "SOLD", "SALES");
            string TotalHeader = "_______________________________________________________\n" +
                "RUNNING TOTAL OF ALL PRODUCT SALES AND SOLD\n" +
                String.Format("{0,-30}{1,-30}{2,-30}\n", "CATEGORY", "SOLD", "SALES");

            foreach (var file in Directory.EnumerateFiles(@".\receipts", "*.txt"))
            {
                foreach (var receiptLine in File.ReadLines(file))
                {
                    string[] splitLine = receiptLine.Split('|');

                    if (splitLine[0] == "CPU")
                    {
                        if (CPUDict.ContainsKey(splitLine[1]))
                        {
                            CPUDict[splitLine[1]][0]++;
                            CPUDict[splitLine[1]][1] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            decimal[] values = { decimal.One, decimal.Parse(splitLine[3]) };
                            CPUDict.Add(splitLine[1], values);
                        }
                    }
                    else if (splitLine[0] == "GPU")
                    {
                        if (GPUDict.ContainsKey(splitLine[1]))
                        {
                            GPUDict[splitLine[1]][0]++;
                            GPUDict[splitLine[1]][1] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            decimal[] values = { decimal.One, decimal.Parse(splitLine[3]) };
                            GPUDict.Add(splitLine[1], values);
                        }
                    }
                    else if (splitLine[0] == "MOBO")
                    {
                        if (MOBODict.ContainsKey(splitLine[1]))
                        {
                            MOBODict[splitLine[1]][0]++;
                            MOBODict[splitLine[1]][1] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            decimal[] values = { decimal.One, decimal.Parse(splitLine[3]) };
                            MOBODict.Add(splitLine[1], values);
                        }
                    }
                    else if (splitLine[0] == "RAM")
                    {
                        if (RAMDict.ContainsKey(splitLine[1]))
                        {
                            RAMDict[splitLine[1]][0]++;
                            RAMDict[splitLine[1]][1] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            decimal[] values = { decimal.One, decimal.Parse(splitLine[3]) };
                            RAMDict.Add(splitLine[1], values);
                        }
                    }
                    else if (splitLine[0] == "STORAGE")
                    {
                        if (STORAGEDict.ContainsKey(splitLine[1]))
                        {
                            STORAGEDict[splitLine[1]][0]++;
                            STORAGEDict[splitLine[1]][1] += decimal.Parse(splitLine[3]);
                        }
                        else
                        {
                            decimal[] values = { decimal.One, decimal.Parse(splitLine[3]) };
                            STORAGEDict.Add(splitLine[1], values);
                        }
                    }
                }
            }

            decimal[] runningTotal = {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0  };

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(CPUHeader);
                foreach (KeyValuePair<string, decimal[]> entry in CPUDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}{2,-30}", entry.Key, entry.Value[0], entry.Value[1]);
                    runningTotal[0] += entry.Value[0];
                    runningTotal[1] += entry.Value[1];
                }

                sw.Write(GPUHeader);
                foreach (KeyValuePair<string, decimal[]> entry in GPUDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}{2,-30}", entry.Key, entry.Value[0], entry.Value[1]);
                    runningTotal[2] += entry.Value[0];
                    runningTotal[3] += entry.Value[1];
                }

                sw.Write(MOBOHeader);
                foreach (KeyValuePair<string, decimal[]> entry in MOBODict)
                {
                    sw.WriteLine("{0,-30}{1,-30}{2,-30}", entry.Key, entry.Value[0], entry.Value[1]);
                    runningTotal[4] += entry.Value[0];
                    runningTotal[5] += entry.Value[1];
                }

                sw.Write(RAMHeader);
                foreach (KeyValuePair<string, decimal[]> entry in RAMDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}{2,-30}", entry.Key, entry.Value[0], entry.Value[1]);
                    runningTotal[6] += entry.Value[0];
                    runningTotal[7] += entry.Value[1];
                }

                sw.Write(STORAGEHeader);
                foreach (KeyValuePair<string, decimal[]> entry in STORAGEDict)
                {
                    sw.WriteLine("{0,-30}{1,-30}{2,-30}", entry.Key, entry.Value[0], entry.Value[1]);
                    runningTotal[8] += entry.Value[0];
                    runningTotal[9] += entry.Value[1];
                }

                sw.Write(TotalHeader);
                sw.WriteLine("{0,-30}{1,-30}{2,-30}\n", "CPU", runningTotal[0], runningTotal[1]);
                sw.WriteLine("{0,-30}{1,-30}{2,-30}\n", "GPU", runningTotal[2], runningTotal[3]);
                sw.WriteLine("{0,-30}{1,-30}{2,-30}\n", "MOBO", runningTotal[4], runningTotal[5]);
                sw.WriteLine("{0,-30}{1,-30}{2,-30}\n", "RAM", runningTotal[6], runningTotal[7]);
                sw.WriteLine("{0,-30}{1,-30}{2,-30}", "STORAGE", runningTotal[8], runningTotal[9]);
            }
        }
    }
}