using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer_de_parametro7
{
    internal class Program
    {
        // Este es el método principal donde comienza la ejecución del programa.
        static void Main(string[] arg)
        {
            // Solicita al usuario que ingrese su edad.
            Console.WriteLine("Por favor ingrese su edad");

            // Lee la entrada del usuario y la convierte a un número entero.
            int edad = Convert.ToInt32(Console.ReadLine());

            // Llama al método 'ClasificarEdad', pasando la variable 'edad' por valor.
            // Esto significa que se envía una copia del valor de 'edad' al método.
            ClasificarEdad(edad);
        }

        // Este método recibe un entero 'age' como parámetro por valor.
        // Cualquier cambio hecho a 'age' dentro de este método NO afectará a la variable original 'edad' en Main.
        static void ClasificarEdad(int age)
        {
            // Comprueba si la edad es inválida (menor o igual a 0).
            if (age <= 0)
            {
                Console.WriteLine("ERROR: edad invalida.");
            }
            // Comprueba si la edad es menor de 18 (menor de edad).
            else if (age < 18)
            {
                Console.WriteLine("Es menor de edad");
            }
            // Comprueba si la edad está entre 18 y 59 (mayor de edad).
            else if (age >= 18 && age < 60)
            {
                Console.WriteLine("Es una persona mayor de edad");
            }
            // Si ninguna de las condiciones anteriores se cumple, la edad debe ser 60 o más (adulto mayor).
            else // age >= 60
            {
                Console.WriteLine("Es una persona adulto mayor");
            }
        }
    }
}

