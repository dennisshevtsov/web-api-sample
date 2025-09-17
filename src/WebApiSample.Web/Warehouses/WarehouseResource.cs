using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Web.Warehouses;

public sealed class WarehouseResource
{
  [Required]
  public string? Id { get; set; }

  [MaxLength(32)]
  public string? Name { get; set; }

  [Required]
  [MaxLength(128)]
  public string? Address { get; set; }

  [Required]
  public CoordinatesResource? Coordinates { get; set; }
}
