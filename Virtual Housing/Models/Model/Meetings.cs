using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Virtual_Housing.Models.Model
{
    public class Meetings
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string UserId { get; set; }
        public Participants[] Participants { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public bool active { get; set; }
        public string Urlvideo { get; set; }
    }
    public class Participants
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public bool ? Active { get; set; }
    }
}
