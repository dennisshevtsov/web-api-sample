namespace WebApiSample.DeliveryPoints;

public sealed class BatchUndeleteDeliveryPointRequest
{
  public required IReadOnlyList<string> Ids { get; set; }
}

