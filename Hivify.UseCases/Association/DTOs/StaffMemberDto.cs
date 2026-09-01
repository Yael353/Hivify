using Hivify.Core.Aggregates.Associations.Members;

namespace Hivify.UseCases.Association.DTOs
{
    public sealed record StaffMemberDto(
        Guid Id,
        string FullName,
        string Email,
        MemberRole Role
    );
}
