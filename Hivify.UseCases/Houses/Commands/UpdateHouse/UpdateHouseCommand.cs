using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Houses.Commands.UpdateHouse;

public sealed record UpdateHouseCommand(
    Guid HouseId,
    string Address,
    string HouseNumber,
    string PostalCode) : ICommand<bool>;