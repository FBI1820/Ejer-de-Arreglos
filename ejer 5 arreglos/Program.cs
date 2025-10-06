using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_5_arreglos
{
    namespace Ejercicio5
    {
        class Clinica
        {
            public int[] Edades = new int[20]; // array para registro de edades de 20 pacientes 

            public void RegistrarEdades() // 
            {
                for (int i = 0; i < Edades.Length; i++)
                {
                    int edad;
                    bool validInput = false;
                    do
                    {
                        Console.Write($"Ingrese la edad del paciente {i + 1}: ");
                        if (int.TryParse(Console.ReadLine(), out edad) && edad > 0)
                        {
                            Edades[i] = edad;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Por favor, ingrese una edad positiva.");
                        }
                    } while (!validInput);
                }
            }

            public void AnalizarEdades()
            {
                // Contadores para cada categoría (para el conteo y el promedio)
                int ninos = 0;
                int jovenes = 0;
                int adultos = 0;
                int mayores = 0;

                // variable para la suma de edades. Usamos 'double' para los cálculos de promedio.
                double sumaNinos = 0;
                double sumaJovenes = 0;
                double sumaAdultos = 0;
                double sumaMayores = 0;
                double sumaTotalEdades = 0;


                for (int i = 0; i < Edades.Length; i++) // Recorrido del arreglo de edades
                {
                    int edadActual = Edades[i];
                    sumaTotalEdades += edadActual; // Suma al total general

                    // acumulación por categoría
                    if (edadActual < 12)
                    {
                        ninos++;
                        sumaNinos += edadActual;
                    }
                    else if (edadActual >= 12 && edadActual <= 25)
                    {
                        jovenes++;
                        sumaJovenes += edadActual;
                    }
                    else if (edadActual > 25 && edadActual <= 60)
                    {
                        adultos++;
                        sumaAdultos += edadActual;
                    }
                    else
                    {
                        mayores++;
                        sumaMayores += edadActual;
                    }
                }

                // Alerta (se muestra una sola vez al final)
                if (mayores > 5)
                {
                    Console.WriteLine("\n*** ALERTA: Más de 5 pacientes mayores de 60 años. ***");
                }

                Console.WriteLine("\n--- Conteo de Pacientes por Categoría ---");
                Console.WriteLine($"Niños: {ninos}");
                Console.WriteLine($"Jóvenes: {jovenes}");
                Console.WriteLine($"Adultos: {adultos}");
                Console.WriteLine($"Mayores: {mayores}");

            //promedios

                Console.WriteLine("\n--- Promedios de Edad ---");

                double promedioTotal = Edades.Length > 0 ? sumaTotalEdades / Edades.Length : 0;
                Console.WriteLine($"Promedio de Edad Total: {promedioTotal:F2}"); 

                // Promedios por Categoría
                // Usamos un operador ternario para evitar la división por cero si la cuenta es 0.
                double promedioNinos = ninos > 0 ? sumaNinos / ninos : 0;
                double promedioJovenes = jovenes > 0 ? sumaJovenes / jovenes : 0;
                double promedioAdultos = adultos > 0 ? sumaAdultos / adultos : 0;
                double promedioMayores = mayores > 0 ? sumaMayores / mayores : 0;

                Console.WriteLine($"Promedio de Edad Niños: {promedioTotal:F2}");
                Console.WriteLine($"Promedio de Edad Jóvenes: {promedioJovenes:F2}");
                Console.WriteLine($"Promedio de Edad Adultos: {promedioAdultos:F2}");
                Console.WriteLine($"Promedio de Edad Mayores: {promedioMayores:F2}");
            }

            static void Main(string[] args)
            {
                Clinica clinica = new Clinica();
                clinica.RegistrarEdades();
                clinica.AnalizarEdades();

                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}