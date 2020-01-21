using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Models
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
