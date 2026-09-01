using Association.Domain.Members;
using Hivify.UseCases.Abstractions.Messaging;

public sealed record AddStaffMemberCommand(
    Guid AssociationId,
    Guid UserId,
    string FullName,
    string Email,
    MemberRole Role) : ICommand<MemberID>;