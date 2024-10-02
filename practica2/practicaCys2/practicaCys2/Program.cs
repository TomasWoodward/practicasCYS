using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using System;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace practicaCys2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,  
            // see https://aka.ms/applicationconfiguration.  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class compressAndEncrypt
    {
        // Método para comprimir varios archivos y luego encriptar el ZIP resultante
        public byte[] CompressAndEncryptFiles(Dictionary<string, byte[]> files, byte[] key, byte[] iv)
        {
            byte[] compressedBytes;

            // Comprimir los archivos
            compressedBytes = CompressFiles(files);

            // Encriptar el archivo comprimido
            return EncryptAes(compressedBytes, key, iv);
        }

        // Método para comprimir múltiples archivos
        public byte[] CompressFiles(Dictionary<string, byte[]> files)
        {
            byte[] compressedBytes;

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Crear el archivo .zip en memoria
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var file in files)
                        {
                            // Crear una entrada dentro del archivo .zip por cada archivo
                            ZipArchiveEntry zipEntry = zip.CreateEntry(file.Key);

                            // Abrir el stream para escribir en la entrada del .zip
                            using (Stream entryStream = zipEntry.Open())
                            {
                                // Escribir los bytes del archivo dentro del .zip
                                entryStream.Write(file.Value, 0, file.Value.Length);
                            }
                        }
                    }

                    // Obtener los bytes comprimidos
                    compressedBytes = memoryStream.ToArray();
                }

                Console.WriteLine("Archivos comprimidos con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al comprimir los archivos: " + ex.Message);
                return null;
            }

            return compressedBytes;
        }

        // Método para encriptar usando AES
        public byte[] EncryptAes(byte[] dataBytes, byte[] key, byte[] iv)
        {
            byte[] cipheredBytes;

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
                        // Escribir los bytes al flujo de cifrado
                        cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        // Obtener los bytes cifrados
                        cipheredBytes = memoryStream.ToArray();
                    }
                }
            }

            Console.WriteLine($"El archivo ha sido cifrado.");
            return cipheredBytes;
        }

        // Método para desencriptar usando AES
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

            Console.WriteLine("El archivo ha sido descifrado.");
            return decryptedBytes;
        }

        // Método para descomprimir archivos
        public Dictionary<string, byte[]> DecompressFiles(byte[] compressedBytes)
        {
            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(compressedBytes))
                {
                    using (ZipArchive zip = new ZipArchive(memoryStream, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                using (MemoryStream decompressedStream = new MemoryStream())
                                {
                                    entryStream.CopyTo(decompressedStream);
                                    files[entry.Name] = decompressedStream.ToArray();
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Archivos descomprimidos con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descomprimir los archivos: " + ex.Message);
                return null;
            }

            return files;
        }
    }

}