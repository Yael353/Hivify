namespace Houses.Application.DTOs
{
    public sealed record HouseListItemDto(
       Guid Id,
       string Address,
       string HouseNumber,
       string PostalCode,
       DateTime CreatedAt
        );
}
