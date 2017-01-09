using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevTicketMaker {
    class Crypto {
        public static byte[] EncryptTitleKey(byte[] commonKey, byte[] titleKey, byte[] titleId) {
            byte[] rgbIV = new byte[0x10];
            byte[] encKey;
            titleId.CopyTo(rgbIV, 0);
            AesManaged aesManaged = new AesManaged();
            aesManaged.Key = commonKey;
            aesManaged.IV = rgbIV;
            aesManaged.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = aesManaged.CreateEncryptor(commonKey, rgbIV);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(titleKey, 0, titleKey.Length);
            cryptoStream.FlushFinalBlock();
            encKey = new byte[0x10];
            Array.Copy(memoryStream.ToArray(), encKey, 0x10);
            return encKey;
        }

        public static byte[] RsaSign(byte[] message) {
            var rsa = new RSACryptoServiceProvider(2048);
            var rsaParams = new RSAParameters();
            rsaParams.Exponent = Properties.Resources.Exponent; //Pub Exponent
            rsaParams.D = Properties.Resources.D;               //Priv Exponent
            rsaParams.P = Properties.Resources.P;               //Prime1
            rsaParams.Q = Properties.Resources.Q;               //Prime2
            rsaParams.Modulus = Properties.Resources.Modulus;   //Mod
            rsaParams.DP = Properties.Resources.DP;             //Exp1
            rsaParams.DQ = Properties.Resources.DQ;             //Exp2
            rsaParams.InverseQ = Properties.Resources.InverseQ; //Coeff
            var hash = new SHA256Managed();
            rsa.ImportParameters(rsaParams);
            return rsa.SignHash(hash.ComputeHash(message), CryptoConfig.MapNameToOID("SHA256"));
        }
    }
}
