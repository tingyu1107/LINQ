using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Product
    {
        public string Id;
        public string Name;
        public int Quantity;
        public int Price;
        public string Class;

        public static Product FromCsv(string csvLine)

        {

            string[] values = csvLine.Split(',');

            Product Values = new Product();

            Values.Id = values[0];
            Values.Name = values[1];
            Values.Quantity = Convert.ToInt32(values[2]);
            Values.Price = Convert.ToInt32(values[3]);
            Values.Class = values[4];


            return Values;

        }

    }
}
