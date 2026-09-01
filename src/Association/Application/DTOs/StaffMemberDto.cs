using Association.Domain.Members;

namespace Association.Application.DTOs
{
    public sealed record StaffMemberDto(
        Guid Id,
        string FullName,
        string Email,
        MemberRole Role
    );
}
