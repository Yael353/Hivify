namespace Ansjon.UseCases.Houses.DTOs
{
    public sealed record HouseDto(
       Guid Id,
       string Address,
       string HouseNumber,
       string PostalCode,
       DateTime CreatedAt
        );
}
