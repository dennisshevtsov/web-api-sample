using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class SambaDataSource() : DataSource(DataSource.SambaType)
{
  [Required]
  public string? Uri { get; set; }
}
