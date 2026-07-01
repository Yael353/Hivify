

using Ansjon.UseCases.Communications.InterFaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ansjon.Infrastructure.Identity;

public class CurrentUser : ICurrentUser
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public CurrentUser(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<Guid> GetUserIdAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        var user = authState.User;

        if (user.Identity?.IsAuthenticated != true)
            throw new UnauthorizedAccessException("User is not authenticated.");

        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(id, out var userId))
            throw new InvalidOperationException("User ID claim is invalid.");

        return userId;
    }
}

