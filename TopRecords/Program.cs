using System;
using System.IO;
using TopRecords.DataFiles;


namespace TopRecords
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Please insert full file path:");
            var filepath = Console.ReadLine();

            Console.WriteLine("Please insert max n of results (int):");
            var nScores = Convert.ToInt32(Console.ReadLine());
            //assume that inputs are valid

            //read file
            DataFile file = new DataFile(filepath);
            file.GetFile();

            // Keeping it as a public method
            file.SortDesc();

            // get top N scores 
            file.GetTop(nScores);
            return 0;
        }
    }
}
