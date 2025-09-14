namespace WebApiSample.Web.Warehouses;

public sealed class ListWarehousesResponse
{
  public required IReadOnlyList<WarehouseResource> Results { get; set; }
}
