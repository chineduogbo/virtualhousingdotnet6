namespace Virtual_Housing.Models.Dto
{
    public class PrivateListingDto
    {


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
