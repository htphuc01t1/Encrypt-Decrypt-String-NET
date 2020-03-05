using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt_String_NET.Cryptography
{
    public class RSAHelper
    {        
        public static void GenerateKey(out string publicKey, out string privateKey)
        {
            var csp = new RSACryptoServiceProvider(2048);
            //generate the private key
            var privKey = csp.ExportParameters(true);

            //generate the public key ...
            var pubKey = csp.ExportParameters(false);

            //converting the private key into a string representation            
            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, privKey);
                //get the string from the stream
                privateKey = sw.ToString();
            }

            //converting the public key into a string representation            
            {
                //we need some buffer
                var sw = new System.IO.StringWriter();
                //we need a serializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //serialize the key into the stream
                xs.Serialize(sw, pubKey);
                //get the string from the stream
                publicKey = sw.ToString();
            }
        }

        public static string Encrypt(string publicKeyString, string planText)
        {
            //converting publicKeyString back

            //get a stream from the string
            var sr = new System.IO.StringReader(publicKeyString);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            var publicKey = (RSAParameters)xs.Deserialize(sr);


            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);

            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(planText);

            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);

            return cypherText;
        }

        public static string Decrypt(string privateKeyString, string encryptText)
        {
            //converting privateKeyString back

            //get a stream from the string
            var sr = new System.IO.StringReader(privateKeyString);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            var privateKey = (RSAParameters)xs.Deserialize(sr);


            //first, get our bytes back from the base64 string ...
            var bytesCypherText = Convert.FromBase64String(encryptText);

            //we want to decrypt, therefore we need a csp and load our private key
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey);

            //decrypt and strip pkcs#1.5 padding
            var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            var plainText = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
            return plainText;

        }
    }
}
