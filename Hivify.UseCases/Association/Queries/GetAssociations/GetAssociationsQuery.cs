using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Association.DTOs;

namespace Hivify.UseCases.Association.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<AssociationListDto>>;