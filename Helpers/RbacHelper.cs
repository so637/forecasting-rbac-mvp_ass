using Microsoft.AspNetCore.Mvc;

namespace Forecast.Api.Helpers;

public static class RbacHelper
{
    public static bool HasRole(HttpRequest request, params string[] allowedRoles)
    {
        if (!request.Headers.TryGetValue("X-User-Role", out var role))
            return false;

        return allowedRoles.Contains(role.ToString());
    }
}
