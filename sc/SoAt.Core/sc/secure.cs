using System.Security.Cryptography;
using System.Text;

namespace sc
{
    public class secure
    {
        // ─── TripleDES encrypt/decrypt (เหมือนเดิม) ──────────────────────────────

        const string Passphrase = "NSa#17";
        private readonly ICryptoTransform _Encryptor;
        private readonly ICryptoTransform _Decryptor;

        public secure()
        {
#pragma warning disable SYSLIB0021
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key     = MD5.HashData(Encoding.UTF8.GetBytes(Passphrase)),
                Mode    = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
#pragma warning restore SYSLIB0021
            _Encryptor = tdes.CreateEncryptor();
            _Decryptor = tdes.CreateDecryptor();
        }

        public string? encrypt(object? val)
        {
            if (val == null || val is DBNull) return null;
            var bytes = Encoding.UTF8.GetBytes(sc.value.toString(val));
            return Convert.ToBase64String(_Encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
        }
        public string decrypt(string val)
        {
            var bytes = Convert.FromBase64String(val);
            return Encoding.UTF8.GetString(_Decryptor.TransformFinalBlock(bytes, 0, bytes.Length));
        }

        // ─── Rijndael/AES encrypt/decrypt ────────────────────────────────────────

        const string ENCRYPTION_KEY = "NsX13a";
        private readonly byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

        public string encryptSalt(string inputText)
        {
            using var aes   = Aes.Create();
            var secretKey    = new Rfc2898DeriveBytes(ENCRYPTION_KEY, SALT, 1000, HashAlgorithmName.SHA1);
            aes.Key          = secretKey.GetBytes(32);
            aes.IV           = secretKey.GetBytes(16);
            using var ms     = new MemoryStream();
            using var cs     = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            var plain         = Encoding.Unicode.GetBytes(inputText);
            cs.Write(plain, 0, plain.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        public string decryptSalt(string inputText)
        {
            using var aes   = Aes.Create();
            var secretKey    = new Rfc2898DeriveBytes(ENCRYPTION_KEY, SALT, 1000, HashAlgorithmName.SHA1);
            aes.Key          = secretKey.GetBytes(32);
            aes.IV           = secretKey.GetBytes(16);
            var encrypted    = Convert.FromBase64String(inputText);
            using var ms     = new MemoryStream(encrypted);
            using var cs     = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            var plain         = new byte[encrypted.Length];
            int count         = cs.Read(plain, 0, plain.Length);
            return Encoding.Unicode.GetString(plain, 0, count);
        }

        // ─── HTML encode ──────────────────────────────────────────────────────────

        public string encodeText(string text)
        {
            var rc = System.Net.WebUtility.HtmlEncode(text);
            rc = rc.Replace("!NL!", "<br/>");
            rc = rc.Replace(Environment.NewLine, "<br/>");
            rc = rc.Replace("\n", "<br/>");
            return rc;
        }
    }
}
