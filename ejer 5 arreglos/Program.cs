using System;
using System.Collections.Generic;
using System.Linq;

namespace ejer_5_arreglos
{
    /// <summary>
    /// Clase que representa un paciente con su edad y categoría
    /// </summary>
    public class Paciente
    {
        public int Edad { get; private set; }
        public CategoriaEdad Categoria { get; private set; }

        public Paciente(int edad)
        {
            if (edad <= 0)
                throw new ArgumentException("La edad debe ser un número positivo", nameof(edad));

            Edad = edad;
            Categoria = ClasificarEdad(edad);
        }

        /// <summary>
        /// Clasifica la edad del paciente en categorías
        /// </summary>
        /// <param name="edad">Edad del paciente</param>
        /// <returns>Categoría de edad correspondiente</returns>
        private CategoriaEdad ClasificarEdad(int edad)
        {
            if (edad < 12)
                return CategoriaEdad.Nino;
            else if (edad <= 25)
                return CategoriaEdad.Joven;
            else if (edad <= 60)
                return CategoriaEdad.Adulto;
            else
                return CategoriaEdad.Mayor;
        }

        public override string ToString()
        {
            return $"Edad: {Edad} años ({Categoria})";
        }
    }

    /// <summary>
    /// Enumeración de categorías de edad
    /// </summary>
    public enum CategoriaEdad
    {
        Nino, Joven, Adulto, Mayor
    }

    /// <summary>
    /// Clase que gestiona la estadísticas de pacientes por categoría
    /// </summary>
    public class EstadisticasPacientes
    {
        private const int LIMITE_MAYORES_ALERTA = 5;
        private const int LIMITE_EDAD_MAYOR = 60;

        public int TotalPacientes { get; private set; }
        public int ContadorNinos { get; private set; }
        public int ContadorJovenes { get; private set; }
        public int ContadorAdultos { get; private set; }
        public int ContadorMayores { get; private set; }

        public double SumaEdadNinos { get; private set; }
        public double SumaEdadJovenes { get; private set; }
        public double SumaEdadAdultos { get; private set; }
        public double SumaEdadMayores { get; private set; }

        public void AgregarPaciente(Paciente paciente)
        {
            TotalPacientes++;

            switch (paciente.Categoria)
            {
                case CategoriaEdad.Nino:
                    ContadorNinos++;
                    SumaEdadNinos += paciente.Edad;
                    break;
                case CategoriaEdad.Joven:
                    ContadorJovenes++;
                    SumaEdadJovenes += paciente.Edad;
                    break;
                case CategoriaEdad.Adulto:
                    ContadorAdultos++;
                    SumaEdadAdultos += paciente.Edad;
                    break;
                case CategoriaEdad.Mayor:
                    ContadorMayores++;
                    SumaEdadMayores += paciente.Edad;
                    break;
            }
        }

        public bool DebeMostrarAlertaMayores()
        {
            return ContadorMayores > LIMITE_MAYORES_ALERTA;
        }

        public double ObtenerPromedioPorCategoria(CategoriaEdad categoria)
        {
            return categoria switch
            {
                CategoriaEdad.Nino => ContadorNinos > 0 ? SumaEdadNinos / ContadorNinos : 0,
                CategoriaEdad.Joven => ContadorJovenes > 0 ? SumaEdadJovenes / ContadorJovenes : 0,
                CategoriaEdad.Adulto => ContadorAdultos > 0 ? SumaEdadAdultos / ContadorAdultos : 0,
                CategoriaEdad.Mayor => ContadorMayores > 0 ? SumaEdadMayores / ContadorMayores : 0,
                _ => 0
            };
        }

        public double ObtenerPromedioTotal()
        {
            double sumaTotal = SumaEdadNinos + SumaEdadJovenes + SumaEdadAdultos + SumaEdadMayores;
            return TotalPacientes > 0 ? sumaTotal / TotalPacientes : 0;
        }
    }

    /// <summary>
    /// Clase principal que gestiona el sistema de la clínica
    /// </summary>
    public class SistemaClinica
    {
        private const int NUMERO_PACIENTES = 20;
        private const int EDAD_MINIMA = 1;
        private const int EDAD_MAXIMA = 120;

        private List<Paciente> pacientes;
        private EstadisticasPacientes estadisticas;

        public SistemaClinica()
        {
            pacientes = new List<Paciente>();
            estadisticas = new EstadisticasPacientes();
        }

        public void IniciarSistema()
        {
            MostrarBienvenida();
            RegistrarPacientes();
            AnalizarYMostrarResultados();
        }

