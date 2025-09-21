using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class ImportRequest
{
  [Required]
  public required InputConfig? InputConfig { get; set; }

  [Required]
  public required DataSource? DataSource { get; set; }
}
