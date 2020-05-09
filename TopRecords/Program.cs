using System;
using System.IO;
using TopRecords.Files;

namespace TopRecords
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Please insert file name");
            var filename = Console.ReadLine();
            Console.WriteLine(Path.Combine(Environment.CurrentDirectory, @"./", filename));

            Console.WriteLine("Number of top results (int):");
            var nScores = Convert.ToInt32(Console.ReadLine());
            //assume that inputs are valid

            //read file
            File file = new File(filename);
            file.GetFile();

            // Keeping it as a public method
            file.SortDesc();

            // get top N scores 
            file.GetTop(nScores);
            return 0;
        }
    }
}
