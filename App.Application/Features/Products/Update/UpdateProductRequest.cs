namespace App.Application.Features.Products.Update;

public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock, int CategoryId);