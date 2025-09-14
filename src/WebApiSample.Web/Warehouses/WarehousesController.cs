using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Web.Warehouses;

[Route("v1/warehouses")]
public sealed class WarehousesController : ControllerBase
{
  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Get([FromRoute] string id) => Ok(new WarehouseResource { Id = id });

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListWarehousesResponse))]
  public IActionResult List() => Ok(new ListWarehousesResponse
  {
    Results = [new WarehouseResource { Id = "test" }],
  });

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WarehouseResource))]
  public IActionResult Create([FromBody] CreateWarehouseRequest request) => CreatedAtAction
  (
    actionName : nameof(Get),
    routeValues: new { id = "test" },
    value      : new WarehouseResource { Id = request.Id }
  );

  [HttpPatch("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] UpdateWarehouseRequest request) => Ok(new WarehouseResource { Id = request.Id });

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] ReplaceWarehouseRequest request) => Ok(new WarehouseResource { Id = request.Id });

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Delete([FromRoute] string id) => NoContent();
}

