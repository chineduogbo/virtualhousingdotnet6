using Microsoft.AspNetCore.Mvc;
using Virtual_Housing.Models.ViewModel;
using Virtual_Housing.Services.Interfaces;

namespace Virtual_Housing.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingService _listingService;
        public ListingsController(IListingService listingService)
        {
            _listingService = listingService;
        }

        public async Task<IActionResult> Index()
        {
            ListingViewModel model = new();
            model.Listings = await _listingService.ViewListings();
            return View(model);
        }
        public IActionResult CreateListing()
        {
            ListingViewModel model = new();
            return View(model);
        }
    }
}
