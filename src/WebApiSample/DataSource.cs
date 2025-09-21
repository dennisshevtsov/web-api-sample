using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public abstract class DataSource
{
  [Required]
  public virtual string? Type { get; }
}
