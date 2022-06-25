using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MongoDB.Driver;
using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Services.Implementation
{
    public class ListingService : IListingService
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private readonly IMapper _mapper;
        public ListingService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseUrl = _configuration.GetValue<string>("BaseUrl:root");
            _mapper = mapper;
        }
        public async Task<SuccessDto> CreateListing(CreateListingDto model)
        {
            if (model != null)
            {
                List<string> ImageUrls = new List<string>();
                if (model.ImageUrl?.Count > 0)
                {
                    foreach(var item in model.ImageUrl)
                    {
                        string url = await UploadImages(item);
                        ImageUrls.Add(url); 
                    }
                }
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
               
                    var listings = _mapper.Map<Listings>(model);
                    listings.active = true;
                    listings.TimeCreated = DateTime.Now;
                    listings.ImageUrl= ImageUrls.ToArray(); 

                    dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").InsertOne(listings);
                    return new SuccessDto() { Id = 1,SuccessMessage="Listing Created"};
               
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<SuccessDto> DeleteListing(Listings model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var filter = Builders<Listings>.Filter.Eq("_id", model._id);
            dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").DeleteOne(filter);

            return new SuccessDto() { Id = 0, SuccessMessage = "Deleted Successfully" };
        }

        public async Task<SuccessDto> EditListing(Listings model)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var filter = Builders<Listings>.Filter.Eq("_id", model._id);
            var updateTitle = Builders<Listings>.Update.Set("Title", model.Title);
            var updateDescription = Builders<Listings>.Update.Set("Description", model.Description);
            var updatePricePerEntry = Builders<Listings>.Update.Set("Description", model.PricePerEntry);
            var updateAddress = Builders<Listings>.Update.Set("Description", model.Address);
            dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").UpdateOne(filter, updateTitle);
            dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").UpdateOne(filter, updateDescription);
            dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").UpdateOne(filter, updatePricePerEntry);
            dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").UpdateOne(filter, updateAddress);


            return new SuccessDto() { Id = 0, SuccessMessage = "Edited Successfully" };
        }

        public async Task<List<Listings>> ViewListings()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("Virtualxconnection"));
            var dblist = dbClient.GetDatabase("virtualx").GetCollection<Listings>("Listings").AsQueryable().ToList();
            return dblist;
        }

        public async Task<string> UploadImages (IFormFile model)
        {
            Stream stream = new MemoryStream(ConvertIformFile(model));
            Account account = new Account("dds639wmo","873337373751463","y5DdPzsZfRo3puuWKlXTQDjVLyw");
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams
            {
                
            File = new FileDescription(model.FileName, stream),
                //transformation code here
                Transformation = new Transformation().Width(200).Height(200).Crop("thumb").Gravity("face")
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }
        public byte[] ConvertIformFile(IFormFile file)
        {
            
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    return fileBytes;
                    }
               
                }
            throw new Exception();
            
        }
    }
}
