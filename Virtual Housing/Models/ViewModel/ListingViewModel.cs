﻿using Virtual_Housing.DropDownLists;
using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Models.ViewModel
{
    public class ListingViewModel
    {
        public CreateListingDto createListingDto { get; set; }
        public List<Listings> Listings { get; set; }
        public List<string> Categories { get; set; }
        public DropDownValues DropDown { get; set; }
        public bool Successful { get; set; }    
    }
}
