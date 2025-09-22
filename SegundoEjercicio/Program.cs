// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main(string[] args)
    {
       
        int x;
     
        
        Console.WriteLine("Ingrese un número entero: ");
        x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("El valor ingresado es: " + x);
        static void Intercambiar(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("Después del intercambio, el valor de x es: " + x);
        } 

    }

   

    

   
}

