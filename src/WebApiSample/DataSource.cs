using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample;

[JsonDerivedType(typeof(S3DataSource), typeDiscriminator: DataSource.S3)]
[JsonDerivedType(typeof(SambaDataSource), typeDiscriminator: DataSource.Samba)]
[JsonPolymorphic(TypeDiscriminatorPropertyName = DataSource.TypeDesriminator)]
public abstract class DataSource(string type)
{
  public const string TypeDesriminator = "type";

  public const string S3 = "s3";
  public const string Samba = "samba";

  [Required]
  public string Type { get; } = type;
}
