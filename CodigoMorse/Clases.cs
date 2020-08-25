using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        static public void CrearArchivoDeConfiguracion(string ruta, string nombre)    //Crea archivos con extension .dat
        {
            string RutaArchivo = ruta + nombre + ".dat";

            if (Directory.Exists(ruta) == false) Directory.CreateDirectory(ruta);

            if (!File.Exists(RutaArchivo))
            {
                FileStream MiArchivo = new FileStream(RutaArchivo, FileMode.Create);      //Crea archivo destino.dat
                MiArchivo.Close();
            }
        }

        static public void LeerConfiguracion(string RutaArchivo)
        {
            using (FileStream MiArchivo = new FileStream(RutaArchivo, FileMode.Open))   //Especialmente para archivos binarios "FileStream"
            {
                //Devuelve el puntero a 0, para leer el archivo desde el inicio
                using (StreamReader MiStream = new StreamReader(MiArchivo))     //Utilizo StreamReader para leer el archivo de texto de Configuracion que es binario
                {
                    //Restablezco la posicion del puntero del archivo al comienzo
                    MiArchivo.Position = 0;
                    //Leyendo el archivo desde StreamReader - obtiene texto a partir de archivos binarios legibles en este formato
                    string cadena = MiStream.ReadToEnd();
                    Console.WriteLine("La cadena leida con StreamReader es: " + cadena);

                    //Forma de leer a partir de FileStream
                    //byte[] buffer = new byte[128];
                    //MiArchivo.Read(buffer, 0, 128);
                    //string cadena2 = System.Text.Encoding.Default.GetString(buffer);    //Convierte los bytes a string
                    //Console.WriteLine("La candena leida con FileStream es: " + cadena2);
                }
            }
        }
    }

    public static class ConversorDeMorse{
        static Dictionary<char, string> DiccionarioCodigoMorse = new Dictionary<char, string>()
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},

            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"}
        };

        static public string MorseATexto(string clave)
        {
            //Voy a separar las palabras en un arreglo de string, y luego cada letra, despues utilizando
            //un recorrido de KeyValuePair para cada par de valores comparando cada value con la letramorse
            //para ver si conincide y si coincide entonces extraere su Key.
            string[] palabrasMorse = clave.Split("/");       // .-.. --- ... /-.. . ..-. .. -. . ... /... --- -. /.- --.. ..- .-..

            string[] letrasMorse;

            string texto = "";

            foreach (string palabra in palabrasMorse)
            {
                letrasMorse = palabra.Split(" ");
                foreach (string letra in letrasMorse)
                {
                    //Para cada par de valores me fijo si el valor coindice con la letra, si coincide lo extraigo y concateno
                    foreach (KeyValuePair<char, string> par in DiccionarioCodigoMorse)  //Es lo unico mas costoso en el ciclo
                    {
                        if (par.Value == letra)
                        {
                            texto += par.Key; // Found
                        }
                    }
                }
                //Cuando pase a otra palabra voy a agregar un espacio para separarlas
                texto += " ";
            }

            return texto;
        }

        static public string TextoAMorse(string texto)
        {
            string ClaveMorse = "";
            foreach (char caracter in texto)
            {
                string salida;
                if (caracter != ' ')
                {
                    //Envio el char convertido a minusculas, para obtener el valor de la clave(char)
                    DiccionarioCodigoMorse.TryGetValue(Char.ToLower(caracter), out salida);
                    //Concateno el valor de cada caracter en codigo morse
                    ClaveMorse += salida + ' ';
                }
                else
                {
                    ClaveMorse += '/';
                }
            }

            return ClaveMorse;
        }



    }
}
