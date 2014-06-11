using System;
using System.Security.Cryptography;
using System.Text;

namespace D3ApiDotNet.DataAccess.Helper
{
    /// <summary>
    /// helper class for md5 hashes. static.
    /// </summary>
    public static class MD5Helper
    {

        /// <summary>
        /// creates md5 hash from string input
        /// </summary>
        /// <param name="textToHash"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetMd5Hash(string textToHash)
        {
            if (textToHash == null)
                throw new ArgumentNullException("textToHash");
            //Prüfen ob Daten übergeben wurden.
            if (string.IsNullOrEmpty(textToHash))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            var tToHash = Encoding.Default.GetBytes(textToHash);
            var result = md5.ComputeHash(tToHash);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
