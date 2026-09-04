using Association.Application.Contracts;
using SharedKernel.Messaging;

namespace Association.Application.Queries.GetAssociation;

public sealed record GetAssociationQuery(Guid AssociationId) : IQuery<AssociationListItem>;


