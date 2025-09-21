﻿using System.ComponentModel.DataAnnotations;

namespace WebApiSample;

public sealed class CoordinatesResource
{
  [Required]
  public float? Latitude { get; set; }

  [Required]
  public float? Longitude { get; set; }
}
