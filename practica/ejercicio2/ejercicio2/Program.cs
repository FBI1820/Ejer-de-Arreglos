using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double precio, precioFinal, iva;
            Console.WriteLine("ingrese el precio total:");
            precio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"el precio total es: {precio}");
            iva = calculoiva(precio);
            precioFinal = total(precio, iva);

            Console.WriteLine($"IVA (15%) es:  {iva}");
            Console.WriteLine($"Precio con IVA incluido:   {precioFinal}");

            Console.ReadKey();

        }
        static double calculoiva(double precio)
        {
            double iva = precio * 0.15;
            return iva;
            
        }
        static double total(double precio, double iva)
        {
            return precio + iva;
        }
    }
}
