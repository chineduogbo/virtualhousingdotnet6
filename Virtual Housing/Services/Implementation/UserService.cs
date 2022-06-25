using AutoMapper;
using MongoDB.Driver;
using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private readonly IMapper _mapper;
        public UserService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl:root");
            _mapper = mapper;
        }
        public async Task<User> CreateUser(CreateUserDto model)
        {if (model != null)
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
                var dblist = dbClient.GetDatabase("virtualx").GetCollection<User>("User").AsQueryable().Where(x => x.Username == model.Username).FirstOrDefault();
                if (dblist == null)
                {
                    var user = _mapper.Map<User>(model);
                    user.active = true;
                    user.lastlogin = DateTime.Now;

                    dbClient.GetDatabase("virtualx").GetCollection<User>("User").InsertOne(user);
                    return user;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();            }
        }

        public async Task<User> Login(LoginDto model)
        {
            if (model != null)
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
                var dblist = dbClient.GetDatabase("virtualx").GetCollection<User>("User").AsQueryable().Where(x => x.Username == model.UserName && x.password == model.Password).FirstOrDefault();
                if (dblist != null)
                {
                    return dblist;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
