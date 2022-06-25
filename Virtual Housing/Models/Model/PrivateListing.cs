using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Virtual_Housing.Models.Model
{
    public class PrivateListing
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public bool active { get; set; }
        public DateTime? TimeCreated { get; set; }
 
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string ParticipantsId { get; set; }
      
        public string ParticipantsUserName { get; set; }

        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string[] ImageUrl { get; set; }
    }
}
