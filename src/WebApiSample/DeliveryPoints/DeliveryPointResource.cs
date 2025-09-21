using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DeliveryPoints;

public sealed class DeliveryPointResource
{
  [Required]
  [MaxLength(16)]
  public string? Id { get; set; }

  [MaxLength(32)]
  public string? Name { get; set; }

  [Required]
  [MaxLength(128)]
  public string? Address { get; set; }

  [Required]
  public CoordinatesResource? Coordinates { get; set; }

  [Required]
  public WorkingDaysResource? WorkingHours { get; set; }
}
