using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;