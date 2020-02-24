using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
