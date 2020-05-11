using System;
using TopRecords.Classes;

namespace TopRecords
{
    class Program
    {
        static int Main(string[] args)
        {
            //Console.WriteLine("Please insert full file path:");
            var filepath = args[0];

            //Console.WriteLine("Please insert max n of results (int):");
            var nScores = Convert.ToInt32(args[1]);
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
