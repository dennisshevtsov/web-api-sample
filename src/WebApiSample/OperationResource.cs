namespace WebApiSample;

public class OperationResource
{
  public required string Id { get; init; }

  public bool Done { get; init; }
}

public class OperationResource<TResult> : OperationResource
{
  public TResult? Result { get; init; }
}

public class OperationResource<TResult, TMetadata> : OperationResource<TResult>
{
  public TMetadata? Metadata { get; init; }
}
