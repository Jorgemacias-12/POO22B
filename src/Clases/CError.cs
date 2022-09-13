namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un error                                   |
    // |  MZJA 23/08/22.                                                  |
    // +------------------------------------------------------------------+
    public class CError
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        #region CLASS_ATRIBUTES
        private int IdError;
        private int IdIdioma;
        private string Mensaje;
        #endregion 

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CError(int Codigo, int IdIdioma)
        {
            IdError = Codigo;
            this.IdIdioma = IdIdioma;
        }

        // +------------------------------------------------------------------+
        // |  Obtiene el id del error                                         |
        // +------------------------------------------------------------------+
        public int GetIdError()
        {
            return IdError;
        }

        // +------------------------------------------------------------------+
        // |  Obtiene el id del idioma                                        |
        // +------------------------------------------------------------------+

        public int GetIdIdioma()
        {
            return IdIdioma;
        }

        // +------------------------------------------------------------------+
        // |  Obtiene el código de mensaje                                    |
        // +------------------------------------------------------------------+
        public string GetMensaje()
        {

            string Mensaje;

            Mensaje = string.Empty;

            if (IdIdioma == 1)
            {
                switch (IdError)
                {
                    case 0:
                        Mensaje = "Pelota inflada con éxito";
                        break;

                    case 1:
                        Mensaje = "No se pudo inflar"; // Genérico
                        break;

                    case 2:
                        Mensaje = "La pelota esta ponchada"; // Especifico
                        break;

                    case 3:
                        Mensaje = "Válvula defectuosa"; // Especifico 2
                        break;

                    case 4:
                        Mensaje = "Inflado excedido."; // Especifico 3
                        break;

                    default:
                        Mensaje = "Ocurriió un error al intentar inflar la pelota."; // No documentado
                        break;
                }
            }

            if (IdIdioma == 2)
            {
                switch (IdError)
                {
                    case 0:
                        Mensaje = "Successfully inflated ball";
                        break;

                    case 1:
                        Mensaje = "Can't inflate ball"; // Genérico
                        break;

                    case 2:
                        Mensaje = "Ball is struck out"; // Especifico
                        break;

                    case 3:
                        Mensaje = "Defective valve"; // Especifico 2
                        break;

                    case 4:
                        Mensaje = "Overinflated ball"; // Especifico 3
                        break;

                    default:
                        Mensaje = "An error ocurred while trying to inflate the ball"; // No documentado
                        break;
                }
            }

            return Mensaje;
        }

    }
}
