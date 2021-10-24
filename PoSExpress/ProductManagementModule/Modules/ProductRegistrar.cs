using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Inventory;
using PoS.ProductModels;
using Validator;
using PoS.LocalValidator;
namespace PoS.ProductManagementModule
{
    public class ProductRegistrar
    {
        public ProductRegistrar(PoSInventory PoSInventoryRepository)
        {
            

            RegistrarInput RegistrarEncoder = new RegistrarInput();

            string productCategory =    GeneralInput.GetProductCategory();
            string productName =        RegistrarEncoder.GetNewProductName(PoSInventoryRepository);
            string brand =              RegistrarEncoder.GetBrand();
            decimal price =             RegistrarEncoder.GetPrice();
            uint stock =                RegistrarEncoder.GetStock();
           
            switch (productCategory)
            {
                case "CPU":
                    CPURegistrar CPUEncoder = new CPURegistrar();

                    byte cpuCoreCount = CPUEncoder.GetCPUCoreCount();
                    string cpuSocket =  CPUEncoder.GetCPUSocket();
                    bool cpuCooler =    CPUEncoder.GetCPUCooler();

                    CPU newCPU = new CPU(productName, brand, price, stock, cpuCoreCount, cpuSocket, cpuCooler);
                    PoSInventoryRepository.CPUInventory.AddCPU(newCPU);
                   
                    break;

                case "GPU":
                    GPURegistrar GPUEncoder = new GPURegistrar();

                    string gpuChipset = GPUEncoder.GetGPUChipset();
                    string gpuMemoryType = GPUEncoder.GetGPUMemoryType();
                    ushort gpuCoreCount = GPUEncoder.GetCoreClock();

                    GPU newGPU = new GPU(productName, brand, price, stock, gpuChipset, gpuMemoryType, gpuCoreCount);
                    PoSInventoryRepository.GPUInventory.AddGPU(newGPU);

                    break;

                case "MOBO":
                    MOBORegistrar MOBOEncoder = new MOBORegistrar();

                    byte moboRAMSlots = MOBOEncoder.GetMOBORAMSlots();
                    string moboSize = MOBOEncoder.GetMOBOSize();
                    string moboSocket = MOBOEncoder.GetMOBOSocket();

                    MOBO newMOBO = new MOBO(productName, brand, price, stock, moboRAMSlots, moboSize, moboSocket);
                    PoSInventoryRepository.MOBOInventory.AddMOBO(newMOBO);

                    break;

                case "RAM":
                    RAMRegistrar RAMEncoder = new RAMRegistrar();

                    string ramSize = RAMEncoder.GetRAMSize();
                    int ramSpeed = RAMEncoder.GetRAMSpeed();
                    byte ramModule = RAMEncoder.GetRAMModule();

                    RAM newRAM = new RAM(productName, brand, price, stock, ramSize, ramSpeed, ramModule);
                    PoSInventoryRepository.RAMInventory.AddRAM(newRAM);

                    break;

                case "STORAGE":
                    STORAGERegistrar STORAGEEncoder = new STORAGERegistrar();

                    string storageType = STORAGEEncoder.GetStorageType();
                    string storageCapacity = STORAGEEncoder.GetStorageCapacity();
                    string storageCache = STORAGEEncoder.GetStorageCache();

                    STORAGE newSTORAGE = new STORAGE(productName, brand, price, stock, storageType, storageCapacity, storageCache);
                    PoSInventoryRepository.STORAGEInventory.AddSTORAGE(newSTORAGE);

                    break;
            }
        }
    }
    internal class CPURegistrar
    {
        public byte GetCPUCoreCount()
        {
            string inputCoreCount;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Core Count\n\n" +
                    "> ");
                inputCoreCount = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUCoreCount(inputCoreCount));
            byte cpuCoreCount = byte.Parse(inputCoreCount);
            Console.Clear();
            return cpuCoreCount;
            
        }
        public string GetCPUSocket()
        {
            string inputSocket;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "> ");
                inputSocket = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUSocket(inputSocket));
            string cpuSocket = inputSocket;
            Console.Clear();
            return cpuSocket;
        }
        public bool GetCPUCooler()
        {
            string inputCooler;
            bool cpuCooler = false;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("CPU Socket\n\n" +
                    "1. With CPU Cooler\n" +
                    "2. No CPU Cooler\n\n" +
                    "> ");
                inputCooler = Console.ReadLine();
            } while (!CPUProductInformationValidator.IsValidCPUCooler(inputCooler));
            switch (inputCooler)
            {
                case "1":
                    cpuCooler = true;
                    break;
                case "2":
                    cpuCooler = false;
                    break;
            }
            Console.Clear();
            return cpuCooler;
        }
    }
    internal class GPURegistrar
    {
        public string GetGPUChipset()
        {
            string inputChipset;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("GPU Chipset\n\n +" +
                    "> ");
                inputChipset = Console.ReadLine();
            } while (GPUProductInformationValidator.IsValidGPUChipset(inputChipset));
            string gpuChipset = inputChipset;
            Console.Clear();
            return gpuChipset;
        }
        public string GetGPUMemoryType()
        {
            string inputMemoryType;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("GPU Memory Type\n\n +" +
                    "> ");
                inputMemoryType = Console.ReadLine();
            } while (GPUProductInformationValidator.IsValidGPUMemoryType(inputMemoryType));
            string gpuMemoryType = inputMemoryType;
            Console.Clear();
            return gpuMemoryType;
        }
        public ushort GetCoreClock()
        {
            string inputCoreClock;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("GPU Core Clock\n\n +" +
                    "> ");
                inputCoreClock = Console.ReadLine();
            } while (GPUProductInformationValidator.IsValidCoreClock(inputCoreClock));
            ushort gpuCoreClock = ushort.Parse(inputCoreClock);
            Console.Clear();
            return gpuCoreClock;
        }
    }
    internal class MOBORegistrar
    {
        public byte GetMOBORAMSlots()
        {
            string inputRAMSlots;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("MOBO RAM Slots\n\n +" +
                    "> ");
                inputRAMSlots = Console.ReadLine();
            } while (MOBOProductInformationValidator.IsValidMOBORAMSlots(inputRAMSlots));
            byte moboRAMSlots = Byte.Parse(inputRAMSlots);
            Console.Clear();
            return moboRAMSlots;
        }
        public string GetMOBOSize()
        {
            
                string inputSize;
                do
                {
                    Console.Clear();
                    Console.Write("Register new Product Model\n\n");
                    Console.Write("MOBO Size [ATX/ITX/MATX]\n\n +" +
                        "> ");
                    inputSize = Console.ReadLine();
                } while (MOBOProductInformationValidator.IsValidMOBOSize(inputSize));
                string moboSize = inputSize;
                Console.Clear();
                return moboSize;
        }
        
        public string GetMOBOSocket()
        {
            
                string inputSocket;
                do
                {
                    Console.Clear();
                    Console.Write("Register new Product Model\n\n");
                    Console.Write("MOBO Socket\n\n +" +
                        "> ");
                    inputSocket = Console.ReadLine();
                } while (MOBOProductInformationValidator.IsValidMOBOSocket(inputSocket));
                string moboSocket = inputSocket;
                Console.Clear();
                return moboSocket;
            
        }
    }
    internal class RAMRegistrar
    {
        public string GetRAMSize()
        {
            string inputSize;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("RAM Size\n\n +" +
                    "> ");
                inputSize = Console.ReadLine();
            } while (RAMProductInformationValidator.IsValidRAMSize(inputSize));
            string ramSize = inputSize;
            Console.Clear();
            return ramSize;
        }
        public int GetRAMSpeed()
        {
            string inputSpeed;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("RAM Speed\n\n +" +
                    "> ");
                inputSpeed = Console.ReadLine();
            } while (RAMProductInformationValidator.IsValidRAMSpeed(inputSpeed));
            int ramSpeed = Int32.Parse(inputSpeed);
            Console.Clear();
            return ramSpeed;
        }
        public byte GetRAMModule()
        {
            string inputModule;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("RAM Module\n\n +" +
                    "> ");
                inputModule = Console.ReadLine();
            } while (RAMProductInformationValidator.IsValidRAMModule(inputModule));
            byte ramModule = Byte.Parse(inputModule);
            Console.Clear();
            return ramModule;
        }
    }
    internal class STORAGERegistrar
    {
        public string GetStorageType()
        {
            string inputType;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Storage Type\n\n +" +
                    "> ");
                inputType = Console.ReadLine();
            } while (STORAGEProductInformationValidator.IsValidSTORAGEType(inputType));
            string storageType = inputType;
            Console.Clear();
            return storageType;
        }
        public string GetStorageCapacity()
        {
            string inputCapacity;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Storage Capacity\n\n +" +
                    "> ");
                inputCapacity = Console.ReadLine();
            } while (STORAGEProductInformationValidator.IsValidSTORAGECapacity(inputCapacity));
            string storageCapacity = inputCapacity;
            Console.Clear();
            return storageCapacity;
        }
        public string GetStorageCache()
        {
            string inputCache;
            do
            {
                Console.Clear();
                Console.Write("Register new Product Model\n\n");
                Console.Write("Storage Cache\n\n +" +
                    "> ");
                inputCache = Console.ReadLine();
            } while (STORAGEProductInformationValidator.IsValidSTORAGECache(inputCache));
            string storageCache = inputCache;
            Console.Clear();
            return storageCache;
        }
    }
}
