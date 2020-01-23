using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Options
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
