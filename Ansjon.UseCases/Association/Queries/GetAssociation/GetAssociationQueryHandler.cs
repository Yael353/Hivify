using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Association.DTOs;
using Ansjon.UseCases.Association.Queries.GetAssociation;

public sealed class GetAssociationQueryHandler
    : IQueryHandler<GetAssociationQuery, AssociationListDto>
{
    private readonly IAssociationRepo _associationRepository;

    public GetAssociationQueryHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<AssociationListDto> Handle(
        GetAssociationQuery query,
        CancellationToken cancellationToken)
    {
        var association =
            await _associationRepository.GetByIdAsync(
                new AssociationID(query.AssociationId),
                cancellationToken);

        if (association is null)
            throw new InvalidOperationException(
                "Association was not found.");

        return new AssociationListDto
        {
            Id = association.Id.Value,
            Name = association.Name.Value,

            StaffMembers = association.StaffMembers
                .Where(member => member.DeletedAt == null)
                .Select(member => new StaffMemberDto(
                    member.Id.Value,
                    member.FullName.Value,
                    member.Email.Value,
                    member.Role))
                .ToList()
        };
    }
}