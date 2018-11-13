using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TriWebAPI.Models
{
    public class Triathlon
    {
        public ObjectId Id { get; set; }
        [BsonElement("date")]
        public string date { get; set; }
        [BsonElement("year")]
        public string year { get; set; }
        [BsonElement("month")]
        public string month { get; set; }
        [BsonElement("day")]
        public string day { get; set; }
        [BsonElement("place")]
        public string place { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("tri_event")]
        public List<Event> tri_event { get; set; }
        [BsonElement("remark")]
        public string remark { get; set; }
        [BsonElement("organizer")]
        public string organizer { get; set; }
        [BsonElement("location")]
        public string location { get; set; }
        [BsonElement("locationmap")]
        public string locationmap { get; set; }
        [BsonElement("applydate")]
        public string applydate { get; set; }
        [BsonElement("onlineapplyurl")]
        public string onlineapplyurl { get; set; }
        [BsonElement("status")]
        public string status { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime in_date { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime up_date { get; set; }

    }
}
