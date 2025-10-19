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

  /// <summary>
  /// Create a new warehause.
  /// </summary>
  /// <param name="resource">The warehouse.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost(Name = "CreateWarehouse")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Create([FromBody] WarehouseResource resource, [FromQuery] string? resourceId) => CreatedAtAction
  (
    actionName : nameof(Get),
    routeValues: new { id = "test" },
    value      : resource
  );

  /// <summary>
  /// Update a warehouse by its ID. Only fields that are listed in <paramref name="fieldMask"/> will be upadated.
  /// </summary>
  /// <param name="id">The ID of a warehouse to undelete.</param>
  /// <param name="resource">The warehouse.</param>
  /// <param name="fieldMask">A list of fields to update.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPatch("{id}", Name = "UpdateWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] WarehouseResource resource, [FromQuery] IReadOnlyList<string> fieldMask, [FromQuery] string? resourceId) => Ok(resource);

  /// <summary>
  /// Replace a warehouse by its ID. If there is no warehouse with this ID, a new warehouse will be created.
  /// </summary>
  /// <param name="id">The ID of a warehouse to undelete.</param>
  /// <param name="resource">The warehouse.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPut("{id}", Name = "ReplaceWarehouse")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WarehouseResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] WarehouseResource resource, [FromQuery] string? resourceId) => Ok(resource);

  /// <summary>
  /// Soft delete a warehouse.
  /// </summary>
  /// <param name="id">The ID of a warehouse to undelete.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpDelete("{id}", Name = "DeleteWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Delete([FromRoute] string id, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<WarehouseResource> { Id = "test" }
  );

  /// <summary>
  /// Undelete a warehouse. The method does not undelete the delivery points that relates to this warehouse, use UndeleteDeliveryPoint or BatchUndeleteDeliveryPoint methods to restore the delivery points.
  /// </summary>
  /// <param name="id">The ID of a warehouse to undelete.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:undelete", Name = "UndeleteWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Undelete([FromRoute] string id, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<WarehouseResource> { Id = "test" }
  );

  /// <summary>
  /// Hard delete a warehouse and all delivery points that are related to this warehouse.
  /// </summary>
  /// <param name="id">The ID of a warehouse to delete.</param>
  /// <param name="force">The flag that indicates whether it should hard delete a warehouse and its delivery points.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:expunge", Name = "ExpungeWarehouse")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<WarehouseResource, ExpungeWarehouseMetadata>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Expunge([FromRoute] string id, [FromQuery] bool force, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<WarehouseResource, ExpungeWarehouseMetadata> { Id = "test" }
  );
}

