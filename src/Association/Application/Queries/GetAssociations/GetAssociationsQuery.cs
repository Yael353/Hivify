using Association.Application.Contracts;
using SharedKernel.Messaging;

namespace Association.Application.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<AssociationListItem>>;



