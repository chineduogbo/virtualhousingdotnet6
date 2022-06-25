using Virtual_Housing.Models.Dto;

namespace Virtual_Housing.Models.ViewModel
{
    public class HomeViewModel
    {
        public CreateUserDto CreateUserDto { get; set; }
        public LoginDto LoginDto { get; set; }    
        public bool Error { get; set; }
    }
}
