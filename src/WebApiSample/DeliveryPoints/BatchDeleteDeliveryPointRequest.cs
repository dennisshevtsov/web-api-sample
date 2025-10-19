namespace WebApiSample.DeliveryPoints;

public sealed class BatchDeleteDeliveryPointRequest
{
  public required IReadOnlyList<string> Ids { get; set; }
}

