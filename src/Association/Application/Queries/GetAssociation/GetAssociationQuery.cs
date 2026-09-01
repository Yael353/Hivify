using Association.Application.DTOs;
using SharedKernel.Messaging;

namespace Association.Application.Queries.GetAssociation;

public sealed record GetAssociationQuery(Guid AssociationId) : IQuery<AssociationListDto>;


