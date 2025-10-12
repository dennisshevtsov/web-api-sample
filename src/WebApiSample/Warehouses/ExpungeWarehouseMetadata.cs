namespace WebApiSample.Warehouses;

public sealed class ExpungeWarehouseMetadata
{
  public required IReadOnlyList<string> DeliveryPoints { get; init; }
}
