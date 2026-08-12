using Ansjon.UseCases.Abstractions.Messaging;


namespace Ansjon.UseCases.Houses.Commands.CreateHouse
{
    public sealed record AddHouseCommand(
        string Address,
        string HouseNumber,
        string PostalCode) : ICommand<Guid>
    {
    }
}
