using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Services.Interfaces
{
    public interface IListingService
    {
        Task<SuccessDto> CreateListing(CreateListingDto model);
        Task<List<Listings>> ViewListings();
        Task<SuccessDto> EditListing(Listings model);
        Task<SuccessDto> DeleteListing(Listings model);
    }
}
