using System;
using System.Collections.Generic;
using TorneoFutbol.Models;
using TorneoFutbol.Services;
using TorneoFutbol.Utils;

namespace TorneoFutbol
{
    class Program
    {
        private static TorneoService _torneoService = new TorneoService();

        static void Main(string[] args)
        {
            Console.WriteLine("🏆 SISTEMA DE GESTIÓN DE TORNEO DE FÚTBOL 🏆");
            Console.WriteLine("============================================");

            int opcion;
            do
            {
                MostrarMenu();
                
                string entrada = Console.ReadLine();
                
                if (!Validaciones.ValidarOpcionMenu(entrada, out opcion, 0, 4))
                {
                    Validaciones.MostrarError("Debe ingresar un número válido entre 0 y 4.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ProcesarRegistroEquipo();
                        break;
                    case 2:
                        ProcesarAgregarJugador();
                        break;
                    case 3:
                        MostrarEquiposYJugadores();
                        break;
                    case 4:
                        ProcesarEliminarEquipo();
                        break;
                    case 0:
                        Validaciones.MostrarInfo("Programa finalizado. ¡Gracias por usar el sistema!");
                        break;
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. 📝 Registrar equipo");
            Console.WriteLine("2. 👤 Agregar jugador a un equipo");
            Console.WriteLine("3. 👥 Mostrar equipos y jugadores");
            Console.WriteLine("4. ❌ Eliminar equipo");
            Console.WriteLine("0. 🚪 Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void ProcesarRegistroEquipo()
        {
            Console.Write("Ingrese el nombre del equipo: ");
            string nombreEquipo = Console.ReadLine();

            var resultado = _torneoService.RegistrarEquipo(nombreEquipo);

            if (resultado.exito)
            {
                Validaciones.MostrarExito(resultado.mensaje);
            }
            else
            {
                Validaciones.MostrarError(resultado.mensaje);
            }
        }

        static void ProcesarAgregarJugador()
        {
            if (!_torneoService.HayEquiposRegistrados())
            {
                Validaciones.MostrarError("No hay equipos registrados. Primero debe registrar un equipo.");
                return;
            }

            Console.Write("Ingrese el nombre del equipo: ");
            string equipo = Console.ReadLine();

            Console.Write("Ingrese el nombre del jugador: ");
            string jugador = Console.ReadLine();

            var resultado = _torneoService.AgregarJugador(equipo, jugador);

            if (resultado.exito)
            {
                Validaciones.MostrarExito(resultado.mensaje);
            }
            else
            {
                Validaciones.MostrarError(resultado.mensaje);
            }
        }

        static void MostrarEquiposYJugadores()
        {
            var equipos = _torneoService.ObtenerTodosLosEquipos();

            Console.WriteLine("\n===== LISTA DE EQUIPOS =====");

            if (equipos.Count == 0)
            {
                Validaciones.MostrarInfo("No hay equipos registrados.");
                return;
            }

            foreach (var par in equipos)
            {
                Equipo equipo = par.Value;
                Console.WriteLine($"\n📌 {equipo}");

                if (!equipo.TieneJugadores())
                {
                    Console.WriteLine("   ⚠️ No tiene jugadores registrados.");
                }
                else
                {
                    foreach (var jugador in equipo.Jugadores)
                    {
                        Console.WriteLine($"   ⚽ {jugador}");
                    }
                }
            }
            
            Console.WriteLine($"\n📊 Total de equipos: {equipos.Count}");
        }

        static void ProcesarEliminarEquipo()
        {
            if (!_torneoService.HayEquiposRegistrados())
            {
                Validaciones.MostrarError("No hay equipos registrados.");
                return;
            }

            Console.Write("Ingrese el nombre del equipo a eliminar: ");
            string equipo = Console.ReadLine();

            Console.Write($"¿Está seguro de eliminar '{equipo}'? (s/n): ");
            string confirmacion = Console.ReadLine()?.ToLower();

            if (confirmacion == "s" || confirmacion == "si")
            {
                var resultado = _torneoService.EliminarEquipo(equipo);

                if (resultado.exito)
                {
                    Validaciones.MostrarExito(resultado.mensaje);
                }
                else
                {
                    Validaciones.MostrarError(resultado.mensaje);
                }
            }
            else
            {
                Validaciones.MostrarInfo("Operación cancelada.");
            }
        }
    }
}