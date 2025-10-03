using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample.Warehouses;

public sealed class WarehouseResource
{
  [Required]
  [MaxLength(16)]
  [JsonPropertyName("id")]
  public string? Id { get; set; }

  [MaxLength(32)]
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  [Required]
  [MaxLength(128)]
  [JsonPropertyName("address")]
  public string? Address { get; set; }

  [Required]
  [JsonPropertyName("location")]
  public LocationResource? Location { get; set; }
}
