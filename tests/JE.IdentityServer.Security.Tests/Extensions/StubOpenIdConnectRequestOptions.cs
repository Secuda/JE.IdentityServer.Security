﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using JE.IdentityServer.Security.OpenIdConnect;
using JE.IdentityServer.Security.Resources;

namespace JE.IdentityServer.Security.Tests.Extensions
{
    internal class StubOpenIdConnectRequestOptions : IOpenIdConnectRequestOptions
    {
        public StubOpenIdConnectRequestOptions()
        {
            ProtectedPath = "identity/connect/token";
            ProtectedGrantTypes = new[] { "password" };
            ExcludedUsernameExpressions = new[] {new Regex("example.com$")};
            NumberOfAllowedLoginFailures = 10;
            ExcludedSubnets = new[] {new IPNetwork("192.168.100.0/24")};
        }

        public string ProtectedPath { get; }

        public IEnumerable<string> ProtectedGrantTypes { get; }

        public IEnumerable<Regex> ExcludedUsernameExpressions { get; }

        public IEnumerable<IPNetwork> ExcludedSubnets { get; set; }

        public int NumberOfAllowedLoginFailures { get; }
    }
}