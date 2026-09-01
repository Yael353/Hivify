using Hivify.UseCases.Abstractions.Messaging;


namespace Hivify.UseCases.Houses.Commands.CreateHouse
{
    public sealed record AddHouseCommand(
        string Address,
        string HouseNumber,
        string PostalCode) : ICommand<Guid>
    {
    }
}
