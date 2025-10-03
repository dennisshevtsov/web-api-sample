using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public abstract class DataSource(string type)
{
  public const string S3Type = "s3";
  public const string SambaType = "samba";

  [Required]
  public string Type { get; } = type;
}
