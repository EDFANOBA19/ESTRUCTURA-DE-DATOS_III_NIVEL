namespace TraductorInglesEspanol
{
    public class DetectorIdioma
    {
        private DiccionarioBilingue diccionario;

        public DetectorIdioma(DiccionarioBilingue diccionario)
        {
            this.diccionario = diccionario;
        }

        public bool EsEspanol(string[] palabras)
        {
            int contadorEspanol = 0;
            int contadorIngles = 0;

            foreach (string palabra in palabras)
            {
                ProcesadorTexto procesador = new ProcesadorTexto();
                string palabraLimpia = procesador.LimpiarPalabra(palabra).ToLower();

                if (diccionario.ExisteEnEspanol(palabraLimpia))
                    contadorEspanol++;
                else if (diccionario.ExisteEnIngles(palabraLimpia))
                    contadorIngles++;
            }

            return contadorEspanol >= contadorIngles;
        }
    }
}