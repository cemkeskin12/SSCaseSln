using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCases.Services
{
    public class AveragePrice
    {
        public void Calculate(string priceList)
        {
            Console.WriteLine(priceList);



            for (int f = 0; f < priceList.Length; f++)
            {
                File.WriteAllText("AveragePrice.txt", priceList.ToString());
            }

        }
    }
}
