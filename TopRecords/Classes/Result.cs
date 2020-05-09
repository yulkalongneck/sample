using System;
using System.Json;
using Newtonsoft.Json;

namespace TopRecords.Classes
{
    public class Result
    {
        public Result(int score, string jsonString)
        {
            Score = score;
            ID = JsonValue.Parse(jsonString)["id"];
        }

        [JsonPropertyAttribute ("score")]
        public int Score { get; set; }

        [JsonPropertyAttribute("id")]
        public string ID { get; set; }
    }
}
