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
            // Declaración de variables: num para el número ingresado, res para el resultado
            int num, res;

            // Solicita al usuario que ingrese un número entero.
            Console.WriteLine("ingrese un numero entero:");
            num = Convert.ToInt32(Console.ReadLine()); // Convierte la entrada a entero.

            // Llama a la función verificar y guarda el resultado en res.
            res = verificar(num);

            // Evalúa el resultado: si es 0, el número es par; si es 1, es impar.
            if (res == 0)
            {
                Console.WriteLine("es par");
            }
            else
            {
                Console.WriteLine("es impar");
            }

            // Espera una tecla antes de cerrar la consola.
            Console.ReadKey();
        }

        // Función que verifica si un número es par o impar.
        // Devuelve 0 si es par, 1 si es impar.
        static int verificar(int num)
        {
            // Si el número es divisible entre 2, es par.
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
