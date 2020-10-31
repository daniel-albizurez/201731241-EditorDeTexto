using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class PDA
{
    /** 
	 * Tengo una pila
	 * Una tabla de sustituciones (Que basicamente es una tabla de transiciones)
	 * Mis trancisiones son del tipo (caracter, pila) -> push o pop
	 **/
    static Stack<string> stack = new Stack<string>();
//    Stack<(int,string)> esperado = new Stack<(int,string)>();

    Dictionary<(string, string), string[]> tabla = new Dictionary<(string, string), string[]>();
    Dictionary<int, string> esperados = new Dictionary<int, string>();
    ArrayList errores = new ArrayList();

    /**
     * Errores
     * Apilo un simbolo
     * Espero un token
     * No viene ese token
     * Guardo el error
     * Reinicio la pila
     * Repito
     * */

    string produccionInicial = "P";

    int posicion = 0;


    public PDA()
    {
        tabla.Add(( "P"     ,   "principal"  ), new string[] { "", "B", ")", "(", "principal" });
        tabla.Add(( "B"     ,   "{"  ), new string[] { "", "}", "I", "{"});

        tabla.Add(( "I"     ,   "imprimir"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "leer"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "entero"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "decimal"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "booleano"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "cadena"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "caracter"     ), new string[] { "", "F", "S" });
        tabla.Add(( "I"     ,   "SI"     ), new string[] { "(", "If"});
        tabla.Add(( "I"     ,   "MIENTRAS"     ), new string[] { "(", "W"});
        tabla.Add(( "I"     ,   "HACER"     ), new string[] { "(", "Do"});
        tabla.Add(( "I"     ,   "DESDE"     ), new string[] { "(", "For" });
        tabla.Add(( "I"     ,   "}"     ), new string[] { ""});

        tabla.Add(( "S"     ,   "imprimir"     ), new string[] { "", "Pr"});
        tabla.Add(( "S"     ,   "leer"     ), new string[] { "", "R"});
        tabla.Add(( "S"     ,   "entero"     ), new string[] { "", "D" });
        tabla.Add(( "S"     ,   "decimal"     ), new string[] { "", "D" });
        tabla.Add(( "S"     ,   "booleano"     ), new string[] { "", "D" });
        tabla.Add(( "S"     ,   "cadena"     ), new string[] { "", "D" });
        tabla.Add(( "S"     ,   "caracter"     ), new string[] { "", "D" });

        tabla.Add(( "D"     ,   "entero"     ), new string[] { "", "D'", "id", "T" });
        tabla.Add(( "D"     ,   "decimal"     ), new string[] { "", "D'", "id", "T" });
        tabla.Add(( "D"     ,   "booleano"     ), new string[] { "", "D'", "id", "T" });
        tabla.Add(( "D"     ,   "cadena"     ), new string[] { "", "D'", "id", "T" });
        tabla.Add(( "D"     ,   "caracter"     ), new string[] { "", "D'", "id", "T" });

        tabla.Add(( "T"     ,   "entero"     ), new string[] { "", "entero" });
        tabla.Add(( "T"     ,   "decimal"     ), new string[] { "", "decimal" });
        tabla.Add(( "T"     ,   "booleano"     ), new string[] { "", "booleano" });
        tabla.Add(( "T"     ,   "cadena"     ), new string[] { "", "cadena" });
        tabla.Add(( "T"     ,   "caracter"     ), new string[] { "", "caracter" });

        tabla.Add(( "D'"    ,   ";"         ), new string[] { "" });
        
        tabla.Add(( "F"    ,    ";"         ), new string[] { "", "I", ";" });


        /*tabla.Add(( "I"     ,   "tipo"  ), new string[] { "", "S" });
        tabla.Add(( "I"     ,   "$"     ), new string[] { "" });
        tabla.Add(( "S"     ,   "tipo"  ), new string[] { "", "S\'", "D" });
        tabla.Add(( "S\'"   ,   ";"     ), new string[] { "", "F" });
        tabla.Add(( "D"     ,   "tipo"  ), new string[] { "id", "N", "tipo" });
        tabla.Add(( "N"     ,   "id"    ), new string[] { ";", "N\'", "id" });
        tabla.Add(( "N\'"   ,   ";"     ), new string[] { "" });
        tabla.Add(( "N\'"   ,   ","     ), new string[] { "id", "N", "," });
        tabla.Add(( "F"     ,   ";"     ), new string[] { "", "I", ";" });*/
    }

    public ArrayList analize(ArrayList tokens)
    {
        stack.Clear();
        esperados.Clear();
        errores.Clear();
        posicion = 0;
        if (stack.Count == 0)
        {
            stack.Push("$");
            stack.Push(produccionInicial);
        }
        foreach (string[] token in tokens)
        {
            transition(token);
        }
        foreach (int item in esperados.Keys)
        {
            string error;
            esperados.TryGetValue(item, out error);
            Console.WriteLine(error + item);
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("Analisis completado");
        }
        foreach (string item in stack)
        {
            Console.WriteLine(item);
        }
        return errores;
    }
    public void transition(string[] info)
    {
        string stackVal;
        string[] pushVal;
        string token = info[1];
        string lexema = info[0];
        posicion++;
        switch (token)
        {
            /*case "tipo":
                lexema = token;
                break;*/
            case "id":
                lexema = "id";
                break;
            /*case "numero entero":
            case "numero decimal":
                lexema = "num";
                break;*/
            case "error":
                lexema = "error";
                break;
            default:
                break;
        }
        Console.WriteLine(lexema);
        bool repeat = true;
            string esp;
            if (esperados.TryGetValue(posicion, out esp) && lexema != "$")
            {
                if (esp == lexema)
                {
                    esperados.Remove(posicion);
                }
                else
                {
                errores.Add("Se esperaba " + esp + " en línea " + info[2] + " columna " + info[3]);
                    stack.Clear();
                    stack.Push("$");
                    stack.Push("I");
                }
            }
                    stackVal = stack.Peek();
        while (repeat)
        {
            if (repeat = tabla.TryGetValue((stackVal, lexema), out pushVal))
            {
                stack.Pop();
                string es = pushVal[0];
                foreach (string val in pushVal.Skip(1))
                {
                    stack.Push(val);
                }
                if (!String.IsNullOrEmpty(es))
                {
                    esperados.Add(posicion + 1, es);
                }
            }
                if (stack.Count != 0 && (stackVal = stack.Peek()) == lexema)
                {
                    stack.Pop();
                }
        }
    }
}
