namespace Ansjon.UseCases.Association.DTOs;

public sealed class AssociationListDto
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public IReadOnlyList<StaffMemberDto> StaffMembers { get; init; } = [];
}