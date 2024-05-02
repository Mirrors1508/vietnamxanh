using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public class HashingMD5
    {
        public static string Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }

        }

    }
}
