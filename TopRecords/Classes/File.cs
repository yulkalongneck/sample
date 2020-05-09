using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TopRecords.Classes;
using System.Json;
using Newtonsoft.Json;

namespace TopRecords.Files
{
    //File has Name, many Records
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
                        //remove any previously added record with score equal to the current record.Score
                        this.Records.RemoveAll(r => r.Score == record.Score);

                        // add the current record
                        this.Records.Add(record);
                    }
                }
      
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                //check if json string is a valid json; if false- abort;
                foreach (var r in topRecords)
                {
                    JsonValue.Parse(r.JsonString);
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

        //write Results to a console;
        private static void WriteTopResults(List<Record> topRecords)
        {
            List<Result> results = new List<Result>();
            foreach (var r in topRecords)
            {
                results.Add(new Result(r.Score, r.JsonString)); 
            }
            var json = JsonConvert.SerializeObject(results, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}