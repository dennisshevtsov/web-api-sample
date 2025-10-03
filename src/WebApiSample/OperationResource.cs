using System.Text.Json.Serialization;

namespace WebApiSample;

public class OperationResource
{
  [JsonPropertyName("id")]
  public required string Id { get; init; }

  [JsonPropertyName("done")]
  public bool Done { get; init; }
}

public class OperationResource<TResult> : OperationResource
{
  [JsonPropertyName("result")]
  public TResult? Result { get; init; }
}

public class OperationResource<TResult, TMetadata> : OperationResource<TResult>
{
  [JsonPropertyName("metadata")]
  public TMetadata? Metadata { get; init; }
}
