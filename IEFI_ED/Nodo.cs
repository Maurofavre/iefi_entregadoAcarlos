using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEFI_ED
{
    internal class Nodo
    {
        public int Codigo { get; set; }
        public String Nombre { get; set; }
        public String Tipo { get; set; }
        public String Rango{ get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo()
        {
            Codigo = 0;
            Nombre = "";
            Tipo = "";
           Rango = "";
             Izquierdo = null;
            Derecho = null;
        }
    }
}
