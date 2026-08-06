using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.UseCases.Abstractions.Messaging;


namespace Ansjon.UseCases.Houses.Commands
{
    public sealed record AddHouseCommand(
        AssociationID AssociationId,
        string Address,
        string HouseNumber,
        string PostalCode) : ICommand<HouseID>
    {
    }
}
