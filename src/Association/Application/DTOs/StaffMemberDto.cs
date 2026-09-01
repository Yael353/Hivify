using Hivify.Association.Domain.Members;

namespace Hivify.Association.Application.DTOs
{
    public sealed record StaffMemberDto(
        Guid Id,
        string FullName,
        string Email,
        MemberRole Role
    );
}



