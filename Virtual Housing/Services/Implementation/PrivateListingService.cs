using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Services.Implementation
{
    public class PrivateListingService : IPrivateListingService
    {
        public Task<SuccessDto> CreatePrivateListing(PrivateListingDto model)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessDto> DeletePrivateListing(PrivateListing model)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessDto> EditPrivateListing(PrivateListing model)
        {
            throw new NotImplementedException();
        }

        public Task<List<PrivateListing>> ViewPrivateListings()
        {
            throw new NotImplementedException();
        }
    }
}
