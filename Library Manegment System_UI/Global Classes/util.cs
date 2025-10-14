using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
            
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
         
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
            
        }
     
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }
       
        public static  bool CopyImageToProjectImagesFolder(ref string  sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\Library-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
             
              File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show (iox.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile= destinationFile;
            return true;
        }

        public static string  GetPublicKey()
        { 
            string publicKey="";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKey = rsa.ToXmlString(false);
            }
            return  publicKey;
        }

        public static string GetPrivateKey()
        { 
            string privateKey = "";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            { 
                privateKey = rsa.ToXmlString(true);
            }

            return privateKey;
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }
        }

        static private Random number = new Random();

        static private char GeneratRandomcharacter()
        {

            byte CharacterByBayte = (byte)number.Next(48, 100);

            char Character = (Char)CharacterByBayte;

            return Character;
        }

        public static string GetgeneralKey(short lengthpassword = 7)
        {
            string password = "";
            for (short i = 0; i < lengthpassword; i++)
            {

                password += GeneratRandomcharacter();

            }
            return password;
        }
     
        private static string _key = "1234567890123456" ;

        public static string Key 
        {
            get { return _key; }
        }

        public static string Encrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                /*
                Here, you are setting the IV of the AES algorithm to a block of bytes 
                with a size equal to the block size of the algorithm divided by 8. 
                The block size of AES is typically 128 bits (16 bytes), 
                so the IV size is 128 bits / 8 = 16 bytes.
                 */
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
     
        public static bool ISPassowordTrue(string OriginalPassoword, string hashedPassowrd) 
        {
           if(ComputeHash(OriginalPassoword)==hashedPassowrd)
                return true;

           return false;
        }

        public static byte[] GeneratearandomIV()
        {
            byte[] iv;
            using (Aes aesAlg = Aes.Create())
            {
                iv = aesAlg.IV;
            }
            return iv;
        }

        static void EncryptFile(string inputFile, string outputFile, string key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
                using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                {
                    // Write the IV to the beginning of the file
                    fsOutput.Write(iv, 0, iv.Length);
                    fsInput.CopyTo(cryptoStream);
                }
            }
        }

        static void DecryptFile(string inputFile, string outputFile, string key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = System.Text.Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
                using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
                using (CryptoStream cryptoStream = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write))
                {
                    // Skip the IV at the beginning of the file
                    fsInput.Seek(iv.Length, SeekOrigin.Begin);
                    fsInput.CopyTo(cryptoStream);
                }
            }
        }

        public static void FillComboBox(Guna2ComboBox comboBox, DataTable dataTable, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
        }



    }
}
