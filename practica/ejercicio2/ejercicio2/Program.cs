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
            // Declaración de variables: precio ingresado, IVA calculado y precio final.
            double precio, precioFinal, iva;

            // Solicita al usuario que ingrese el precio base.
            Console.WriteLine("ingrese el precio total:");
            precio = Convert.ToDouble(Console.ReadLine()); // Convierte la entrada a tipo double.

            // Muestra el precio ingresado.
            Console.WriteLine($"el precio total es: {precio}");

            // Llama a la función que calcula el IVA y guarda el resultado.
            iva = calculoiva(precio);

            // Llama a la función que suma el precio con el IVA para obtener el total.
            precioFinal = total(precio, iva);

            // Muestra el IVA calculado.
            Console.WriteLine($"IVA (15%) es:  {iva}");

            // Muestra el precio final con IVA incluido.
            Console.WriteLine($"Precio con IVA incluido:   {precioFinal}");

            // Espera una tecla antes de cerrar la consola.
            Console.ReadKey();
        }

        // Función que calcula el 15% de IVA sobre el precio ingresado.
        static double calculoiva(double precio)
        {
            double iva = precio * 0.15; // Multiplica el precio por 0.15 (15%).
            return iva; // Devuelve el valor del IVA.
        }

        // Función que suma el precio base con el IVA para obtener el total.
        static double total(double precio, double iva)
        {
            return precio + iva; // Devuelve el precio final.
        }
    }
}
