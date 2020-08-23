using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings;

namespace Helpers
{
    public class SoporteParaConfiguracion
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
}
