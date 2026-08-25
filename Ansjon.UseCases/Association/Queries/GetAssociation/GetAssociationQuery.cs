using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Association.DTOs;

namespace Ansjon.UseCases.Association.Queries.GetAssociation;

public sealed record GetAssociationQuery(Guid AssociationId) : IQuery<AssociationListDto>;