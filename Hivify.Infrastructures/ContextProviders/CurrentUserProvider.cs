using Hivify.UseCases.Abstractions.Context;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Hivify.Infrastructures.ContextProviders;

public class CurrentUserProvider : ICurrentUser
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public CurrentUserProvider(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<Guid> GetUserIdAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        var user = authState.User;

        if (user.Identity?.IsAuthenticated != true)
            throw new UnauthorizedAccessException();

        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return Guid.Parse(id!);
    }



    public async Task<bool> IsInRoleAsync(string role)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        return authState.User.IsInRole(role);
    }
}
