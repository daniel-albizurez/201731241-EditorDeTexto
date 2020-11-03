using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201731241_EditorDeTexto
{
    class Arbol
    {
        class Nodo
        {
            public static int numero { get; set; }
            public string etiqueta { get; set; }
            public int numeroNodo { get; set; }
            public Nodo padre { get; set; }
            public LinkedList<Nodo> hijos { get; }

            public Nodo(string valor)
            {
                this.etiqueta = valor;
                numeroNodo = numero;
                numero++;
                hijos = new LinkedList<Nodo>();
            }
            public void agregarHijo(string valor)
            {
                Nodo hijo = new Nodo(valor);
                hijo.padre = this;
                hijos.AddLast(hijo);
            }
        }
        Nodo raiz;
        Nodo actual;

        public Arbol(string valorRaiz)
        {
            Nodo.numero = 0;
            raiz = new Nodo(valorRaiz);
            raiz.padre = null;
            actual = raiz;
        }

        public void agregarHijo(string valor)
        {
            actual.agregarHijo(valor);
        }

        public void cambiar( string valor)
        {
            bool cambio = false;
            foreach (Nodo nodo in actual.hijos)
            {
                if (cambio = (nodo.etiqueta == valor && nodo.hijos.Count==0))
                {
                    actual = nodo;
                    break;
                }
            }
            if (!cambio && actual != raiz)
            {
                actual = actual.padre;
                cambiar(valor);
            }

        }

        public void imprimir()
        {
            imprimir(raiz);
        }
        private void imprimir(Nodo inicial)
        {
            foreach (Nodo item in inicial.hijos)
            {
                Console.WriteLine("Padre: " + item.padre.etiqueta + item.padre.numeroNodo + " Hijo: " + item.etiqueta + item.numeroNodo);
                imprimir(item);
            }
        }
    }
}
