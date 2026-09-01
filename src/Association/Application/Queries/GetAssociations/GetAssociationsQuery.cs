using Association.Application.DTOs;
using Hivify.UseCases.Abstractions.Messaging;

namespace Association.Application.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<AssociationListDto>>;