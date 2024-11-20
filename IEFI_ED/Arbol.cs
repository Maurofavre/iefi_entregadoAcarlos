using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEFI_ED
{
    internal class Arbol
    {
        public Nodo Raiz { get; set; }

        public Arbol()
        {
            Raiz = null;
        }

        public void Crear(Nodo nuevo)
        {
            if (Raiz == null)
            {
                Raiz = nuevo;
            }
            else
            {
                Insertar(nuevo);
            }
        }

        public void Insertar(Nodo nuevo)
        {
            if (Raiz != null)
            {
                Nodo aux = Raiz;
                Nodo ant = null;
                while (aux != null)
                {
                   ant = aux;
                    if (nuevo.Codigo < aux.Codigo)
                    {
                        aux = aux.Izquierdo;
                    } else{
                       
                        if (nuevo.Codigo > aux.Codigo )
                        {
                            aux = aux.Derecho;
                        }else{
                            MessageBox.Show("Codigo Con Datos Preexistentes" ,"Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                         }

                    }
                }
                if (nuevo.Codigo < ant.Codigo)
                {
                    ant.Izquierdo = nuevo;
                }
                if (nuevo.Codigo > ant.Codigo)
                {
                    ant.Derecho = nuevo;
                }
            }
            else
            {
                Crear(nuevo);
            }
        }

        public List<Nodo> Listar(Nodo raiz)
        {
            List<Nodo> nodos = new List<Nodo>();

            ListaRecursiva(raiz, nodos);

            return nodos;

        }

        private void ListaRecursiva(Nodo raiz, List<Nodo> nodos)
        {
            if (raiz.Izquierdo != null)
            {
                ListaRecursiva(raiz.Izquierdo, nodos);
            }

            nodos.Add(raiz);

            if (raiz.Derecho != null)
            {
                ListaRecursiva(raiz.Derecho, nodos);
            }
        }
    }
}
