using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Core
{
    static class Cryptage
    {
        //clé symérique et tableau d'initialisation
        static public byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
        static public byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");

        static public void Generate_cle_iv()
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            byte[] iv = TDES.IV;
            byte[] cle = TDES.Key;

            Console.WriteLine("cle = " + Convert.ToBase64String(cle));
            Console.WriteLine("iv = " + Convert.ToBase64String(iv));
        }

        static public string DecryptSym(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            var decryptor = TDES.CreateDecryptor(key, iv);

            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

            return Encoding.Default.GetString(decryptedTextAsByte);
        }

    }
}
