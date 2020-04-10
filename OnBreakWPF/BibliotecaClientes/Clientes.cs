using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClientes
{
    public class Clientes
    {
        public String Rut { get; set; }
        public String Razon { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Actividad { get; set; }
        public String Tipo{ get; set; }        
        public Clientes()
        {
            init();
        }
        public Clientes(String Rut)
        {
            this.Rut = Rut;
        }
        private void init()
        {
            Rut = String.Empty;
            Razon = String.Empty;
            Direccion = String.Empty;
            Telefono = String.Empty;
            Actividad = String.Empty;
            Tipo = String.Empty;
        }
    }
}
