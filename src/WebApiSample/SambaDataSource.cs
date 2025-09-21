using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class SambaDataSource : DataSource
{
  [Required]
  public override string? Type => "samba";

  [Required]
  public string? Uri { get; set; }
}
