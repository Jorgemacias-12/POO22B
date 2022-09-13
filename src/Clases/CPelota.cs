namespace POO22B_MZJA.src.Clases
{

    // +------------------------------------------------------------------+
    // |  Clase que representa una pelota.                                |
    // |  MZJA 18/08/22.                                                  |
    // +------------------------------------------------------------------+

    public class CPelota
    {

        #region CLASS ATTRIBUTES

        private int Libras;
        private double Diametro;
        private int Tipo;
        private string Material;
        private string PaisOrigen;

        #endregion

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CPelota(double Diametro,
                       int Tipo, string Material,
                       string PaisOrigen)
        {
            Libras = 0;
            this.Diametro = Diametro;
            this.Tipo = Tipo;
            this.Material = Material;
            this.PaisOrigen = PaisOrigen;
        }

        // +------------------------------------------------------------------+
        // | Infla la pelota
        // +------------------------------------------------------------------+

        public CError Inflar(int Libras)
        {

            bool ponchada;

            ponchada = false;

            if (Libras > 6)
            {
                return new CError(4, 2);
                // return new CError(2, "Fuga detectada");
            }
            else
            {
                // TODO: Algoritmo de inflado
                this.Libras = Libras;

                if (ponchada)
                {
                    return new CError(2, 2);
                }
                else
                {
                    return new CError(0, 2);
                }

            }


        }

    }
}
