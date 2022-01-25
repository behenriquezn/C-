using System;

namespace Biblioteca.Negocio
{
    public class ClistaContrato
    {
        public ClistaContrato()
        {
        }

        public string NUMERO { get; set; }
        public DateTime CREACION { get; set; }
        public DateTime TERMINO { get; set; }
        public string RUTCLIENTE { get; set; }
        public string MODALIDAD { get; set; }
        public string TIPOEVENTO { get; set; }
        public DateTime FECHA_HORAINICIO { get; set; }
        public DateTime FECHA_HORATERMINO { get; set; }
        public int ASISTENTES { get; set; }
        public int PERSONAL_ADICIONAL { get; set; }
        public bool REALIZADO { get; set; }
        public double VALOR_TOTAL_CONTRATO { get; set; }
        public string OBSERVACIONES { get; set; }
    }
}