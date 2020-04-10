using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class Contrato
    {
        public String NumeroContraro { get; set; }
        public String Creacion { get; set; }
        public String Termino { get; set;}
        public String FechaHoraIni { get; set; }
        public String FechaHoraTer { get; set; }
        public String DireContrato { get; set; }  
        public String EstadoVig { get; set; }
        public String Tipo { get; set; }
        public String Observaciones { get; set; }

        public Contrato()
        {
            init();
        }
        public Contrato(String num)
        {
            NumeroContraro = num;
        }
        private void init()
        {
            NumeroContraro = String.Empty;
            Creacion = String.Empty;
            Termino = String.Empty;
            FechaHoraIni=String.Empty;
            FechaHoraTer = String.Empty;
            DireContrato = String.Empty;
            EstadoVig = null;
            Tipo = String.Empty;
        }
    }  
}
