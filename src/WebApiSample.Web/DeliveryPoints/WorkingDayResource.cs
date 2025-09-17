using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Web.DeliveryPoints;

public sealed class WorkingDayResource
{
  [Required]
  [Range(0D, 23.59D)]
  public TimeSpan? From { get; set; }

  [Required]
  [Range(0D, 23.59D)]
  public TimeSpan? To { get; set; }
}

