namespace RealTimeUber.DTO
{
    public class LoginDto
    {
   //     public string? UserName { get; set; }
        public string Password { get; set; }
       public string Email { get; set; }
    }
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
    }

    public class UserRegistrationDto
    {
        public string? UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }





    }
}
