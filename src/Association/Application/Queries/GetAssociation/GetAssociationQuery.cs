using Association.Application.DTOs;
using Hivify.UseCases.Abstractions.Messaging;

namespace Association.Application.Queries.GetAssociation;

public sealed record GetAssociationQuery(Guid AssociationId) : IQuery<AssociationListDto>;