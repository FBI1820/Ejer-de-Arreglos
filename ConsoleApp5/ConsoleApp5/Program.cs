using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    /// <summary>
    /// Clase que representa una temperatura con su valor en Celsius y su conversión a Fahrenheit
    /// </summary>
    public class TemperaturaDia
    {
        public double Celsius { get; private set; }
        public double Fahrenheit { get; private set; }
        public int Dia { get; private set; }

        public TemperaturaDia(double celsius, int dia)
        {
            Celsius = celsius;
            Fahrenheit = ConvertirCelsiusAFahrenheit(celsius);
            Dia = dia;
        }

        public static double ConvertirCelsiusAFahrenheit(double celsius)
        {
            return (celsius * 9.0 / 5.0) + 32.0;
        }

        public override string ToString()
        {
            return $"Día {Dia}: {Celsius}°C = {Fahrenheit:F1}°F";
        }
    }

    /// <summary>
    /// Clase que maneja el análisis estadístico de temperaturas
    /// </summary>
    public class AnalizadorTemperaturas
    {
        private const double TEMPERATURA_MINIMA = -40.0;
        private const double TEMPERATURA_MAXIMA = 45.0;
        private const double UMBRAL_CALOR = 30.0;
        private const double UMBRAL_FRIO = 0.0;

        private List<TemperaturaDia> temperaturas;

        public AnalizadorTemperaturas()
        {
            temperaturas = new List<TemperaturaDia>();
        }

        public void AgregarTemperatura(double celsius, int dia)
        {
            temperaturas.Add(new TemperaturaDia(celsius, dia));
        }

        public bool ValidarRangoTemperatura(double temperatura)
        {
            return temperatura >= TEMPERATURA_MINIMA && temperatura <= TEMPERATURA_MAXIMA;
        }

        public void MostrarTemperaturas()
        {
            Console.WriteLine("\n📊 TEMPERATURAS REGISTRADAS");
            Console.WriteLine(new string('=', 40));
            foreach (var temp in temperaturas)
            {
                Console.WriteLine($"  {temp}");
            }
        }

        public void MostrarEstadisticas()
        {
            if (temperaturas.Count == 0)
            {
                Console.WriteLine("No hay datos de temperatura para analizar.");
                return;
            }

            Console.WriteLine("\n📈 ESTADÍSTICAS DE TEMPERATURAS");
            Console.WriteLine(new string('=', 40));

            var temperaturaMaxima = temperaturas.OrderByDescending(t => t.Celsius).First();
            var temperaturaMinima = temperaturas.OrderBy(t => t.Celsius).First();

            int diasBajoCero = temperaturas.Count(t => t.Celsius < UMBRAL_FRIO);
            int diasCalurosos = temperaturas.Count(t => t.Celsius > UMBRAL_CALOR);
            double promedio = temperaturas.Average(t => t.Celsius);
            double promedioFahrenheit = temperaturas.Average(t => t.Fahrenheit);

            Console.WriteLine($"🔥 Temperatura más alta: {temperaturaMaxima.Celsius}°C el día {temperaturaMaxima.Dia} ({temperaturaMaxima.Fahrenheit:F1}°F)");
            Console.WriteLine($"❄️  Temperatura más baja: {temperaturaMinima.Celsius}°C el día {temperaturaMinima.Dia} ({temperaturaMinima.Fahrenheit:F1}°F)");
            Console.WriteLine($"📊 Temperatura promedio: {promedio:F1}°C ({promedioFahrenheit:F1}°F)");
            Console.WriteLine($"🥶 Días bajo 0°C: {diasBajoCero}");
            Console.WriteLine($"🌡️  Días sobre {UMBRAL_CALOR}°C: {diasCalurosos}");
        }
    }

    /// <summary>
    /// Clase principal que gestiona la interacción con el usuario
    /// </summary>
    public class GestorTemperaturas
    {
        private AnalizadorTemperaturas analizador;
        private const int DIAS_SEMANA = 7;

        public GestorTemperaturas()
        {
            analizador = new AnalizadorTemperaturas();
        }

        public void IniciarAplicacion()
        {
            MostrarBienvenida();
            RegistrarTemperaturas();
            MostrarResultados();
        }

        private void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine("🌡️  CONVERSOR Y ANALIZADOR DE TEMPERATURAS");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Este programa registrará temperaturas diarias y las analizará estadísticamente.");
            Console.WriteLine("Rango válido: -40°C a 45°C");
            Console.WriteLine(new string('=', 50));
        }

        private void RegistrarTemperaturas()
        {
            for (int dia = 1; dia <= DIAS_SEMANA; dia++)
            {
                bool entradaValida = false;
                int intentos = 0;
                const int MAX_INTENTOS = 3;

                while (!entradaValida && intentos < MAX_INTENTOS)
                {
                    Console.Write($"\nIngrese la temperatura del día {dia} (°C): ");
                    
                    if (double.TryParse(Console.ReadLine(), out double temperatura))
                    {
                        if (analizador.ValidarRangoTemperatura(temperatura))
                        {
                            analizador.AgregarTemperatura(temperatura, dia);
                            entradaValida = true;
                            Console.WriteLine($"✅ Temperatura registrada: {temperatura}°C");
                        }
                        else
                        {
                            intentos++;
                            Console.WriteLine($"❌ Temperatura fuera de rango válido (-40°C a 45°C). Intentos restantes: {MAX_INTENTOS - intentos}");
                        }
                    }
                    else
                    {
                        intentos++;
                        Console.WriteLine($"❌ Entrada inválida. Por favor ingrese un número. Intentos restantes: {MAX_INTENTOS - intentos}");
                    }
                }

                if (!entradaValida)
                {
                    Console.WriteLine($"⚠️  Usando temperatura predeterminada de 20°C para el día {dia}");
                    analizador.AgregarTemperatura(20.0, dia);
                }
            }
        }

        private void MostrarResultados()
        {
            analizador.MostrarTemperaturas();
            analizador.MostrarEstadisticas();
            
            Console.WriteLine("\n✅ Proceso completado. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var gestor = new GestorTemperaturas();
                gestor.IniciarAplicacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
                Console.WriteLine("El programa se cerrará. Presione cualquier tecla...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}