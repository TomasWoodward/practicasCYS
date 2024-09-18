using System;
using System.IO;
using System.IO.Compression;

class Programa_compresor
{
    static void Main(string[] args)
    {
        comprime();
    }

    private static void comprime() {
        // Ruta del archivo a comprimir
        string archivo = @"C:\Universidad\3º\Cys\archivo.txt";

        // Ruta donde se creará el archivo .zip
        string ruta_a_comprimir = @"C:\Universidad\3º\Cys\archivo_comprimido.zip";

        try
        {
            // Comprimir el archivo

            // creo un fichero e introduzco mi fichero original ()
            using (FileStream fichero_Original = new FileStream(archivo, FileMode.Open, FileAccess.Read))
            {   
                // creo una ruta para introducir mi ruta_a_comprimir
                using (FileStream ruta_zip = new FileStream(ruta_a_comprimir, FileMode.Create))
                {   
                    // creo el zip y le introduzco la ruta donde quiero que se cree
                    using (ZipArchive zip = new ZipArchive(ruta_zip, ZipArchiveMode.Create))
                    {
                        // Agrego el archivo al .zip
                        ZipArchiveEntry entrada_zip = zip.CreateEntry(Path.GetFileName(archivo));

                        // Abro el zip
                        using (Stream entryStream = entrada_zip.Open())
                        {   
                            // Copio mi archivo dentro del .zip
                            fichero_Original.CopyTo(entryStream);
                        }
                    }
                }
            }

            Console.WriteLine("Archivo comprimido con éxito en: " + ruta_a_comprimir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al comprimir el archivo: " + ex.Message);
        }
    }
}
