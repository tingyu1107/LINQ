using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 題2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool game = true;
            Random r = new Random();
            while (game)
            {
                Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～\r\n");
                string ans = "";
                var list1 = new List<int> { };
                while (ans.Length < 4)
                {
                    int r1 = r.Next(0, 10);
                    if (!ans.Contains(r1.ToString()))
                    {
                        ans += r1.ToString();
                        list1.Add(r1);
                    }
                }

                Console.Write("ans:　");
                foreach(var i in list1)
                {
                Console.Write (i);
                }
                Console.WriteLine();                          
                
                int a = 0, b = 0;
                for (int i = 0; i < 100; i++)
                {
                    var list2 = new List<int> { };
                    Console.WriteLine("------");
                    Console.WriteLine("請輸入 4 個數字： ");
                    string guess = Console.ReadLine();
                    for(int j = 0; j < 4 ; j++)
                    {
                        int g = Convert.ToInt32(guess[j]- '0') ;
                        list2.Add(g);
                    }
                    /*foreach (var k in list2)
                    {
                        Console.Write(k);
                    }*/
                    
                    var intersect = list1.Intersect(list2);
                                       
                    if (intersect.Count() > 0)
                    {
                        a = intersect.Count(x => list1.IndexOf(x) == list2.IndexOf(x));
                        
                    }
                    b = intersect.Count() -  a;

                    Console.WriteLine($"判定結果是{a}A{b}B");
                    if (a == 4 && b == 0)
                    {
                        Console.WriteLine("恭喜你！猜對了！！");
                        break;
                    }
                    a = 0;
                    b = 0;
            }

                Console.WriteLine("------\r\n");
                Console.WriteLine("你要繼續玩嗎？(y/n): ");
                string end = "";
                end = Console.ReadLine();

                if (end == "y") game = true;
                if (end == "n")
                {
                    game = false;
                    Console.WriteLine("遊戲結束，下次再來玩喔～\r\n");
                }
            }

            Console.ReadKey();
        }
    }
}
