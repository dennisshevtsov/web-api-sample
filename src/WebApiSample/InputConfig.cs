using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class InputConfig
{
  [Required]
  [JsonPropertyName("contentType")]
  public string? ContentType { get; set; }

  [Required]
  [JsonPropertyName("compressionFormat")]
  public string? CompressionFormat { get; set; }
}
