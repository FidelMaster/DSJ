using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace DSJ.Helpers
{
    public class MetodosEncriptacion
    {
        // Utilizacion del algoritmo symetrico Rijdael
        #region Metodo
        public  byte[] Encriptado(string password)
        {
            try
            {

                SymmetricAlgorithm r = SymmetricAlgorithm.Create("Rijndael");
              
                // Definiendo el key 
                // r.KeySize = 256;
                byte[] key = new byte[] { 0x21, 0x05, 0x07, 0x08, 0x27, 0x02, 0x23 };
                byte[] IV = new byte[] { 0x21, 0x05, 0x07, 0x08, 0x27, 0x02, 0x23 };

                byte[] encrypted = ExtraerByte(password, key,IV);
                return encrypted;
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        #endregion

        public   byte[] ExtraerByte(string texto, byte[] Key, byte[] IV)
        {
            #region Validacion
            // Validando Parametros
            if (texto == null || texto.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            #endregion
            byte[] encrypted;

            // Instanciando algoritmo simetrico de Rijndael
            using (SymmetricAlgorithm r = SymmetricAlgorithm.Create("Rijndael"))
            {
                r.GenerateKey();
                r.GenerateIV();

               // r.Key = Key;
               // r.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = r.CreateEncryptor(r.Key, r.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(texto);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}