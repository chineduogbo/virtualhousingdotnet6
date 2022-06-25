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
        [HttpGet]
        public IActionResult CreateListing()
        {
            ListingViewModel model = new()
            {
                DropDown = new(),
                createListingDto = new()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateListing(ListingViewModel model)
        {
            var createlist = _listingService.CreateListing(model.createListingDto);
            if (createlist?.Id > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Successful = false;
                return View(model);
            }
        }
    }
}
