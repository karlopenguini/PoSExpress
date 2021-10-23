using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public class BasicDataInput
    {
        public static bool IsValidPositivieInteger(string input)
        {
            
            if(uint.TryParse(input, out _))
            {
                return true;
            }
            return false;
        }
    }
}
