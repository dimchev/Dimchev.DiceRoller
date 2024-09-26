using Microsoft.AspNetCore.Http;

namespace Dimchev.DiceRoller.Auth.Core.Dtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IFormFile? Image { get; set; }
    }
}
