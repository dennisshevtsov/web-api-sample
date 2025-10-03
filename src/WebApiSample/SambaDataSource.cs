using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class SambaDataSource() : DataSource(DataSource.Samba)
{
  [Required]
  [JsonPropertyName("uri")]
  public string? Uri { get; set; }
}
