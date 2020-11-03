using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class AFD
{
/*    private int[] estados = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                              10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                              20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
                              30, 31
    };*/
    private string[] tipos = { "entero", "decimal", "cadena", "booleano", "caracter" };
    public string[] reservadas = {
        "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO", "principal"
            , "leer", "imprimir"
    };
    private string[] boolean = { "verdadero", "falso" };
    private int inicial = 0;

    //Listas que contienen los estados finales y una descripcion de la cadena resultante
    private SortedList<int, string> finales = new SortedList<int, string>();
    private SortedList<int, string> colores = new SortedList<int, string>();

    // Diccionario para almacenar las transiciones, la llave corresponde al estado actual
    // Los valores son diccionarios que representan las transiciones en la forma (caracter, estado resultante)
    private Dictionary<int, Dictionary<char, int>> delta = new Dictionary<int, Dictionary<char, int>>();

    //Diccionario que almacenan las transiciones individuales de cada estado
    private Dictionary<char, int> d0 = new Dictionary<char, int>();
    private Dictionary<char, int> d1 = new Dictionary<char, int>();
    private Dictionary<char, int> d2 = new Dictionary<char, int>();
    private Dictionary<char, int> d3 = new Dictionary<char, int>();
    private Dictionary<char, int> d4 = new Dictionary<char, int>();
    private Dictionary<char, int> d5 = new Dictionary<char, int>();
    private Dictionary<char, int> d6 = new Dictionary<char, int>();
    private Dictionary<char, int> d7 = new Dictionary<char, int>();
    private Dictionary<char, int> d8 = new Dictionary<char, int>();
    private Dictionary<char, int> d9 = new Dictionary<char, int>();
    private Dictionary<char, int> d10 = new Dictionary<char, int>();
    private Dictionary<char, int> d11 = new Dictionary<char, int>();
    private Dictionary<char, int> d12 = new Dictionary<char, int>();
    private Dictionary<char, int> d13 = new Dictionary<char, int>();
    private Dictionary<char, int> d14 = new Dictionary<char, int>();
    private Dictionary<char, int> d15 = new Dictionary<char, int>();
    private Dictionary<char, int> d16 = new Dictionary<char, int>();
    private Dictionary<char, int> d17 = new Dictionary<char, int>();
    private Dictionary<char, int> d18 = new Dictionary<char, int>();
    private Dictionary<char, int> d19 = new Dictionary<char, int>();
    private Dictionary<char, int> d20 = new Dictionary<char, int>();
    private Dictionary<char, int> d21 = new Dictionary<char, int>();
    private Dictionary<char, int> d22 = new Dictionary<char, int>();
    private Dictionary<char, int> d23 = new Dictionary<char, int>();
    private Dictionary<char, int> d24 = new Dictionary<char, int>();
    private Dictionary<char, int> d25 = new Dictionary<char, int>();
    private Dictionary<char, int> d26 = new Dictionary<char, int>();
    private Dictionary<char, int> d27 = new Dictionary<char, int>();
    private Dictionary<char, int> d28 = new Dictionary<char, int>();
    private Dictionary<char, int> d29 = new Dictionary<char, int>();
    private Dictionary<char, int> d30 = new Dictionary<char, int>();
    private Dictionary<char, int> d31 = new Dictionary<char, int>();
    private Dictionary<char, int> d32 = new Dictionary<char, int>();
    private Dictionary<char, int> d33 = new Dictionary<char, int>();
    private Dictionary<char, int> d34 = new Dictionary<char, int>();
    private Dictionary<char, int> dError = new Dictionary<char, int>();

    //Lista que almacena los tokens encontrados, el tipo, fila y columna del mismo
    private ArrayList resultados = new ArrayList();

    public AFD()
    {
        //Se definen las transiciones individuales de cada estado
        d0.Add('+', 1);
        d0.Add('d', 3);
        d0.Add('-', 6);
        d0.Add('l', 8);
        d0.Add('/', 10);
        d0.Add('=', 16);
        d0.Add('!', 18);
        d0.Add('*', 19);
        d0.Add('<', 20);
        d0.Add('>', 22);
        d0.Add('\"', 23);
        d0.Add('|', 26);
        d0.Add('&', 28);
        d0.Add('(', 30);
        d0.Add(')', 30);
        d0.Add('{', 30);
        d0.Add('}', 30);
        d0.Add(';', 31);
        d0.Add(',', 32);
        d0.Add('_', 33);

        d1.Add('+', 2);

        d3.Add('d', 3);
        d3.Add('.', 4);

        d4.Add('d', 5);

        d5.Add('d', 5);

        d6.Add('-', 7);

        d8.Add('l', 34);

        d9.Add('l', 9);
        d9.Add('d', 9);
        d9.Add('_', 9);

        d10.Add('/', 11);
        d10.Add('*', 12);

        d11.Add('a', 11);

        d12.Add('a', 13);
        d12.Add('*', 14);

        d13.Add('a', 13);
        d13.Add('*', 14);

        d14.Add('a', 13);
        d14.Add('/', 15);

        d16.Add('=', 17);

        d18.Add('=', 17);

        d20.Add('=', 21);

        d22.Add('=', 21);

        d23.Add('a', 24);
        d23.Add('\"', 25);

        d24.Add('\"', 25);
        d24.Add('a', 24);

        d26.Add('|', 27);

        d28.Add('&', 29);

        d33.Add('d', 9);
        d33.Add('l', 9);

        d34.Add('l', 34);

        dError.Add('a', -1);

        // Se agregan las transiciones al conjunto de transiciones
        delta.Add(0, d0);
        delta.Add(1, d1);
        delta.Add(2, d2);
        delta.Add(3, d3);
        delta.Add(4, d4);
        delta.Add(5, d5);
        delta.Add(6, d6);
        delta.Add(7, d7);
        delta.Add(8, d8);
        delta.Add(9, d9);
        delta.Add(10, d10);
        delta.Add(11, d11);
        delta.Add(12, d12);
        delta.Add(13, d13);
        delta.Add(14, d14);
        delta.Add(15, d15);
        delta.Add(16, d16);
        delta.Add(17, d17);
        delta.Add(18, d18);
        delta.Add(19, d19);
        delta.Add(20, d20);
        delta.Add(21, d21);
        delta.Add(22, d22);
        delta.Add(23, d23);
        delta.Add(24, d24);
        delta.Add(25, d25);
        delta.Add(26, d26);
        delta.Add(27, d27);
        delta.Add(28, d28);
        delta.Add(29, d29);
        delta.Add(30, d30);
        delta.Add(31, d31);
        delta.Add(32, d32);
        delta.Add(33, d33);
        delta.Add(34, d34);
        delta.Add(-1, dError);

        // Se agregan los estados finales y el tipo de token al que correspondern
        finales.Add(1, "operador aritmectico");
        finales.Add(2, "operador aritmectico");
        finales.Add(6, "operador aritmectico");
        finales.Add(7, "operador aritmectico");
        finales.Add(10, "operador aritmectico");
        finales.Add(19, "operador aritmectico");
        finales.Add(3, "int");
        finales.Add(5, "double");
        finales.Add(8, "char");
        finales.Add(9, "id");
        finales.Add(11, "comentario");
        finales.Add(15, "comentario mult");
        finales.Add(16, "asignacion");
        finales.Add(17, "operador relacional");
        finales.Add(20, "operador relacional");
        finales.Add(21, "operador relacional");
        finales.Add(22, "operador relacional");
        finales.Add(18, "operador logico");
        finales.Add(27, "operador logico");
        finales.Add(29, "operador logico");
        finales.Add(25, "str");
        finales.Add(30, "agrupacion");
        finales.Add(31, "fin sentencia");
        finales.Add(32, "coma");
        finales.Add(34, "reservada");

        // Se le asigna un color a cada estado final
        colores.Add(1, "blue");
        colores.Add(2, "blue");
        colores.Add(6, "blue");
        colores.Add(7, "blue");
        colores.Add(10, "blue");
        colores.Add(19, "blue");
        colores.Add(3, "mediumOrchid");
        colores.Add(5, "lightSkyblue");
        colores.Add(8, "brown");
        colores.Add(9, "black");
        colores.Add(11, "red");
        colores.Add(12, "red");
        colores.Add(13, "red");
        colores.Add(14, "red");
        colores.Add(15, "red");
        colores.Add(16, "magenta");
        colores.Add(17, "blue");
        colores.Add(20, "blue");
        colores.Add(21, "blue");
        colores.Add(22, "blue");
        colores.Add(18, "blue");
        colores.Add(27, "blue");
        colores.Add(29, "blue");
        colores.Add(23, "gray");
        colores.Add(24, "gray");
        colores.Add(25, "gray");
        colores.Add(30, "blue");
        colores.Add(31, "magenta");
        colores.Add(32, "black");
    }

    //Metodo que realiza el analisis de un texto, caracter por caracter
    public ArrayList Analizar(string texto)
    {
        //Se vacia la lista de resultados, para poder contener nuevos resultados
        resultados.Clear();
        int estadoActual = inicial;
        // Variable que almacena el estado anterior a
        int estadoAnterior = inicial;
        // Fila que se analiza
        int fila = 1;
        // Posicion general dentro del texto
        int posicion = 0;
        // Columna dentro de la fila que se analiza
        int columna = 1;
        // El token que se almacena en este momento
        string token = "";
        // Caracter que esta siendo analizado
        char caracter;

        /* Mientras la posicion sea menor al tamaño del texto se realiza el analisis
         * Se toma el caracter en la posicion actual
         * estadoAnterior almacen el estadoActual antes de realizar la transicion
         * Se cambia el estadoActual, utilizando el metodo CambiarEstado, enviando el estadoActual y el caracter actual
         * 
         * Si el caracter es un espacio o salto de linea
         *  Se evalua si la cadena que se ha evaluado esta vacia
         *      Sino se agrega a los resultados, utilizando el estadoAnterior como stado final, y el token se vuelve vacio
         *  Se aumenta la columna (Si es un salto de linea se le asigna el valor 1)
         *  Se aumenta la posicion
         *  Si es un salto de linea se aumenta la fila
         *  Al estadoActual se le asigna el estado inicial para comenzar el analisis de un nuevo token
         *  Y se reinicia el ciclo, sin analizar el caracter
         *  
         *  El analisis se realiza hasta encontrar un error
         *  
         *  Si el estadoActual tienene valor -1 entonces 
         *      se evalua si el estadoAnterior es un estadoFinal y  no es un error
         *          en ese caso se agrega a los resultados el token que habia sido evaluado hasta ese momento,
         *          utilizando el estadoAnterior como estado final
         *          como no se sabe si el caracter encontrado es un error, se resta una posicion
         *          y se asigna el estado inicial al estadoActual para poder realizar el analisis
         *          del caracter que sigue al token hallado
         *      Sino se agrega el caracter al token que esta siendo evaluado
         *  Sino se agrega el caracter al token que esta siendo evaluado
         *  
         * Se aumenta la posicion y la columna y se repite
         * Al terminar el ciclo se agrega el ultimo token que llego a ser evaluado, tomando el estadoActual como final
        */
        while (posicion < texto.Length)
        {
            caracter = texto.ElementAt(posicion);
            estadoAnterior = estadoActual;
            estadoActual = CambiarEstado(estadoActual, caracter);
            if (caracter == ' ' || caracter == '\n')
            {
                //Si el estado fuera de comentario se ignora
                if (estadoActual != 11 && estadoActual != 24 && estadoActual != 13)
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        ListarToken(token, estadoAnterior, fila, columna, posicion);
                    }
                    token = "";
                    estadoActual = inicial;
                }
                columna++;
                posicion++;
                if (estadoActual == 11 || estadoActual == 24)
                {
                    token += caracter;
                }
                if (caracter == '\n')
                {
                    fila++;
                    columna = 1;
                    if (estadoActual == 13)
                    {
                        token += caracter;
                    }
                    else if (estadoActual == 11)
                    {
                        ListarToken(token, estadoAnterior, fila, columna, posicion);
                        token = "";
                        estadoActual = inicial;
                    }
                }
                continue;
            }
            else
            {
                if (estadoActual == -1)
                {
                    if (finales.ContainsKey(estadoAnterior) && estadoAnterior != -1)
                    {
                        ListarToken(token, estadoAnterior, fila, columna, posicion);
                        token = "";
                        posicion--;
                        estadoActual = 0;
                    }
                    else
                    {
                        token += caracter;
                    }
                }
                else
                {
                    token += caracter;
                }
                posicion++;
                columna++;

            }
        }
        if (!string.IsNullOrEmpty(token))
        {
            ListarToken(token, estadoActual, fila, columna, posicion);
            token = "";
        }
        return resultados;
    }

    public void ListarToken(string token, int estadoFinal, int fila, int columna, int posicion)
    {
        string color =
        colores.TryGetValue(estadoFinal, out color) ? color : "black";
        string tipo = Encontrado(estadoFinal);
        if (estadoFinal == 34)
        {
            if (reservadas.Contains(token) || tipos.Contains(token))
            {
                color = "green";
                if (tipos.Contains(token))
                {
                    tipo = "tipo";
                }
                else
                {
                    tipo = "palabra reservada";
                }
            }
            else if (boolean.Contains(token))
            {
                color = "orange";
                tipo = "boolean";
            } else
            {
                tipo = "error";
                color = " black";
            }
        }
        resultados.Add(new string[] { token, tipo, fila.ToString(), columna.ToString(), color, (posicion - token.Length).ToString() });
    }

    //Metodo que evalua, segun el estado final que tipo de token fue encontrado
    public string Encontrado(int estadoFinal)
    {
        string tipo;
        if (!finales.TryGetValue(estadoFinal, out tipo))
        {
            tipo = "error";
        }
        return tipo;
    }

    //Metodo que cambia el estado actual
    public int CambiarEstado(int estado, char caracter)
    {
        if (estado == 11)
        {
            caracter = 'a';
        }
        else if (estado == 13 || estado == 12)
        {
            caracter = (caracter == '*') ? caracter : 'a';
        }
        else if (estado == 14)
        {
            caracter = (caracter == '/') ? caracter : 'a';
        }
        else if (estado == 23 || estado == 24)
        {
            caracter = (caracter == '\"') ? caracter : 'a';
        }
        else if (estado == -1)
        {
            caracter = 'a';
        }
        else
        {
            caracter = (caracter >= 48 && caracter <= 57) ? 'd'
            : ((caracter >= 65 && caracter <= 90) || (caracter >= 97 && caracter <= 122)) ? 'l'
            : caracter;

        }
        int proximo =
        (delta.ContainsKey(estado) && delta[estado].TryGetValue(caracter, out proximo)) ?
        proximo : -1
        ;
        return proximo;
    }

}
