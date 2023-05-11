using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace email
{
    class Program
    {
        static void Main(string[] args)
        {
            char check = '0';
            do {
                try
                {
                    string fileName = @"mydata.txt";

                    // Delete the file if it exists.
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    // Create the file.
                    Console.WriteLine("Enter how many ids you want");
                    int datalen = Convert.ToInt32(Console.ReadLine());
                    FileCreator(datalen);
                }
                catch (Exception MyExcep)
                {
                    Console.WriteLine(MyExcep.ToString());
                }
                ConsoleKeyInfo key = Console.ReadKey();
                check = key.KeyChar;
            } while (check == '1');
        }
        public static void FileCreator(int datalen)
        {
            string password, email;
            string fileName = @"mydata.txt";

            using (StreamWriter fileStr = File.CreateText(fileName))
            {
                
                fileStr.WriteLine("\tEmails\t\t\t\tPassword\n");
                for (int i = 1; i <= datalen; i++) {
                    for (int j = 1; j <= 100; j++)
                    {
                        RandomPasswordGenerator randomPasswordGenerator = new RandomPasswordGenerator();
                        email = (GenerateFirstName(6)) + (EmailNo(true, 4)) + (Email());
                        password = randomPasswordGenerator.GeneratePassword(true, 8);
                        fileStr.WriteLine("{0} {1} \t\t\t{2}", j, email, password);
                    }
                    fileStr.WriteLine("\n-----------------------------------------\n");
                }
            }
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("");
            }
        }
        public static string GenerateFirstName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)];
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            //string email = EmailNo(true,4);
            return Name;
        }
        public static string Email()
        {
            Random r = new Random();
            string[] suffix = { "@vintomaper.com", "@tovinit.com", "@mentonit.net" };
            string rnd = suffix[r.Next(suffix.Length)];
            return rnd;
        }
        const string EMAIL_NO = "1234567890";
        public static string EmailNo(bool usenumber, int len)
        {
            char[] _emailno = new char[len];
            string charSet = "";
            Random _random = new Random();
            int counter;
            if (usenumber) charSet += EMAIL_NO;
            for (counter = 0; counter < len; counter++)
            {
                _emailno[counter] = charSet[_random.Next(charSet.Length - 1)];
            }
            return String.Join(null, _emailno);
        }
    }
    class RandomPasswordGenerator
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@£$%&#€";
        public string GeneratePassword(bool useLowercase, int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            Random _random = new Random();
            int counter;

            // Build up the character set to choose from
            if (useLowercase) charSet += LOWER_CASE;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }
            return String.Join(null, _password);
        }
    }
}
