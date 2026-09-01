using Association.Domain;
using Hivify.UseCases.Abstractions.Messaging;

namespace Association.Application.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;