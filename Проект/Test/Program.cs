using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dll;

namespace lab
{
    class Program
    {     
        static void Main(string[] args)
        {

            int[,] graph = {
{0, 16, 13, 0, 0, 0},
{0, 0, 10, 12, 0, 0},
{0, 4, 0, 0, 14, 0 },
{0, 0, 9, 0, 0, 20 },
{0, 0, 0, 7, 0, 4  },
{0, 0, 0, 0, 0, 0  }
                    };

            //  Console.WriteLine( Dll.MaxFlowPreflowN3.maxFlow(graph, 0, 5));
             string way="";
            int[] a = way.Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.ReadKey();
        }
    }
}
