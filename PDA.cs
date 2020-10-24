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
    Dictionary<(string, string), string[]> tabla = new Dictionary<(string, string), string[]>();
    //Dictionary<string, string> errores = new Dictionary<string, string>();
    ArrayList errores = new ArrayList();

    string produccionInicial = "I";

    public PDA()
    {
        tabla.Add(( "I"     ,   "tipo"  ), new string[] { "", "S" });
        tabla.Add(( "I"     ,   "$"     ), new string[] { "" });
        tabla.Add(( "S"     ,   "tipo"  ), new string[] { "", "S\'", "D" });
        tabla.Add(( "S\'"   ,   ";"     ), new string[] { "", "F" });
        tabla.Add(( "D"     ,   "tipo"  ), new string[] { " identificador", "N", "tipo" });
        tabla.Add(( "N"     ,   "id"    ), new string[] { " ;", "N\'", "id" });
        tabla.Add(( "N\'"   ,   ";"     ), new string[] { "" });
        tabla.Add(( "N\'"   ,   ","     ), new string[] { "", "N", "," });
        tabla.Add(( "F"     ,   ";"     ), new string[] { "", "I", ";" });

        /*errores.Add("F", ";");
        errores.Add("N", "identificador");
        errores.Add("N\'", ";");*/
    }

    public ArrayList analize(ArrayList tokens)
    {
        stack.Clear();
        errores.Clear();
        if (stack.Count == 0)
        {
            stack.Push("$");
            stack.Push(produccionInicial);
        }
        foreach (string[] token in tokens)
        {
            string esperado;
            transition(token[0], token[1], token[2], out esperado);
            //Console.WriteLine(token[0]);
            if (!String.IsNullOrEmpty(esperado) && tokens.LastIndexOf(token) == tokens.Count-2)
            {
                string error = "Se espera" + esperado + " en linea " + token[2] + " en columna " + (Int16.Parse(token[3]) + 1) ;
                Console.WriteLine(error);
                errores.Add(error);
            }
        }
/*        if (stack.Count == 0)
        {
            Console.WriteLine("Analisis Completo");
        } /*else
        {
            string esperado;
            errores.TryGetValue(stack.Peek(), out esperado);
            Console.WriteLine(esperado + " esperado");
        }*/
        return errores;
    }

    public void transition(string lexema, string token, string linea, out string esperado)
    {
        //Console.WriteLine(lexema + " " + token + " " + linea);
        string stackVal = stack.Peek();
        string[] pushVal;
        switch (token)
        {
            case "tipo":
                lexema = token;
                break;
            case "identificador":
                lexema = "id";
                break;
            case "numero entero":
            case "numero decimal":
                lexema = "num";
                break;
            default:
                break;
        }
        esperado = "";
        while (tabla.TryGetValue((stackVal, lexema), out pushVal))
        {
            stack.Pop();
            esperado = pushVal[0];
            foreach (string val in pushVal.Skip(1))
            {
                stack.Push(val);
            }
            if (stack.Count != 0 && (stackVal = stack.Peek()) == lexema)
            {
                stack.Pop();
            }
        }
/*        if (stack.Count != 0 && (stackVal = stack.Peek()) == lexema)
        {
            stack.Pop();
        }*/
    }
}
