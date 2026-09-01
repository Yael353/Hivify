using Association.Application.Abstractions;
using Association.Application.DTOs;
using Association.Application.Queries.GetAssociation;
using Hivify.Association.Application.DTOs;
using Hivify.Association.Domain.Associations;
using SharedKernel.Messaging;

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
        var AssociationEntity =
            await _associationRepository.GetByIdAsync(
                new AssociationID(query.AssociationId),
                cancellationToken);

        if (AssociationEntity is null)
            throw new InvalidOperationException(
                "AssociationEntity was not found.");

        return new AssociationListDto
        {
            Id = AssociationEntity.Id.Value,
            Name = AssociationEntity.Name.Value,

            StaffMembers = AssociationEntity.StaffMembers
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


