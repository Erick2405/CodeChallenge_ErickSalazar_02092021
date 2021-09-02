using System;
using System.Linq;
using System.Text.RegularExpressions;


// Code Chalenge
// Autor: Erick David Salazar González
// Fecha: 29/08/2021

/*
 Simple coding exercise:
In c#, write a program that parses a sentence and replaces each word with the following: 
first letter, number of distinct characters between first and last character, and last letter. 

For example, Smooth would become S3h. 
Words are separated by spaces or non-alphabetic characters and these separators should be maintained in 
their original form and location in the answer.
*/


namespace Pruebas_CodeChallenge
{
   public class Program
    {
        static void Main(string[] args)
        {
            string mensajeSalida = "Presiona una tecla para continuar";
            try
            {
                Console.WriteLine("Ingresa la cadena:");
                var Input = Console.ReadLine();

                var strFinal = ConvierteCadena(Input);

                Console.WriteLine(strFinal);

                Console.WriteLine(mensajeSalida);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error");
                Console.WriteLine(ex.Message);

                Console.WriteLine(mensajeSalida);
                Console.ReadLine();
            }

        }

       public static string ConvierteCadena(string Input)
        {
            var InputMod = Regex.Replace(Input, "[^A-Za-zÀ-ÖØ-öø-ÿ0-9]", " ");

            //"esta, es una candena, pars (pruebas)?
            var arrPrimero = InputMod.Split(" ");
            var arr = arrPrimero.Where(x => x != "").ToArray();

            string[] arrMod = new string[arr.Length];
            string strFinal = Input;

            for (int i = 0; i < arr.Length; i++)
            {
                // Si la palabra solo tiene 2 o 1 letra o si es un numero las descarta
                if (arr[i].Length > 2)
                {
                    string strSinPU = arr[i].Substring(1, arr[i].Length - 2);

                    var arrStrSinPU = strSinPU.ToCharArray();
                    Array.Sort(arrStrSinPU);

                    int diferentes = 0;
                    char actual = ' ';

                    for (int j = 0; j < arrStrSinPU.Length; j++)
                    {
                        if (arrStrSinPU[j] != actual)
                        {
                            diferentes++;
                            actual = arrStrSinPU[j];
                        }
                    }
                    arrMod[i] = arr[i].Substring(0, 1) + diferentes.ToString() + arr[i].Substring(arr[i].Length - 1, 1);
                }
                else
                    arrMod[i] = arr[i];

              
                strFinal = RemplazarPrimeraCad(strFinal, arr[i], arrMod[i]);
                // l1s Atl1s              
            }

            return strFinal;
        }


       // Remplazamos solo la primera ocurrencia para evitar que se reemplace en otras palabras
     public static  string RemplazarPrimeraCad(string texto, string busq, string remp)
       {
            int pos = texto.IndexOf(busq);
            if (pos < 0)
            {
                return texto;
            }
            return texto.Substring(0, pos) + remp + texto.Substring(pos + busq.Length);
      }

    }
}
