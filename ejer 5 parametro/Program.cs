using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ejer_5_parametro
{
    internal class Program
    {
        // función comprueba si una palabra es un palíndromo.
        // Lo hace al comparar la palabra con su versión invertida.
        public static bool EsPalindromo(string palabra)
        {
   
            // Convierte todo a minúsculas y filtra los espacios en blanco.
            string palabraLimpia = new string(palabra.ToLower().Where(c => !Char.IsWhiteSpace(c)).ToArray());

            // logra inveritr la palabra normalizada.
            char[] arrayCaracteres = palabraLimpia.ToCharArray();
            Array.Reverse(arrayCaracteres);
            string palabraInvertida = new string(arrayCaracteres);

            // Comparara la palabra limpia con su versión invertida.
            return palabraLimpia.Equals(palabraInvertida);
        }

        static void Main(string[] args)
        {
            string palabra;
            Console.WriteLine("Escribe una palabra o frase para ver si es un palíndromo:");
            palabra = Console.ReadLine();

           
            if (EsPalindromo(palabra))
            {
                Console.WriteLine($"'{palabra}' es un palíndromo.");
            }
            else
            {
                Console.WriteLine($"'{palabra}' no lo es.");
            }

            Console.ReadLine();
        }
    }
}