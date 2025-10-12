using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Warehouses;

[Route("api/v1/warehouses")]
public sealed class WarehousesController : ControllerBase
{
  [HttpGet("{id}", Name = "GetWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new WarehouseResource { Id = id });

  [HttpGet(Name = "ListWarehouses")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<WarehouseResource>))]
  public IActionResult List(
    [FromQuery] string filter,
    [FromQuery] string nextPageToken,
    [FromQuery] int maxPageSize,
    [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new ListResponse<WarehouseResource>
  {
    Results = [new WarehouseResource { Id = "test" }],
  });

  [HttpPost(Name = "CreateWarehouse")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WarehouseResource))]
  public IActionResult Create([FromBody] WarehouseResource resource) => CreatedAtAction
  (
    actionName : nameof(Get),
    routeValues: new { id = "test" },
    value      : resource
  );

  [HttpPatch("{id}", Name = "UpdateWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] WarehouseResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(resource);

  [HttpPut("{id}", Name = "ReplaceWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] WarehouseResource resource) => Ok(resource);

  [HttpDelete("{id}", Name = "DeleteWarehouse")]
  [ProducesResponseType(typeof(WarehouseResource), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
  public IActionResult Delete([FromRoute] string id) => NoContent();

  [HttpDelete("{id}:undelete", Name = "UndeleteWarehouse")]
  [ProducesResponseType(typeof(WarehouseResource), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
  public IActionResult Undelete([FromRoute] string id) => NoContent();
}

