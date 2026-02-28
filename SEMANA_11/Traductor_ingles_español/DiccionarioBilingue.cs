using System.Collections.Generic;
using System.Linq;

namespace TraductorInglesEspanol
{
    public class DiccionarioBilingue
    {
        private Dictionary<string, string> diccionarioInglesEspanol;
        private Dictionary<string, string> diccionarioEspanolIngles;

        public DiccionarioBilingue()
        {
            diccionarioInglesEspanol = new Dictionary<string, string>();
            diccionarioEspanolIngles = new Dictionary<string, string>();
        }

        public void InicializarDiccionarioBase()
        {
            // Diccionario Inglés -> Español
            var palabrasBase = new Dictionary<string, string>
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino/forma"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño/a"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto/tema"},
                {"government", "gobierno"},
                {"company", "empresa/compañía"}
            };

            foreach (var item in palabrasBase)
            {
                AgregarPalabraInglesEspanol(item.Key, item.Value);
            }
        }

        public bool AgregarPalabraInglesEspanol(string ingles, string español)
        {
            ingles = ingles.ToLower().Trim();
            español = español.ToLower().Trim();

            if (!diccionarioInglesEspanol.ContainsKey(ingles))
            {
                diccionarioInglesEspanol.Add(ingles, español);
                
                // Agregar al diccionario inverso (manejar múltiples significados)
                string[] significados = español.Split('/');
                foreach (string significado in significados)
                {
                    string significadoLimpio = significado.Trim(); // CORREGIDO: cambio de significadoLimpo a significadoLimpio
                    if (!diccionarioEspanolIngles.ContainsKey(significadoLimpio))
                    {
                        diccionarioEspanolIngles.Add(significadoLimpio, ingles);
                    }
                }
                return true;
            }
            return false;
        }

        public bool AgregarPalabraEspanolIngles(string español, string ingles)
        {
            español = español.ToLower().Trim();
            ingles = ingles.ToLower().Trim();

            if (!diccionarioEspanolIngles.ContainsKey(español))
            {
                diccionarioEspanolIngles.Add(español, ingles);
                
                // Manejar múltiples significados en español (separados por /)
                if (español.Contains("/"))
                {
                    string[] significados = español.Split('/');
                    foreach (string significado in significados)
                    {
                        string significadoLimpio = significado.Trim();
                        if (!diccionarioInglesEspanol.ContainsKey(ingles))
                        {
                            // No agregamos automáticamente porque podría haber conflictos
                            // Esta parte se maneja mejor manualmente
                        }
                    }
                }
                else
                {
                    // También agregar al diccionario inverso inglés->español si no existe
                    if (!diccionarioInglesEspanol.ContainsKey(ingles))
                    {
                        diccionarioInglesEspanol.Add(ingles, español);
                    }
                }
                return true;
            }
            return false;
        }

        public string TraducirInglesEspanol(string palabra)
        {
            string palabraLimpia = palabra.ToLower().Trim();
            return diccionarioInglesEspanol.ContainsKey(palabraLimpia) 
                ? diccionarioInglesEspanol[palabraLimpia] 
                : null;
        }

        public string TraducirEspanolIngles(string palabra)
        {
            string palabraLimpia = palabra.ToLower().Trim();
            return diccionarioEspanolIngles.ContainsKey(palabraLimpia) 
                ? diccionarioEspanolIngles[palabraLimpia] 
                : null;
        }

        public bool ExisteEnIngles(string palabra)
        {
            return diccionarioInglesEspanol.ContainsKey(palabra.ToLower().Trim());
        }

        public bool ExisteEnEspanol(string palabra)
        {
            return diccionarioEspanolIngles.ContainsKey(palabra.ToLower().Trim());
        }

        public Dictionary<string, string> ObtenerDiccionarioInglesEspanol()
        {
            return new Dictionary<string, string>(diccionarioInglesEspanol);
        }

        public Dictionary<string, string> ObtenerDiccionarioEspanolIngles()
        {
            return new Dictionary<string, string>(diccionarioEspanolIngles);
        }

        public int TotalPalabras()
        {
            return diccionarioInglesEspanol.Count;
        }
    }
}