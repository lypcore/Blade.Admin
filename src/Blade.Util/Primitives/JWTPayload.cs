using System;

namespace Blade.Util
{
    public class JWTPayload
    {
        public string UserId { get; set; }
        public DateTime Expire { get; set; }
    }
}
