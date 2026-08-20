using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<Core.Aggregates.Associations.Association>>;