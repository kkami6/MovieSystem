using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.UserDtos
{
    public class UserBaseDto
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
        
        public string Email { get; set; } = default!;
        
        public DateTime DateOfBirth { get; set; }

    }
}
