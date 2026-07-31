using Ansjon.Core.Aggregates.Associations.Members;

namespace Ansjon.UseCases.Association.DTOs
{
    public sealed record StaffMemberDto(
        Guid Id,
        string FullName,
        MemberRole Role
    );
}
