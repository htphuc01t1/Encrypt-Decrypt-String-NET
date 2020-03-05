using Encrypt_Decrypt_String_NET.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt_String_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string planText = "Hello World";
            Console.WriteLine($"ORIGINAL DATA: {planText}");

            //ENCRYPT AND DECRYPT WITH RSA
            {
                string publicRSAKey, privateRSAKey = "";
                RSAHelper.GenerateKey(out publicRSAKey, out privateRSAKey);

                string encryptText = RSAHelper.Encrypt(publicRSAKey, planText);
                string decryptText = RSAHelper.Decrypt(privateRSAKey, encryptText); //Equal with planText 

                Console.WriteLine("======== ENCRYPT AND DECRYPT WITH RSA:==================");
                Console.WriteLine("");
                Console.WriteLine($"    - ENCRYPTED  DATA: {encryptText}");
                Console.WriteLine($"    - DECRYPTED  DATA: {decryptText}");                
                Console.WriteLine();
            }


            //ENCRYPT AND DECRYPT WITH TripleDES
            {
                string key = "your-keys-sqoy19";
                string encryptText = TripleDESHelper.Encrypt(key, planText);
                string decryptText = TripleDESHelper.Decrypt(key, encryptText);

                Console.WriteLine("======== ENCRYPT AND DECRYPT WITH TripleDES:=============");                
                Console.WriteLine($"    - ENCRYPTED  DATA: {encryptText}");
                Console.WriteLine($"    - DECRYPTED  DATA: {decryptText}");                
                Console.WriteLine();
            }

            //ENCRYPT AND DECRYPT WITH AES
            {
                string key = "YourKey";
                string encryptText = AESHelper.Encrypt(key, planText);
                string decryptText = AESHelper.Decrypt(key, encryptText);

                Console.WriteLine("======== ENCRYPT AND DECRYPT WITH AES:===================");                
                Console.WriteLine($"    - ENCRYPTED  DATA: {encryptText}");
                Console.WriteLine($"    - DECRYPTED  DATA: {decryptText}");
                
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
