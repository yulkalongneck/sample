﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Json;
using Newtonsoft.Json;

namespace TopRecords.Classes
{
    //File has path, many Records
    public class DataFile
    {
        public DataFile(string filePath)
        {
            FilePath = filePath;
            Records = new List<Record>();
        }

        public List<Record> Records { get; set; }
        public string FilePath { get; set; }

        

        // read file, adds sorted items File.Records 
        public void GetFile()
        {
            try
            {
                // using StreamReader read/import a file
                // and add each line to a string list
                using (StreamReader reader = new StreamReader(this.FilePath))
                {
                    string line;
                    // Read line by line
                    Dictionary<int, bool> recs = new Dictionary<int, bool>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            Record record = new Record(line.Replace(@"\", ""));
                            //remove any previously added record with score equal to the current record.Score

                            if (recs[record.Score])
                            {
                                this.Records.RemoveAll(r => r.Score == record.Score);
                            }
                            
                            // add the current record
                            this.Records.Add(record);
                            recs[record.Score] = true;
                        }
                        catch 
                        {
                            Console.WriteLine("invalid json format No JSON object could be decoded");
                            Console.WriteLine("THIS IS NOT JSON");
                        }
                     
                    }
                    reader.Dispose();
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

        public void GetTop(int top)
        {

            try
            {
                List<Record> topRecords = this.Records.Take(top).ToList();
                //check if json string is a valid json; if false- abort;
                foreach (var r in topRecords)
                {
                    r.ID = JsonValue.Parse(r.JsonString)["id"];
                }
                WriteTopResults(topRecords);
            }
            catch
            {
                Console.WriteLine("invalid json format No JSON object could be decoded");
                Console.WriteLine("THIS IS NOT JSON");
            }
        }

        //write Results to a console;
        private static void WriteTopResults(List<Record> topRecords)
        {
            try
            {
                var json = JsonConvert.SerializeObject(topRecords, Formatting.Indented);
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
    }
}