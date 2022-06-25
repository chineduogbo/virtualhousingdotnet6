using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Services.Interfaces
{
    public interface IPrivateListingService
    {
        Task<SuccessDto> CreatePrivateListing(PrivateListingDto model);
        Task<List<PrivateListing>> ViewPrivateListings();
        Task<SuccessDto> EditPrivateListing(PrivateListing model);
        Task<SuccessDto> DeletePrivateListing(PrivateListing model);
    }
}
