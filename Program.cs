using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Mistake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What number factorial do you want to know?");
            int length = Convert.ToInt32(Console.ReadLine());
            Cancer mistake = new Cancer();
            mistake.FuckComputer(length);
            BigInteger total = new BigInteger(0);
            foreach (List<List<List<List<int>>>> i in mistake.Mistakes)
            {
                foreach (List<List<List<int>>> k in i)
                {
                    foreach (List<List<int>> j in k)
                    {
                        foreach (List<int> l in j)
                        {
                            foreach (int m in l) { total += m; }
                        }
                    }
                }
            }
            Console.WriteLine("Total of {0}!: {1}", length, total);
            Console.ReadLine();
        }
    }
}
