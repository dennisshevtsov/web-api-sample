using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample.DeliveryPoints;

public sealed class WorkingDayResource
{
  [Required]
  [Range(0D, 23.59D)]
  [JsonPropertyName("from")]
  public TimeSpan? From { get; set; }

  [Required]
  [Range(0D, 23.59D)]
  [JsonPropertyName("to")]
  public TimeSpan? To { get; set; }
}

