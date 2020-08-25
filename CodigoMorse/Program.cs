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
            string texto = "Los delfines son azules";
            //El texto es traducido a clave morse y luego mostrado por pantalla
            string clave = ConversorDeMorse.TextoAMorse(texto);
            Console.WriteLine("El texto '{0}' en clave morse es: {1}", texto, clave);

            //envio la clave del texto anterior que fue traducida para verificar su funcionamiento, muestro por pantalla
            texto = ConversorDeMorse.MorseATexto(clave);
            Console.WriteLine("La clave morse '{0}' traducida es: {1}", clave, texto);


            //ArchivarTextoMorse: recibe la ruta donde se quiere guardar un archivo.txt, pide escribir un texto
            //el cual sera traducido a clave morse y guardado en el archivo con nombre morse_fechaActual
            //Apartado
            string ruta = @"C:\Users\Franco\Desktop\Repositorios\codebin#\TPN9\Morse\";

            ArchivarTextoMorse(ruta);

        }



        public static void ArchivarTextoMorse(string ruta)
        {
            Console.WriteLine("Escriba el texto morse a traducir");
            string texto = Console.ReadLine();
            
            string clave = ConversorDeMorse.TextoAMorse(texto);

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            DateTime FechaActual = DateTime.Now;
            string nombre = "morse_[" + FechaActual.ToString("dd_MM_yy") + "]-" + FechaActual.ToString("hh_mm_ss") + ".txt";

            string rutaArchivo = ruta + nombre;

            if (!File.Exists(rutaArchivo))
            {
                using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create))
                {
                    using (StreamWriter stream = new StreamWriter(archivo))
                    {
                        stream.WriteLine(clave);
                    }
                }
            }
        }
    }
}
