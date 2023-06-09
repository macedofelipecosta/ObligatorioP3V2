using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogicaNegocio.ValueObject
{
    public class Token
    {
        private string _data;
        public string Data { get { return _data; } private set { _data = value; } }

        public Token()
        {
            Data = GenerateSecureKey();
        }
    
        

        public static string GenerateSecureKey()
    {
        byte[] keyBytes = new byte[32]; // 32 bytes = 256 bits

        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(keyBytes);
        }

        string base64Key = Convert.ToBase64String(keyBytes);
        return base64Key;
    }
}
}
