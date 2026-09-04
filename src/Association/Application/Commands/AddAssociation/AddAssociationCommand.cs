using Association.Domain.Associations;
using BuildingBlocks.ApplicationPorts.Messeging;

namespace Association.Application.Commands.AddAssociation;

public sealed record AddAssociationCommand(string Name) : ICommand<AssociationID>;




