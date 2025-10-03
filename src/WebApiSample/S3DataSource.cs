using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class S3DataSource() : DataSource(DataSource.S3Type)
{
  [Required]
  public string? BucketId { get; set; }

  [Required]
  public IReadOnlyList<string>? Mask { get; set; }
}
