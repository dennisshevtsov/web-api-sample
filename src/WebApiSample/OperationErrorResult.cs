namespace WebApiSample;

public sealed class OperationErrorResult
{
  public required string Code { get; init; }

  public required string Message { get; init; }

  public object? Details { get; init; }
}
