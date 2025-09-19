using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer_de_parametro7
{
    internal class Program
    {
        static void Main(string[] arg)
        {
            int edad;
            Console.WriteLine("Por favor ingresar edad");
            edad = Convert.ToInt32(Console.ReadLine());
            if (edad <= 0)
            {
                Console.WriteLine("ERROR edad invalida.");
            }

            else if (edad < 18)
            {
                Console.WriteLine("Es menor de edad");
            }
            else if (edad >= 18 && edad < 60)
            {
                Console.WriteLine("Es una persona mayor de edad");
            }
            else // edad >= 60
            {
                Console.WriteLine("Es una persona adulto mayor");
            }
        }
    }
}
