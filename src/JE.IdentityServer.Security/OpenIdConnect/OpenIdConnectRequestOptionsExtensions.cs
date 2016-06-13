using System;
using System.Linq;

namespace JE.IdentityServer.Security.OpenIdConnect
{
    public static class OpenIdConnectRequestOptionsExtensions
    {
        public static bool Matches(this IOpenIdConnectRequestOptions openIdConnectRequestOptions, IOpenIdConnectRequest openIdConnectRequest)
        {
            var grantType = openIdConnectRequest.GetGrantType();
            var path = openIdConnectRequestOptions.ProtectedPath;
            if (string.IsNullOrEmpty(grantType) || string.IsNullOrEmpty(path))
            {
                return false;
            }

            return path.Equals(openIdConnectRequest.GetPath(), StringComparison.OrdinalIgnoreCase) && 
                   openIdConnectRequestOptions.ProtectedGrantTypes.Contains(grantType);
        }

        public static bool IsExcluded(this IOpenIdConnectRequestOptions options, IOpenIdConnectRequest openIdConnectRequest)
        {
            var username = openIdConnectRequest.GetUsername();
            if (!string.IsNullOrEmpty(username) &&
                options.ExcludedUsernameExpressions.Any(regex => regex.IsMatch(username))) return true;

            return options.ExcludedSubnets.Any(excludedSubnet => excludedSubnet.Contains(openIdConnectRequest.GetRemoteIpAddress()));
        }
    }
}