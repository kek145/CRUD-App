using System.ComponentModel.DataAnnotations;

namespace CRUD.Domain.DTOs
{
    public class UserDto
    {
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}