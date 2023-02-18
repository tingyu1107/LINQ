using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            List<Product> values = System.IO.File.ReadAllLines("C:\\Users\\wendy\\Desktop\\product.csv").Skip(1).Select(v => Product.FromCsv(v)).ToList();

            //1.
            var total_price = values.Sum(x => x.Price);
            Console.WriteLine($"1. 計算所有商品的總價格: {total_price}");

            //2.
            var avg_price = values.Average(x => x.Price);
            Console.WriteLine($"2. 計算所有商品的平均價格: {avg_price}");

            //3.
            var total_quantity = values.Sum(x => x.Quantity);
            Console.WriteLine($"3. 計算商品的總數量: {total_quantity}");

            //4.
            var avg_quantity = values.Average(x => x.Quantity);
            Console.WriteLine($"4. 計算商品的平均數量: {avg_quantity}");

            //5.
            var max_price_item = from p in values
                                 where p.Price == values.Max(x => x.Price)
                                 select p;
            foreach(var p in  max_price_item)
            {
                Console.WriteLine($"5. 找出哪一項商品最貴: {p.Name}");
            }

            //6.
            var min_price_item = from p in values
                                 where p.Price == values.Min(x => x.Price)
                                 select p;
            foreach (var p in min_price_item)
            {
                Console.WriteLine($"6. 找出哪一項商品最便宜: {p.Name}");
            }
           
            //7.
            var c_total_price = values.Where(x => x.Class == "3C").Sum(x => x.Price);
            Console.WriteLine($"7. 計算產品類別為 3C的商品總價: {c_total_price}");

            //8.
            var dr_fo_total_price = values.Where(x => x.Class == "飲料" ||  x.Class == "食品").Sum(x => x.Price);
            Console.WriteLine($"8. 計算產品類別為 飲料及食品的商品總價: {dr_fo_total_price}");

            //9.
            var fo_qu_100 = from p in values
                            where p.Class == "食品" && p.Quantity > 100
                            select p;
            Console.Write("9. 找出所有商品類別為食品，而且商品數量大於100 的商品:");
            foreach (var p in fo_qu_100)
            {
                Console.Write($" {p.Name}");
            }
            Console.WriteLine("");

            //10.
            var g = from p in values
                           group p by p.Class into gp
                           select gp;
            Console.WriteLine("10. 找出各個商品類別底下有哪些商品的價格是大於1000 的商品:");
            foreach (var item in g)
            {
                var bigger_1000 = item.Where(x => x.Price > 1000);
                Console.Write($"{item.Key}: ");
                if(bigger_1000.Count() > 0)
                {
                    foreach(var p in item) 
                    {
                        if(p.Price > 1000) Console.Write($"{p.Name}  ");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("沒大於$1000的商品");
                }
                              
            }

            //11.
            Console.WriteLine("11. 呈上題，請計算該類別底下所有商品的平均價格");
            foreach(var item in g)
            {
                var gp_avg_price = item.Average(x => x.Price);
                Console.Write($"{item.Key}: ");
                Console.WriteLine($"{gp_avg_price}");
            }

            //12.
            var price_high = from p in values
                             orderby p.Price descending
                             select p;
            Console.WriteLine($"12. 依照商品價格由高到低排序: ");
            foreach(var p in price_high)
            {
                Console.WriteLine($"{p.Name} {p.Price}元");
            }

            //13.
            var quantity_low = from p in values
                             orderby p.Quantity
                             select p;
            Console.WriteLine($"13. 依照商品數量由低到高排序: ");
            foreach (var p in quantity_low)
            {
                Console.WriteLine($"{p.Name} 的數量 {p.Quantity}");
            }

            //14.
            /*var g = from p in values
                    group p by p.Class into gp
                    select gp;*/
            Console.Write("14. ");
            foreach(var item in g)
            {
                var high = from i in item
                           where i.Price == item.Max(x => x.Price)
                           select i;
                Console.Write($"{item.Key}類別底下，最貴的商品是");
                foreach(var h in high)
                {
                    Console.WriteLine($"{h.Name}");
                }
            }

            //15.
            Console.Write("15. ");
            foreach (var item in g)
            {
                var low = from i in item
                           where i.Price == item.Min(x => x.Price)
                           select i;
                Console.Write($"{item.Key}類別底下，最便宜的商品是");
                foreach (var l in low)
                {
                    Console.WriteLine($"{l.Name}");
                }
            }

            //16.
            var p_10000 = from p in values
                          where p.Price <= 10000
                          select p;
            Console.Write("找出價格小於等於10000 的商品: ");
            foreach(var p in p_10000)
            {
                Console.Write($" {p.Name}");
            }
            Console.WriteLine();


            //17.
            Console.WriteLine("輸入想查第幾頁(0-4): ");

            const int pageSize = 4;//每頁有4筆
            int pageNum =  Convert.ToInt32(Console.ReadLine());
            var query = values.Skip(pageNum * pageSize).Take(pageSize);
            foreach(var item in query)
            {
                Console.WriteLine($"商品編號: {item.Id}，商品名稱: {item.Name}，商品數量: {item.Quantity}，價格: {item.Price}，商品類別: {item.Class}。");
            }

            Console.ReadLine();
        }

        
    }
}
