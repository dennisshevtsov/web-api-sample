using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Warehouses;

[Route("api/v1/warehouses")]
public sealed class WarehousesController : ControllerBase
{
  [HttpGet("{id}", Name = "GetWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new WarehouseResource { Id = id });

  [HttpGet(Name = "ListWarehouses")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<WarehouseResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
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
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Create([FromBody] WarehouseResource resource) => CreatedAtAction
  (
    actionName : nameof(Get),
    routeValues: new { id = "test" },
    value      : resource
  );

  [HttpPatch("{id}", Name = "UpdateWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] WarehouseResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(resource);

  [HttpPut("{id}", Name = "ReplaceWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] WarehouseResource resource) => Ok(resource);

  [HttpDelete("{id}", Name = "DeleteWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Delete([FromRoute] string id) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<WarehouseResource>
    {
      Id = "test",
    }
  );

  [HttpPost("{id}:undelete", Name = "UndeleteWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Undelete([FromRoute] string id) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<WarehouseResource>
    {
      Id = "test",
    }
  );

  /// <summary>
  /// Hard delete a warehouse and all delivery points that are related to this warehouse.
  /// </summary>
  /// <param name="id">The ID of a warehouse to delete.</param>
  /// <param name="force">The flag that indicates whether it should hard delete a warehouse and its delivery points.</param>
  [HttpPost("{id}:expunge", Name = "ExpungeWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource, ExpungeWarehouseMetadata>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Expunge([FromRoute] string id, bool force) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<WarehouseResource, ExpungeWarehouseMetadata>
    {
      Id = "test",
    }
  );
}

