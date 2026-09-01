using Hivify.Core.Aggregates.Associations;
using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Association.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;