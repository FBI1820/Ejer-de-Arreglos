using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, res;
            Console.WriteLine("ingrese un numero entero:");
            num = Convert.ToInt32(Console.ReadLine());
            res = verificar(num);

            if (res == 0)
            {
                Console.WriteLine("es par");
            }
            else
            {
                Console.WriteLine("es impar");
            }
            Console.ReadKey();


        }

        static int verificar(int num)
        {
          if (num % 2 == 0)
            {
                return 0;
            }
          else
            { 
                return 1;
            }
        }
    }
}
