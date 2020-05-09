using System;
using TopRecords.Files;

namespace TopRecords
{
    class Program
    {
        static int Main(string[] args)
        {
            // read the string filename
            string input = Console.ReadLine();
            string filename = input.Split(' ')[0]; //highest score_recs.data
            int nScores = Convert.ToInt32(input.Split(' ')[1]);

            //read file
            File file = new File(filename);
            file.GetFile();

            //possible sorting ASC. Keeping it as a public method
            file.SortDesc();

            // get top N scores 
            file.GetTop(nScores);
            return 0;
        }
    }
}
