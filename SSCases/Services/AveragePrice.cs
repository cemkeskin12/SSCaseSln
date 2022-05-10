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
                //it will create txt in \SSCaseSln\SSCases\bin\Debug\net6.0 location.
                File.WriteAllText("AveragePrice.txt", priceList.ToString());
            }

        }
    }
}
