using System.Collections.Generic;
using System.Linq;

namespace TraductorInglesEspanol
{
    public class ProcesadorTexto
    {
        public string[] SepararPalabras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new string[0];

            return texto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string LimpiarPalabra(string palabra)
        {
            return new string(palabra.Where(c => !char.IsPunctuation(c)).ToArray());
        }

        public string ObtenerSignosPuntuacion(string palabra)
        {
            return new string(palabra.Where(c => char.IsPunctuation(c)).ToArray());
        }

        public string UnirPalabras(string[] palabras)
        {
            return string.Join(" ", palabras);
        }
    }
}