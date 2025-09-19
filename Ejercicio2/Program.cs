// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main(string[] args)
    {
      
        PedirDatos();
        
    }

   

    static void PedirDatos()
    {
        Console.WriteLine("Ingrese la base del triangulo: ");
        double baseTriangulo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese la altura del triangulo: ");
        double alturaTriangulo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("El área del triángulo es: " + CalcularArea(baseTriangulo, alturaTriangulo));

    }
    static double CalcularArea(double baseTriangulo, double alturaTriangulo)
    {
        return (baseTriangulo * alturaTriangulo) / 2;
        
    }
}
