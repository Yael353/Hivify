using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Queries.GetAssociation;

public sealed record GetAssociationQuery(
    AssociationID AssociationId
) : IQuery<Core.Aggregates.Associations.Association?>;