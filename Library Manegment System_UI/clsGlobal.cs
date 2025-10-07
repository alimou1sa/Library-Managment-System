
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Library_Business;
using Library_Manegment_System;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Json;

namespace Library
{
    public class clsGlobal
    {

     
       
        public static clsUsers CurrentUser { get; set; }
        




        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
    
        

        static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\LibraryProject";
        public static void  RememberUsernameAndPasswordByRegjistry(object sender, clsLoginEventArgs e)
        {

            string valueName1 = "Username";
            string valueData1 = e.UserName;

            string valueName2 = "Password";
            string valueData2 = e.Passoword;

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, valueName1, valueData1, RegistryValueKind.String);

                Registry.SetValue(keyPath, valueName2, valueData2, RegistryValueKind.String);
      
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
      
            }

      
        }
        public static bool GetStoredCredentialByRegjistry(ref string Username, ref string Password)
        {

            string valueName1 = "Username";
            string valueName2 = "Password";

            try
            {
                // Read the value from the Registry
                string value1 = Registry.GetValue(keyPath, valueName1, null) as string;
                string value2 = Registry.GetValue(keyPath, valueName2, null) as string;

                if (value1 != null)
                {
                    Username = value1;

                    if (value2 != null)
                    {
                        Password = value2;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }


        }




    }
}
