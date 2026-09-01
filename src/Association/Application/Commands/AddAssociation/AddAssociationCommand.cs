using Hivify.Association.Domain.Associations;
using SharedKernel.Messaging;

namespace Association.Application.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;




