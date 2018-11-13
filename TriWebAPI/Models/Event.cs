using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TriWebAPI.Models
{
    public class Event
    {
        [BsonElement("eventgroup")]
        public string eventgroup { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("startDate")]
        public string startDate { get; set; }
        [BsonElement("startTime")]
        public string startTime { get; set; }
        [BsonElement("cost")]
        public string cost { get; set; }
        [BsonElement("timelimit")]
        public string timelimit { get; set; }
    }
}
