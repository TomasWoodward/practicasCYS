using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Security.Cryptography;
using System;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using System.Text;

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
        // Metodo para comprimir varios archivos y luego encriptar el ZIP resultante
        public byte[] CompressAndEncryptFiles(Dictionary<string, byte[]> files, byte[] key, byte[] iv)
        {
            byte[] compressedBytes;

            // Comprimir los archivos
            compressedBytes = CompressFiles(files);

            // Encriptar el archivo comprimido
            return EncryptAes(compressedBytes, key, iv);
        }

        // Metodo para comprimir m�ltiples archivos
        public byte[] CompressFiles(Dictionary<string, byte[]> files)
        {
            byte[] compressedBytes;

            try
            {
                using (MemoryStream memoryStream = new())
                {
                    // Crear el archivo .zip en memoria
                    using (ZipArchive zip = new(memoryStream, ZipArchiveMode.Create, true))
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

                Console.WriteLine("Archivos comprimidos con �xito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al comprimir los archivos: " + ex.Message);
                return null;
            }

            return compressedBytes;
        }

        // Metodo para encriptar usando AES
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
                using (MemoryStream memoryStream = new())
                {
                    // Crear CryptoStream para escribir los datos cifrados
                    using (CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write))
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

        // Mwtodo para desencriptar usando AES
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
                using (MemoryStream memoryStream = new(cipheredBytes))
                {
                    // Crear CryptoStream para leer los datos cifrados
                    using (CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream decryptedStream = new())
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

        // M�todo para descomprimir archivos
        public Dictionary<string, byte[]> DecompressFiles(byte[] compressedBytes)
        {
            Dictionary<string, byte[]> files = new();

            try
            {
                using (MemoryStream memoryStream = new(compressedBytes))
                {
                    using (ZipArchive zip = new(memoryStream, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in zip.Entries)
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                using (MemoryStream decompressedStream = new())
                                {
                                    entryStream.CopyTo(decompressedStream);
                                    files[entry.Name] = decompressedStream.ToArray();
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Archivos descomprimidos con �xito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descomprimir los archivos: " + ex.Message);
                return null;
            }

            return files;
        }
        public RSAParameters GenerateRsaKeys(out string publicKey, out string privateKey)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                // Exportar la clave publica y privada
                publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
                privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
                return rsa.ExportParameters(true);
            }
        }
        public byte[] DecryptAesKeyWithRsa(byte[] encryptedAesKey, string privateKey)
        {
            byte[] decryptedKey;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                decryptedKey = rsa.Decrypt(encryptedAesKey, RSAEncryptionPadding.OaepSHA256);
            }

            return decryptedKey;
        }

        // Metodo para cifrar la clave AES con la clave p�blica RSA
        public byte[] EncryptAesKeyWithRsa(byte[] aesKey, string publicKey)
        {
            byte[] encryptedKey;

            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                encryptedKey = rsa.Encrypt(aesKey, RSAEncryptionPadding.OaepSHA256);
            }

            return encryptedKey;
        }

        // Metodo para cifrar la clave privada RSA con AES128
        public byte[] EncryptPrivateKeyWithAes(string privateKey, string password)
        {
            byte[] encryptedPrivateKey;
            byte[] privateKeyBytes = Encoding.UTF8.GetBytes(privateKey);

            using (Aes aes = Aes.Create())
            {
                // Derivar la clave AES de la contrase�a del usuario
                using (Rfc2898DeriveBytes keyGen = new(password, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256))
                {
                    aes.Key = keyGen.GetBytes(16);  // AES128 (clave de 16 bytes)
                    aes.IV = keyGen.GetBytes(16);   // IV de 16 bytes

                    // Crear el cifrador AES
                    using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    {
                        using (MemoryStream memoryStream = new())
                        {
                            using (CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(privateKeyBytes, 0, privateKeyBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                encryptedPrivateKey = memoryStream.ToArray();
                            }
                        }
                    }
                }
            }

            return encryptedPrivateKey;
        }

        // M�todo para descifrar la clave privada RSA usando AES128
        public string DecryptPrivateKeyWithAes(byte[] encryptedPrivateKey, string password)
        {
            string decryptedPrivateKey;
            byte[] decryptedPrivateKeyBytes;

            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes keyGen = new(password, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256))
                {
                    aes.Key = keyGen.GetBytes(16);
                    aes.IV = keyGen.GetBytes(16);

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        using (MemoryStream memoryStream = new(encryptedPrivateKey))
                        {
                            using (CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                using (MemoryStream decryptedStream = new())
                                {
                                    cryptoStream.CopyTo(decryptedStream);
                                    decryptedPrivateKeyBytes = decryptedStream.ToArray();
                                }
                            }
                        }
                    }
                }
            }

            decryptedPrivateKey = Encoding.UTF8.GetString(decryptedPrivateKeyBytes);
            return decryptedPrivateKey;
        }

        // M�todo para generar la clave AES a partir de la contrase�a ingresada por el usuario
        public byte[] GenerateAesKeyFromPassword(string password)
        {
            using (Rfc2898DeriveBytes keyGen = new(password, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256))
            {
                return keyGen.GetBytes(16);  // AES128 (clave de 16 bytes)
            }
        }
    }
}

