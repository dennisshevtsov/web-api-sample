using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class ImportRequest
{
  [Required]
  [JsonPropertyName("inputConfig")]
  public required InputConfig? InputConfig { get; set; }

  [Required]
  [JsonPropertyName("dataSource")]
  public required DataSource? DataSource { get; set; }
}
