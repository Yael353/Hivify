using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Association.DTOs;

namespace Hivify.UseCases.Association.Queries.GetAssociation;

public sealed record GetAssociationQuery(Guid AssociationId) : IQuery<AssociationListDto>;