using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.DeliveryPoints;

[Route("api/v1/delivery-points")]
public sealed class DeliveryPointController : ControllerBase
{
  [HttpGet("{id}", Name = "GetDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new DeliveryPointResource { Id = id });

  [HttpGet(Name = "ListDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<DeliveryPointResource>))]
  public IActionResult List(
    [FromQuery] string filter,
    [FromQuery] string nextPageToken,
    [FromQuery] int maxPageSize,
    [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new ListResponse<DeliveryPointResource>
  {
    Results = [new DeliveryPointResource { Id = "test" }],
  });

  [HttpPost(Name = "CreateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeliveryPointResource))]
  public IActionResult Create([FromBody] DeliveryPointResource resource) => CreatedAtAction
  (
    actionName: nameof(Get),
    routeValues: new { id = "test" },
    value: resource
  );

  [HttpPatch("{id}", Name = "UpdateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(resource);

  [HttpPut("{id}", Name = "ReplaceDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] DeliveryPointResource resource) => Ok(resource);

  [HttpDelete("{id}", Name = "DeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Delete([FromRoute] string id) => NoContent();

  [HttpPost(":import", Name = "ImportDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Import([FromBody] ImportRequest request) => NoContent();
}

