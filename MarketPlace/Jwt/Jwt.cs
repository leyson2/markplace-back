using System.Security.Claims;

namespace MarketPlace.Jwt
{
    public class Jwt
    {
        public string JWT_SECRET_KEY { get; set; } = null!;
        public string JWT_AUDIENCE_TOKEN { get; set; } = null!;
        public string JWT_ISSUER_TOKEN { get; set; } = null!;
        public string JWT_EXPIRE_MINUTES { get; set; } = null!;
        public string JWT_SECR { get; set; } = null!;
    }
}
