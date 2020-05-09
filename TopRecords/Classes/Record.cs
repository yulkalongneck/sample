using System;
namespace TopRecords.Classes
{
    public class Record
    {
        public Record(string line)
        {
            //find score
            Score = Convert.ToInt32(line.Split(':')[0]);

            //temp assign the json string object as an id
            ID = line.Split(':')[1];
        }

        //json serialize to score
        public int Score { get; set; }
        //json serialize to id
        public string ID { get; set; }

        private static string ParseRecord(string s, int part)
        {
            int index = s.IndexOf(':');
            string result;
            try
            {
                if(part == 1)
                {
                    result = s.Substring(0, index);
                } else if(part == 2)
                {

                }
                string score = 
                string json = s.Substring(index + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return result;
        }
    }
}
