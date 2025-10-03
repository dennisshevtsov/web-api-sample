using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

public sealed class LocationResource
{
  [Required]
  [JsonPropertyName("latitude")]
  public float? Latitude { get; set; }

  [Required]
  [JsonPropertyName("longitude")]
  public float? Longitude { get; set; }
}