        private void MostrarBienvenida()
        {
            Console.Clear();
            Console.WriteLine("🏥 SISTEMA DE ANÁLISIS DE EDADES - CLÍNICA");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Se registrarán las edades de {NUMERO_PACIENTES} pacientes para análisis estadístico.");
            Console.WriteLine($"Rango de edad permitido: {EDAD_MINIMA} a {EDAD_MAXIMA} años");
            Console.WriteLine(new string('=', 50));
        }

        private void RegistrarPacientes()
        {
            for (int i = 0; i < NUMERO_PACIENTES; i++)
            {
                bool entradaValida = false;
                int intentos = 0;
                const int MAX_INTENTOS = 3;

                while (!entradaValida && intentos < MAX_INTENTOS)
                {
                    Console.Write($"\nIngrese la edad del paciente {i + 1}: ");

                    if (int.TryParse(Console.ReadLine(), out int edad))
                    {
                        if (edad >= EDAD_MINIMA && edad <= EDAD_MAXIMA)
                        {
                            try
                            {
                                var paciente = new Paciente(edad);
                                pacientes.Add(paciente);
                                estadisticas.AgregarPaciente(paciente);
                                entradaValida = true;
                                Console.WriteLine($"✅ Paciente registrado: {paciente}");
                            }
                            catch (ArgumentException ex)
                            {
                                intentos++;
                                Console.WriteLine($"❌ {ex.Message}. Intentos restantes: {MAX_INTENTOS - intentos}");
                            }
                        }
                        else
                        {
                            intentos++;
                            Console.WriteLine($"❌ Edad fuera de rango ({EDAD_MINIMA}-{EDAD_MAXIMA}). Intentos restantes: {MAX_INTENTOS - intentos}");
                        }
                    }
                    else
                    {
                        intentos++;
                        Console.WriteLine($"❌ Entrada inválida. Ingrese un número entre {EDAD_MINIMA} y {EDAD_MAXIMA}. Intentos restantes: {MAX_INTENTOS - intentos}");
                    }
                }

                if (!entradaValida)
                {
                    int edadDefault = 25;
                    var pacienteDefault = new Paciente(edadDefault);
                    pacientes.Add(pacienteDefault);
                    estadisticas.AgregarPaciente(pacienteDefault);
                    Console.WriteLine($"⚠️  Usando edad predeterminada de {edadDefault} años para el paciente {i + 1}");
                }
            }
        }

        private void AnalizarYMostrarResultados()
        {
            Console.WriteLine("\n📊 ANÁLISIS ESTADÍSTICO DE PACIENTES");
            Console.WriteLine(new string('=', 50));

            MostrarAlertas();
            MostrarConteoPorCategoria();
            MostrarPromedios();

            Console.WriteLine("\n✅ Análisis completado. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        private void MostrarAlertas()
        {
            if (estadisticas.DebeMostrarAlertaMayores())
            {
                Console.WriteLine("\n⚠️  ALERTA MÉDICA");
                Console.WriteLine($"   Más de 5 pacientes mayores de 60 años ({estadisticas.ContadorMayores} pacientes)");
                Console.WriteLine("   Recomendación: Programar controles geriátricos");
                Console.WriteLine();
            }
        }

        private void MostrarConteoPorCategoria()
        {
            Console.WriteLine("📋 CONTEO DE PACIENTES POR CATEGORÍA");
            Console.WriteLine($"  👶 Niños (0-11 años): {estadisticas.ContadorNinos} pacientes");
            Console.WriteLine($"  🧑 Jóvenes (12-25 años): {estadisticas.ContadorJovenes} pacientes");
            Console.WriteLine($"  👨 Adultos (26-60 años): {estadisticas.ContadorAdultos} pacientes");
            Console.WriteLine($"  👴 Mayores (>60 años): {estadisticas.ContadorMayores} pacientes");
            Console.WriteLine($"  📊 Total: {estadisticas.TotalPacientes} pacientes");
        }

        private void MostrarPromedios()
        {
            Console.WriteLine("\n📈 PROMEDIOS DE EDAD");
            Console.WriteLine($"  📊 Promedio general: {estadisticas.ObtenerPromedioTotal():F1} años");
            Console.WriteLine($"  👶 Promedio niños: {estadisticas.ObtenerPromedioPorCategoria(CategoriaEdad.Nino):F1} años");
            Console.WriteLine($"  🧑 Promedio jóvenes: {estadisticas.ObtenerPromedioPorCategoria(CategoriaEdad.Joven):F1} años");
            Console.WriteLine($"  👨 Promedio adultos: {estadisticas.ObtenerPromedioPorCategoria(CategoriaEdad.Adulto):F1} años");
            Console.WriteLine($"  👴 Promedio mayores: {estadisticas.ObtenerPromedioPorCategoria(CategoriaEdad.Mayor):F1} años");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sistema = new SistemaClinica();
                sistema.IniciarSistema();
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