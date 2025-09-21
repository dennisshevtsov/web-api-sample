namespace WebApiSample;

public sealed class ListResponse<TResource> where TResource : class
{
  public required IReadOnlyList<TResource> Results { get; set; }
}
