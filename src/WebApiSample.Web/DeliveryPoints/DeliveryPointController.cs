using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Web.DeliveryPoints;

[Route("api/v1/delivery-points")]
public sealed class DeliveryPointController : ControllerBase
{
  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new DeliveryPointResource { Id = id });

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<DeliveryPointResource>))]
  public IActionResult List([FromQuery] IReadOnlyList<string> fieldMask) => Ok(new ListResponse<DeliveryPointResource>
  {
    Results = [new DeliveryPointResource { Id = "test" }],
  });

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DeliveryPointResource))]
  public IActionResult Create([FromBody] DeliveryPointResource resource) => CreatedAtAction
  (
    actionName: nameof(Get),
    routeValues: new { id = "test" },
    value: resource
  );

  [HttpPatch("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(resource);

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryPointResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] DeliveryPointResource resource) => Ok(resource);

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Delete([FromRoute] string id) => NoContent();
}

