using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class S3DataSource() : DataSource(DataSource.S3)
{
  [Required]
  [JsonPropertyName("bucketId")]
  public string? BucketId { get; set; }

  [Required]
  [JsonPropertyName("mask")]
  public IReadOnlyList<string>? Mask { get; set; }
}
