Encrypt and Decrypt in C#.NET

# Features

- RSA Encrypting & Descrypting in C# sample
- TripleDES Encrypting & Descrypting in C# sample
- AES Encrypting & Descrypting in C# sample

## Usage

### RSA Encrypting & Descrypting

```cs
string publicRSAKey, privateRSAKey = "";
RSAHelper.GenerateKey(out publicRSAKey, out privateRSAKey);
string encryptText = RSAHelper.Encrypt(publicRSAKey, planText);
string decryptText = RSAHelper.Decrypt(privateRSAKey, encryptText);
```

### TripleDES Encrypting & Descrypting

```cs
string key = "your-keys-sqoy19";
string encryptText = TripleDESHelper.Encrypt(key, planText);
string decryptText = TripleDESHelper.Decrypt(key, encryptText);
```

### AES Encrypting & Descrypting

```cs
string key = "YourKey";
string encryptText = AESHelper.Encrypt(key, planText);
string decryptText = AESHelper.Decrypt(key, encryptText);
}
```

