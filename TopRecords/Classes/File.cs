using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TopRecords.Classes;
using System.Json;
using Newtonsoft.Json;

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
      
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        public void SortDesc()
        {
            try
            {
                this.Records = this.Records.OrderByDescending(x => x.Score).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetTop(int top)
        {
            List<Record> topRecords = new List<Record>();
            try
            {
                topRecords = this.Records.Take(top).ToList();

                // write result:  top N if Record.Data is a valid json object
                foreach (var r in topRecords)
                {
                    JsonValue.Parse(r.ID);
                }  
            }
            catch
            {
                Console.WriteLine("invalid json format No JSON object could be decoded");
                Console.WriteLine("THIS IS NOT JSON");
                return -1;
            }

            WriteTopResults(topRecords);
            return 0;
        }

        private static void WriteTopResults(List<Record> topRecords)
        {
            List<Result> results = new List<Result>();
            foreach (var r in topRecords)
            {
                results.Add(new Result(r.Score, r.ID)); 
            }
            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}