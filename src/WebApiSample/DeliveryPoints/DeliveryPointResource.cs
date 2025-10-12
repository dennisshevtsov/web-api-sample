using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiSample.DeliveryPoints;

public sealed class DeliveryPointResource
{
  [Required]
  [MaxLength(16)]
  [JsonPropertyName("id")]
  public string? Id { get; set; }

  [Required]
  [MaxLength(16)]
  [JsonPropertyName("warehouseId")]
  public string? WarehouseId { get; set; }

  [MaxLength(32)]
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  [Required]
  [MaxLength(128)]
  [JsonPropertyName("address")]
  public string? Address { get; set; }

  [Required]
  [JsonPropertyName("location")]
  public LocationResource? Location { get; set; }

  [Required]
  [JsonPropertyName("workingHours")]
  public WorkingDaysResource? WorkingHours { get; set; }

  /// <summary>
  /// This field cannot be set or updated directly through CreateDeliveryPoint (POST delivery-point) and UpdaetDeliveryPoint (PUT delivery-point/{id}) methods. Use the DeleteDeliveryPoint (DELETE delivery-point/{id}) or UndeleteDeliveryPoint (POST delivery-point/{id}:undelete) methods.
  /// </summary>
  [JsonPropertyName("deleted")]
  public bool? Deleted { get; set; }
}
