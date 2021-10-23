using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Validator
{
    // DIRECTORY FOR INVENTORY TEXT FILES
    // @".\repo\[category]_inventory.txt"
    public class ProductInformationValidator
    {
        public static bool IsValidCategory(string input)
        {
            
            if(input != "1" || input != "2" || input != "3" || input != "4" || input != "5")
            {
                return false;
            }
            return true;
        }

        public static bool IsValidBrand(string input)
        {
            if(input.Any(ch => char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidProductName(string input)
        {
            input = input.ToUpper();
            if(input.Any(ch => char.IsLetterOrDigit(ch) || char.IsWhiteSpace(ch)))
            {
                return true;
            }

            return false;
        }

        public static bool IsValidPrice(string input)
        {
            if (!Decimal.TryParse(input, out decimal result))
            {
                return false;
            }
            return true;

        }
        // is input for price valid? data type = decimal
        // is input for stock valid? data type = uint
    }
    public class CPUProductInformationValidator
    {
        
        public static bool IsValidCPUCoreCount(string input)
        {
            
            if (!Byte.TryParse(input, out byte result) || input != "0")
            {
                MessageBox.Show("Input is not valid! 1-255 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        } 
        
        public static bool IsValidCPUSocket(string input)
        {
            if (input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Up to 10 letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidCPUCooler(string input)
        {
            if(input != "1" || input != "2")
            {
                MessageBox.Show("Input is not valid! 1 or 2 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
    class GPUProductInformationValidator
    {
        public static bool IsValidGPUChipset(string input)
        {
            if (input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        
        public static bool IsValidGPUMemoryType(string input)
        {
            if(input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidCoreClock(string input)
        {
            if (!ushort.TryParse(input, out ushort result) || result >= 10000 || result <= 0)  // if mhz
            {
                MessageBox.Show("Input is not valid! 1-10000 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
    class MOBOProductInformationValidator
    {
        public static bool IsValidMOBORAMSlots(string input)
        {
            if (!Byte.TryParse(input, out _))
            {
                MessageBox.Show("Input is not valid! 1-255 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidMOBOSize(string input)
        {
            input = input.ToUpper();
            if (input != "ATX" || input != "MATX" || input != "ITX")
            {
                MessageBox.Show("Input is not valid! ATX, MATX or ITX only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidMOBOSocket(string input)
        {
            input = input.ToUpper();
            if (input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Up to 10 letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
    class RAMProductInformationValidator
    {
        public static bool IsValidRAMSize(string input)
        {
            input = input.ToUpper();
            if (input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Up to 10 letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidRAMSpeed(string input)
        {
            if (!Int32.TryParse(input, out int result) || result >= 10000 || result <= 0)
            {
                MessageBox.Show("Input is not valid! 1 - 10000 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidRAMModule(string input)
        {
            if (!Byte.TryParse(input, out byte result) || input != "0")
            {
                MessageBox.Show("Input is not valid! 1 - 255 only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
    class STORAGEProductInformationValidator
    {
        public static bool IsValidSTORAGEType(string input)
        {
            input = input.ToUpper();
            if (input != "HDD" || input != "SDD")
            {
                MessageBox.Show("Input is not valid! HDD or SDD only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidSTORAGECapacity(string input)
        {
            input = input.ToUpper();
            if (input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Up to 10 letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidSTORAGECache(string input)
        {
            input = input.ToUpper();
            if (input.Length >= 11 || input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Input is not valid! Up to 10 letters and digits only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
