using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ejer_5_parametro
{
    internal class Programe 
    {
        // función que comprueba si una palabra es un palíndromo.
        // comparara la palabra con su versión invertida.
        public static bool EsPalindromo(string palabra)
        {
   
            // Convertir todo a minúsculas y filtra los espacios en blanco.
            string palabraNormal = new string(palabra.ToLower().Where(c => !Char.IsWhiteSpace(c)).ToArray());

            // logra inveritr la palabra normalizada.
            char[] arrayCaracteres = palabraNormal.ToCharArray();
            Array.Reverse(arrayCaracteres);
            string InvertirPalabra = new string(arrayCaracteres);

            // Comparara la palabra limpia con su versión invertida.
            return palabraNormal.Equals(InvertirPalabra);
        }

        static void Main(string[] args)
        {
            string palabra;
            Console.WriteLine("Escribir alguna palabra o frase para ver si es un palíndromo:");
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
