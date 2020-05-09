using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TopRecords.Classes;

namespace TopRecords.Files
{
    //File has Name, many Records, and top results
    public class File
    {
        public File(string name)
        {
            Name = name;
            Records = new List<Record>();
        }

        public List<Record> Records { get; set; }
        public string Name { get; set; }

        

        // read file, adds sorted items File.Records 
        public void GetFile()
        {
            try
            {
                // using StreamReader read/import a file
                // and add each line to a string list
                using (StreamReader reader = new StreamReader("/Users/julka/Desktop/" + this.Name))
                {
                    string line;
                    // Read line by line  
                    while ((line = reader.ReadLine()) != null)
                    {
                        Record record = new Record(line.Replace(@"\", ""));
                        this.Records.Add(record);
                    }
                }
                this.Records = this.Records.OrderBy(x => x.Score).ToList();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

    }
}