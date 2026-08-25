using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Association.DTOs;

namespace Ansjon.UseCases.Association.Queries.GetAssociations;

public sealed record GetAssociationsQuery : IQuery<IReadOnlyList<AssociationListDto>>;