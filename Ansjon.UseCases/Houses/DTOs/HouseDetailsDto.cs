namespace Ansjon.UseCases.Houses.DTOs;

public sealed record HouseDetailsDto(
    Guid Id,
    string Address,
    string HouseNumber,
    string PostalCode,
    DateTime CreatedAt,
    IReadOnlyCollection<HouseDto> Tenants
);