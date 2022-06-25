namespace Virtual_Housing.Models.Dto
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string password { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class LoginDto
    {
        public string UserName { get; set; }
        public string? Password { get; set; }
    }
}
