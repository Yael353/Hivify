using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands.UpdateHouse;

public sealed record UpdateHouseCommand(
    Guid HouseId,
    string Address,
    string HouseNumber,
    string PostalCode) : ICommand<bool>;