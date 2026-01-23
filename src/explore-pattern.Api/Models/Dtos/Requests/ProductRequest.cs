namespace explore_pattern.Api.Models.Dtos.Requests
{
    #region docs
    // why use record?
    // 1. Immutability: Records are immutable by default, meaning their properties cannot be changed after creation. This is beneficial for request DTOs as it ensures that the data remains consistent throughout its lifecycle.
    // 2. Value-based equality: Records use value-based equality, which means that two record instances are considered equal if their properties have the same values. This is useful for request DTOs when comparing instances or checking for duplicates.
    // 3. Concise syntax: Records provide a more concise syntax for defining data structures compared to traditional classes. This reduces boilerplate code and makes the code easier to read and maintain.
    // 4. Built-in functionality: Records come with built-in functionality such as deconstruction, cloning, and with-expressions, which can simplify operations on request DTOs.
    #endregion

    public record CreateProductRequest(
        Guid CategoryId,
        string Name,
        decimal Price);

    public record UpdateProductRequest(
        string Name,
        decimal Price);
}
