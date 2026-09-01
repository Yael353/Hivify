using Association.Application.DTOs;
using SharedKernel.Messaging;

namespace Hivify.Association.Application.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<AssociationListDto>>;



