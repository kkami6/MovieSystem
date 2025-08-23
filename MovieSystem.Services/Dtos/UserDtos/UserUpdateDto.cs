using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.UserDtos
{
    public class UserUpdateDto: UserBaseDto
    {
        public int Id { get; set; }
    }
}
