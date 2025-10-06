using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reto 1: Conversor de temperaturas
            double[] temperatura = new double[7];
            double[] farenheit = new double[7];

            for(int i = 0; i < temperatura.Length; i++)
            {
                Console.WriteLine($"ingrese la temperatura del dia en celcius:{i+1}");
                try
                {
                    double temp = Convert.ToDouble(Console.ReadLine());
                    if (temp >= -40 && temp <= 45)
                    {
                        temperatura[i] = temp;
                        farenheit[i] = (temp * 9 / 5) + 32;
                    }
                    else
                    {
                        Console.WriteLine("temperatura fuera de rango(-40,45)");
                        i--;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor ingrese un número válido.");
                    i--;
                }
            }
            Console.WriteLine("temperaturas registradas");
            for(int i = 0;i < farenheit.Length;i++)
            {
                Console.WriteLine($"Día {i + 1}: {temperatura[i]}°C = {farenheit[i]}°F");
            }
            double maximo = temperatura.Max();
            int diaMaximo = Array.IndexOf(temperatura, maximo);
            Console.WriteLine($"\nLa temperatura más caliente fue {maximo}°C el día {diaMaximo + 1}");

            double minimo = temperatura.Min();
            int diaMinimo = Array.IndexOf(temperatura, minimo);
            Console.WriteLine($"La temperatura más fría fue {minimo}°C el día {diaMinimo + 1}");
            int contador = 0;
            int contador2 = 0;

            foreach (double tem in temperatura)
            {
                if (tem < 0)
                {
                    contador++;
                }
                else if (tem > 30)
                {
                    contador2++;
                }
            }

            Console.WriteLine($"Los días bajo 0°C fueron: {contador}");
            Console.WriteLine($"Los días arriba de 30°C fueron: {contador2}");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }   
    }
}

