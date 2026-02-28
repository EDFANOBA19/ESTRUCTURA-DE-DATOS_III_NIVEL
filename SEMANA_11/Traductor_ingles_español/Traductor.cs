using System.Collections.Generic;

namespace TraductorInglesEspanol
{
    public class Traductor
    {
        private DiccionarioBilingue diccionario;
        private DetectorIdioma detectorIdioma;
        private ProcesadorTexto procesador;

        public Traductor(DiccionarioBilingue diccionario)
        {
            this.diccionario = diccionario;
            this.detectorIdioma = new DetectorIdioma(diccionario);
            this.procesador = new ProcesadorTexto();
        }

        public string TraducirFrase(string frase)
        {
            if (string.IsNullOrWhiteSpace(frase))
                return "";

            string[] palabras = procesador.SepararPalabras(frase);
            bool esEspanol = detectorIdioma.EsEspanol(palabras);
            List<string> palabrasTraducidas = new List<string>();

            foreach (string palabra in palabras)
            {
                string palabraLimpia = procesador.LimpiarPalabra(palabra);
                string signosPuntuacion = procesador.ObtenerSignosPuntuacion(palabra);
                
                string traduccion = null;

                if (esEspanol)
                {
                    traduccion = diccionario.TraducirEspanolIngles(palabraLimpia);
                }
                else
                {
                    traduccion = diccionario.TraducirInglesEspanol(palabraLimpia);
                }

                if (traduccion != null)
                {
                    palabrasTraducidas.Add(traduccion + signosPuntuacion);
                }
                else
                {
                    palabrasTraducidas.Add(palabra);
                }
            }

            return procesador.UnirPalabras(palabrasTraducidas.ToArray());
        }

        public string ObtenerIdiomaDetectado(string frase)
        {
            if (string.IsNullOrWhiteSpace(frase))
                return "Desconocido";

            string[] palabras = procesador.SepararPalabras(frase);
            return detectorIdioma.EsEspanol(palabras) ? "Español" : "Inglés";
        }
    }
}