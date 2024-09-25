using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using System;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;


namespace practicaCys
{
    internal static class Program
    {
        /// <summary>  
        ///  The main entry point for the application.  
        /// </summary>  
        [STAThread]
        static void Main()
        {
            byte[] key = new byte[32];
            RandomNumberGenerator.Fill(key); // Genera 32 bytes aleatorios para la clave  

            // Generar IV de 16 bytes  
            byte[] iv = new byte[16];
            RandomNumberGenerator.Fill(iv); // Genera 16 bytes aleatorios para el IV  

            compressAndEncrypt compresor = new compressAndEncrypt();

            // Llamar al método EncryptAes con los datos generados  
            compresor.EncryptAes(new byte[0], key, iv);

            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class compressAndEncrypt
    {
        public byte[] EncryptAes(byte[] fileBytes, byte[] key, byte[] iv)
        {
            byte[] cipheredBytes;

            string rutaArchivo = @"C:\Users\Tomas Woodward\Desktop\Facultad\prueba.txt";

            // Leer el archivo y obtener los bytes  
            fileBytes = File.ReadAllBytes(rutaArchivo);

            //Comprimir el archivo
            compressAndEncrypt compresor = new compressAndEncrypt();
            fileBytes = compresor.Comprime(fileBytes);

            // Ahora 'fileBytes' contiene el contenido del archivo en formato byte[]  

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Crear el cifrador  
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                // Usar MemoryStream para almacenar el archivo cifrado  
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Crear CryptoStream para escribir los datos cifrados  
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        // Escribir los bytes del archivo al flujo de cifrado  
                        cryptoStream.Write(fileBytes, 0, fileBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        // Obtener los bytes cifrados  
                        cipheredBytes = memoryStream.ToArray();
                    }
                }
            }
            File.WriteAllBytes(@"C:\Users\Tomas Woodward\Desktop\Facultad\prueba2.txt", cipheredBytes);

            Console.WriteLine($"El archivo ha sido cifrado y guardado");
            //PRUEBA DESCIFRADO

            compresor.DecryptAes(cipheredBytes, key, iv);


            return cipheredBytes;
        }

        public byte[] Comprime(byte[] fileBytes)
        {
            byte[] compressedBytes;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Crear el archivo .zip en memoria  
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        // Crear una entrada dentro del archivo .zip  
                        ZipArchiveEntry zipEntry = zip.CreateEntry("archivo_comprimido");

                        // Abrir el stream para escribir en la entrada del .zip  
                        using (Stream entryStream = zipEntry.Open())
                        {
                            // Escribir los bytes del archivo dentro del .zip  
                            entryStream.Write(fileBytes, 0, fileBytes.Length);

                        }
                    }
                    // Obtener los bytes comprimidos  
                    compressedBytes = memoryStream.ToArray();

                }

                Console.WriteLine("Archivo comprimido con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al comprimir el archivo: " + ex.Message);
                return null;
            }

            return compressedBytes;
        }

        public byte[] DecryptAes(byte[] cipheredBytes, byte[] key, byte[] iv)
        {
            byte[] decryptedBytes;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                // Crear el descifrador
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

                // Usar MemoryStream para almacenar los datos desencriptados
                using (MemoryStream memoryStream = new MemoryStream(cipheredBytes))
                {
                    // Crear CryptoStream para leer los datos cifrados
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream decryptedStream = new MemoryStream())
                        {
                            // Leer desde el CryptoStream y escribir los datos descifrados en decryptedStream
                            cryptoStream.CopyTo(decryptedStream);
                            decryptedBytes = decryptedStream.ToArray();
                        }
                    }
                }
            }
            compressAndEncrypt compresor = new compressAndEncrypt();
            decryptedBytes = compresor.Descomprime(decryptedBytes);

            File.WriteAllBytes(@"C:\Users\Tomas Woodward\Desktop\Facultad\prueba_descifrado.txt", decryptedBytes);

            Console.WriteLine($"El archivo ha sido desencriptado y guardado");
            return decryptedBytes;
        }

        public byte[] Descomprime(byte[] compressedBytes)
        {
            byte[] decompressedBytes;


            try
            {
                // Usar MemoryStream para leer el archivo .zip desde los bytes comprimidos
                using (MemoryStream memoryStream = new MemoryStream(compressedBytes))
                {
                    // Abrir el archivo .zip en memoria
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Read))
                    {
                        // Obtener la primera entrada del .zip (puedes adaptar esto si hay más de una entrada)
                        ZipArchiveEntry zipEntry = zip.Entries[0];

                        // Abrir el stream de la entrada para leer el contenido descomprimido
                        using (Stream entryStream = zipEntry.Open())
                        {
                            using (MemoryStream decompressedStream = new MemoryStream())
                            {
                                // Copiar el contenido del archivo descomprimido al MemoryStream
                                entryStream.CopyTo(decompressedStream);

                                // Convertir el contenido del stream descomprimido a un array de bytes
                                decompressedBytes = decompressedStream.ToArray();
                            }
                        }
                    }
                }

                Console.WriteLine("Archivo descomprimido con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descomprimir el archivo: " + ex.Message);
                return null;
            }

            return decompressedBytes;
        }



    }



}
