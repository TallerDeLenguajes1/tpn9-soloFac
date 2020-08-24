using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

using Helpers;


namespace CodigoMorse
{
    class Program
    {
        //PUNTO 1 y 2
        /*
        static void Main(string[] args)
        {
            //PUNTO 1
            string ruta = @"C:\Users\Franco\Desktop\Repositorios\codebin#\TPN9\archivobin\temp\";    //Recordar siempre poner la ultima barra
            string nombre = "destino";
            string RutaArchivo = ruta + nombre + ".dat";

            //SoporteParaConfiguracion.CrearArchivoDeConfiguracion(ruta, nombre);

            //SoporteParaConfiguracion.LeerConfiguracion(RutaArchivo);

            //PUNTO 2

            string RutaPListar = @"C:\Users\Franco\Desktop\Repositorios\codebin#\TPN9\CodigoMorse\bin\Debug\";

            //Creo una instancia de DirectoryInfo para poder listar la informacion y usar metodos de FileInfo
            DirectoryInfo directorio = new DirectoryInfo(RutaPListar);
            FileInfo[] Files = directorio.GetFiles();

            string Origen;
            //Para cada Archivo dentro del directorio para listar
            foreach (FileInfo Archivos in Files)
            {
                //Obtengo el nombre de cada archivo y lo muestro por pantalla
                string NombreArchivo = Path.GetFileName(Archivos.ToString()).ToString();
                Console.WriteLine(NombreArchivo + "\n");

                //Obtengo la extension y la comparo, si coincide muevo el archivo a ruta
                string extension = Path.GetExtension(Archivos.ToString()).ToString();
                if (extension == ".txt" || extension == ".mp3")
                {
                    Origen = Archivos.ToString();
                    File.Move(Origen, ruta + NombreArchivo);
                }
            }

        }
        */

        static void Main(string[] args)
        {
            Dictionary<string, string> DiccionarioClaveMorse = new Dictionary<string, string>();

            //DiccionarioClaveMorse["a"] = ".-";

            string texto = "Los defines son azules";
            string clave = ConversorDeMorse.TextoAMorse(texto);

            Console.WriteLine("El texto '{0}' en clave morse es: {1}", texto, clave);

            texto = ConversorDeMorse.MorseATexto(clave);

            Console.WriteLine("La clave morse '{0}' en texto es: {1}", clave, texto);



        }
    }
}
