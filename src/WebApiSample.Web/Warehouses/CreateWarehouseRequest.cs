namespace WebApiSample.Web.Warehouses;

public sealed class CreateWarehouseRequest
{
  public required string Id { get; set; }

  public string? Name { get; set; }
}
