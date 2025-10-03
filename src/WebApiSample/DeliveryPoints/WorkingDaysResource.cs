using System.Text.Json.Serialization;

namespace WebApiSample.DeliveryPoints;

public sealed class WorkingDaysResource
{
  [JsonPropertyName("mon")]
  public WorkingDayResource? Mon { get; set; }

  [JsonPropertyName("tue")]
  public WorkingDayResource? Tue { get; set; }

  [JsonPropertyName("wed")]
  public WorkingDayResource? Wed { get; set; }

  [JsonPropertyName("thu")]
  public WorkingDayResource? Thu { get; set; }

  [JsonPropertyName("fri")]
  public WorkingDayResource? Fri { get; set; }

  [JsonPropertyName("sat")]
  public WorkingDayResource? Sat { get; set; }

  [JsonPropertyName("sun")]
  public WorkingDayResource? Sun { get; set; }
}

