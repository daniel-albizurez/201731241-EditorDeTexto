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

    string produccionInicial = "I";

    int posicion = 0;


    public PDA()
    {
        tabla.Add(( "I"     ,   "tipo"  ), new string[] { "", "S" });
        tabla.Add(( "I"     ,   "$"     ), new string[] { "" });
        tabla.Add(( "S"     ,   "tipo"  ), new string[] { "", "S\'", "D" });
        tabla.Add(( "S\'"   ,   ";"     ), new string[] { "", "F" });
        tabla.Add(( "D"     ,   "tipo"  ), new string[] { "id", "N", "tipo" });
        tabla.Add(( "N"     ,   "id"    ), new string[] { ";", "N\'", "id" });
        tabla.Add(( "N\'"   ,   ";"     ), new string[] { "" });
        tabla.Add(( "N\'"   ,   ","     ), new string[] { "id", "N", "," });
        tabla.Add(( "F"     ,   ";"     ), new string[] { "", "I", ";" });
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
            case "tipo":
                lexema = token;
                break;
            case "id":
                lexema = "id";
                break;
            case "numero entero":
            case "numero decimal":
                lexema = "num";
                break;
            case "error":
                lexema = "error";
                break;
            default:
                break;
        }
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
                    stack.Push(produccionInicial);
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
                if (stack.Count != 0 && (stackVal = stack.Peek()) == lexema)
                {
                    stack.Pop();
                }
            }
        }
    }
}
