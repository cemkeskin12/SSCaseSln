using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCases.Services
{
    public class SetPriceFormat
    {
        public string SetPrice(string price)
        {
            int a = price.IndexOf("TL");
            if (a >= 0)
            {
                price = price.Substring(0, a);
                price = price.Replace(".", "");
            }
            return price;
        }
    }
}
