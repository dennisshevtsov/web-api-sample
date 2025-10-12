using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class ErrorResource
{
  [JsonPropertyName("code")]
  public required string Code { get; init; }

  [JsonPropertyName("message")]
  public required string Message { get; init; }

  [JsonPropertyName("details")]
  public object? Details { get; init; }
}
