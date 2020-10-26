using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Generator
{
    class Program
    {
        static void Main()
        {
           while (true) //So the process runs until the user exits
            {
                Run(); //The main function
            }
        }
        private static string FixString(string file) //Gets rid of invalid (most) characters in filenames
        {
            return file.Replace("\"", "");
        }
        private static void Run() //The main function
        {
            Console.Clear();
            Console.Title = "MD5 Hash Generator | Simp#0174";
            Console.WriteLine("Drop File: ");
            string file = FixString(Console.ReadLine());
            string hash = GetMD5(file);
            Console.Clear();
            Console.WriteLine(hash);
            Console.ReadKey();
        }
        private static string GetMD5(string file) //The actual MD5 Generator Code. Basically just reads the file and then converts the result to a string.
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }
    }
}
