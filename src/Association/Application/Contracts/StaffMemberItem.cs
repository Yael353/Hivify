using Hivify.Association.Domain.Members;

namespace Association.Application.Contracts
{
    public sealed record StaffMemberItem(
        Guid Id,
        string FullName,
        string Email,
        MemberRole Role
    );
}



