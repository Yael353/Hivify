using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.AssociationUseCases.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;