using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Warehouses;

[Route("api/v1/warehouses")]
public sealed class WarehousesController : ControllerBase
{
  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new WarehouseResource { Id = id });

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<WarehouseResource>))]
  public IActionResult List([FromQuery] string filter, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new ListResponse<WarehouseResource>
  {
    Results = [new WarehouseResource { Id = "test" }],
  });

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WarehouseResource))]
  public IActionResult Create([FromBody] WarehouseResource resource) => CreatedAtAction
  (
    actionName : nameof(Get),
    routeValues: new { id = "test" },
    value      : resource
  );

  [HttpPatch("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] WarehouseResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(resource);

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] WarehouseResource resource) => Ok(resource);

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Delete([FromRoute] string id) => NoContent();
}

