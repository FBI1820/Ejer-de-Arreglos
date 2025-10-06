using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    class Clinica
    {
        public int[] Edades = new int[20]; //Arreglo que contendra las edades de los 20 puestos diarios 
        public void RegistrarEdades()//Primer prosedimiento para llenar el arreglo
        {
            for (int i = 0; i < Edades.Length; i++)
            {
                Console.WriteLine($"Ingrese la edad del paciente {i + 1}: ");
                Edades[i] = int.Parse(Console.ReadLine()); //Me incluyo el parse?
                //Aqui ya se van registrando las edades de los pacientes 
            }
            
        }
        public void AnalizarEdades()
        {
            int ninos = 0;
            int jovenes = 0;
            int adultos = 0;
            int mayores = 0;
            for (int i = 0; i < Edades.Length; i++) //recorro de nuevo el cosito de codigo 
            {
                if (Edades[i] < 12)// ya aqui tenemos las sentencias de clasificacion de edades
                {
                    ninos++;
                }
                else if (Edades[i] >= 12 && Edades[i] <= 25)
                {
                    jovenes++;
                }
                else if (Edades[i] > 25 && Edades[i] <= 60)
                {
                    adultos++;
                }
                else
                {
                    mayores++;
                }
                if (mayores > 5)
                {
                    Console.WriteLine("Alerta: Más de 5 pacientes mayores de 60 años.");
                }

            }
            Console.WriteLine($"Niños: {ninos}");
            Console.WriteLine($"Jóvenes: {jovenes}");
            Console.WriteLine($"Adultos: {adultos}");
            Console.WriteLine($"Mayores: {mayores}");
            //Ahora la pregunta esta en donde irian los promedios
           

        }

        static void Main(string[] args)

        {
            Clinica clinica = new Clinica();
            clinica.RegistrarEdades();
            clinica.AnalizarEdades();
        }
    }
}
