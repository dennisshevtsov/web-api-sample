using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Warehouses;

public sealed class WarehouseResource
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
}
