using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels.jwt
{
    public class JwtModels
    {
        public static class Roles
        {
            public const string ROLE_API_ADMIN = "APIAdmin";
        }

        public class TokenConfigurations
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public int Seconds { get; set; }
        }
    }
}
