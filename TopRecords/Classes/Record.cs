using System;
using Newtonsoft.Json;

namespace TopRecords.Classes
{
    //Record belongs to a file, has a score and unique id
    public class Record
    {
        public Record(string line)
        {
            //find score
            Score = Convert.ToInt32(ParseRecord(line, 1));    
            JsonString = ParseRecord(line, 2);
        }

        [JsonPropertyAttribute("score")]
        public int Score { get; set; }

        [JsonIgnore]
        public string JsonString { get; set; }

        [JsonPropertyAttribute("id")]
        public string ID { get; set; }


        private static string ParseRecord(string s, int part)
        {
            int index = s.IndexOf(':');
            string result = String.Empty;
            try
            {
                if(part == 1){
                   result = s.Substring(0, index).Trim();
                }
                else if(part == 2){
                   result = s.Substring(index + 1).Trim();
                }               
            }
            catch 
            {
                Console.WriteLine("Invalid input string in ParseRecord");
            }
            return result;
        }
    }
}
