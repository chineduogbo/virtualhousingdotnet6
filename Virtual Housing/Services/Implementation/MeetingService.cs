using AutoMapper;
using MongoDB.Driver;
using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Services.Implementation
{
    public class MeetingService : IMeetingService
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private readonly IMapper _mapper;
        public MeetingService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl:root");
            _mapper = mapper;
        }
        public async Task<SuccessDto> CreateMeeting(DateTime? ScheduledAt, string UserId)
        {

            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));

           Meetings meetings= new() { active = true,CreatedAt=DateTime.Now,ScheduledAt= ScheduledAt,UserId =UserId };

            dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").InsertOne(meetings);
            return new SuccessDto() { Id = 1, SuccessMessage = "Listing Created" };
        }

        public async Task<SuccessDto> DeleteMeeting(string Id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var filter = Builders<Meetings>.Filter.Eq("_id", Id);
            dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").DeleteOne(filter);

            return new SuccessDto() { Id = 0, SuccessMessage = "Deleted Successfully" };
        }

        public async Task<SuccessDto> EditMeeting(Meetings model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var filter = Builders<Meetings>.Filter.Eq("_id", model._id);
            var updateTime = Builders<Meetings>.Update.Set("ScheduledAt", model.ScheduledAt);
            dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").UpdateOne(filter, updateTime);
         

            return new SuccessDto() { Id = 0, SuccessMessage = "Edited Successfully" };
        }

        public async Task<Meetings> ViewMeeting(string Id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var dblist = dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").AsQueryable().Where(x=>x._id == Id).FirstOrDefault();
            return dblist;
        }

        public async Task<List<Meetings>> ViewMeetings(string UserId)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var dblist = dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").AsQueryable().Where(x => x.UserId == UserId).ToList();
            return dblist;
        }

        public async Task<List<Meetings>> ViewMeetingsCreated(string UserId)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var dblist = dbClient.GetDatabase("virtualx").GetCollection<Meetings>("Meetings").AsQueryable().Where(x => x.UserId == UserId).ToList();
            return dblist;
        }
    }
}
