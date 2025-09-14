using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Web.Warehouses;

public sealed class WarehouseResource
{
  [Required]
  public required string Id { get; set; }

  public string? Name { get; set; }
}
