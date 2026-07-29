using Ansjon.Core.Aggregates.Associations.Staff;

namespace Ansjon.UseCases.Association.DTOs
{
    public sealed record StaffMemberDto(
        Guid Id,
        string FullName,
        StaffRole Role
    );
}
