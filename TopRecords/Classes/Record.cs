using System;
namespace TopRecords.Classes
{
    public class Record
    {
        public Record(string line)
        {
            //find score
            Score = Convert.ToInt32(ParseRecord(line, 1));

            //temp assign the json string object as an id
            ID = ParseRecord(line, 2);
        }

        public int Score { get; set; }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return result;
        }
    }
}
