using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class InputConfig
{
  [Required]
  public string? ContentType { get; set; }

  [Required]
  public string? CompressionFormat { get; set; }
}
