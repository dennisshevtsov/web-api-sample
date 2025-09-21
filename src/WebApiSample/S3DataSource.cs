using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class S3DataSource : DataSource
{
  [Required]
  public override string? Type => "s3";

  [Required]
  public string? BucketId { get; set; }

  [Required]
  public IReadOnlyList<string>? Mask { get; set; }
}
