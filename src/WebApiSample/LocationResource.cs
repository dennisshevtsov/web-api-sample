using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class LocationResource
{
  [Required]
  public float? Latitude { get; set; }

  [Required]
  public float? Longitude { get; set; }
}
