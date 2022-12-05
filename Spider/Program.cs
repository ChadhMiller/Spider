using System.IO;
using System.Text.RegularExpressions;



//find all files with the word in it like a web scraper like Linux grep command

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> fileList = new List<string>();
        List<string> directoryList = new List<string>();
        List<string> fileContainsWord = new List<string>();

        Console.WriteLine("What path do you want to start looking from");
        string? startingPath = Console.ReadLine();//    works to this point C:/users/chadh/code

        Console.WriteLine("What word do you want to search for?");
        string? word = Console.ReadLine();

        //FileAttributes attributes = File.GetAttributes(startingPath);
        //if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        //{
        //    attributes &= ~FileAttributes.ReadOnly;
        //    File.SetAttributes(startingPath, attributes);
        //
        //}


        GetInfo(startingPath);
        for (int x = 0; x < directoryList.Count; x++)
        {
            GetInfo(directoryList[x]);
        }



        bool CheckWord(string f)
        {
            var fileContent = File.ReadAllText(f);

            if (fileContent.Contains(word))

                return true;
            else return false;
        }



        void GetInfo(string start)
        {
            var direc = Directory.GetDirectories(start);
            var files = Directory.GetFiles(start);
            foreach (string d in direc)
            {

                directoryList.Add(d);

            }

            foreach (string f in files)
            {

                fileList.Add(Path.GetFullPath(f));

            }

        }

        //find the word and count word
        Console.WriteLine("#############################################FilesWithInput##########################################################");
        int count = 0;
        foreach (string f in fileList)
        {

            if (CheckWord(f))
            {
                //int count = Regex.Matches(f, word).Count;
                //Console.WriteLine((new Regex($@"(?i)\b{word}\b")).Matches(f).Count);
                fileContainsWord.Add(f);
                Console.WriteLine(f);
                //Console.WriteLine($"The number of words you searched for in this file is: {count}");

                using (StreamReader reader = File.OpenText(f))
                {
                    string contents = reader.ReadToEnd();
                    MatchCollection matches = Regex.Matches(contents, word);
                    count = matches.Count;
                }


        
                Console.WriteLine($"The number of \"{word}\" in the file is {count}");
        File.AppendAllText("Save.txt", Convert.ToString(count));
            }

        }
                File.AppendAllLines("Save.txt", fileContainsWord);
        

        

        Console.ReadKey();
    }
}


// try to throw a catch to see the error message and or ignore it.





