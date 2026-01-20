namespace explore_pattern.Domain.Dtos.Requests
{
    public record CreateProductRequest(
        Guid CategoryId,
        string Name,
        decimal Price);

    public record UpdateProductRequest(
        string Name,
        decimal Price);
}
