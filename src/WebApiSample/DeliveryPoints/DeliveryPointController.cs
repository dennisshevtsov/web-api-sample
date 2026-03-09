using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApiSample.DeliveryPoints;

[ApiController]
[Route("api/v1/delivery-points")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public sealed class DeliveryPointController : ControllerBase
{
  /// <summary>
  /// Gets a delivery point by its ID.
  /// </summary>
  /// <param name="id">The ID of the delivery point.</param>
  /// <param name="fieldMask">The list of fields that should be included to the response. Example: name,locations.*</param>
  [HttpGet("{id}", Name = "GetDeliveryPoint")]
  [ProducesResponseType(typeof(DeliveryPointResource), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new DeliveryPointResource { Id = id });

  /// <summary>
  /// Gets a list of delivery points that satisfy to conditions in the filter.
  /// </summary>
  /// <param name="filter">Use this parameter to filter the result. Available operators: eq, ne, gt, ge, lt, le, and, or, not, contains. Excample: GET api/v1/warehouses?filter=not(contains(name, 'abc'))</param>
  /// <param name="nextPageToken">The next page token.</param>
  /// <param name="maxPageSize">The max size of the page. If page contains less than this value, it does not mean the there is no more records. Only nextPageToken indicates if there are records still.</param>
  /// <param name="fieldMask">The list of fields that should be included to the response. Example: name,locations.*</param>
  [HttpGet(Name = "ListDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult List([FromQuery] string filter, [FromQuery] string nextPageToken, [FromQuery] int maxPageSize, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new ListResponse<DeliveryPointResource>
  {
    Results = [new DeliveryPointResource { Id = "test" }],
  });

  /// <summary>
  /// Create a delivery point.
  /// </summary>
  /// <param name="resource">A delivery point to create.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  /// <param name="validateOnly">If this field is true, no chages will be applied, the method will only validate the request.</param>
  [HttpPost(Name = "CreateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Create([FromBody] DeliveryPointResource resource, [FromQuery] string? resourceId, [FromQuery] bool validateOnly) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Update a delivery point. Only fields that are listed in <paramref name="fieldMask"/> will be updated.
  /// </summary>
  /// <param name="id">The ID of a delivery point.</param>
  /// <param name="resource">A delivery point to update.</param>
  /// <param name="fieldMask">A list of fields to update.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  /// <param name="validateOnly">If this field is true, no chages will be applied, the method will only validate the request.</param>
  [HttpPatch("{id}", Name = "UpdateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Update([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] IReadOnlyList<string> fieldMask, [FromQuery] string? resourceId, [FromQuery] bool validateOnly) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Replace a delivery point by its ID. If there is no delivery points with this ID, a new delivery point will be created.
  /// </summary>
  /// <param name="id">The ID of a delivery point.</param>
  /// <param name="resource">A delivery point to replace.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  /// <param name="validateOnly">If this field is true, no chages will be applied, the method will only validate the request.</param>
  [HttpPut("{id}", Name = "ReplaceDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Replace([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] string? resourceId, [FromQuery] bool validateOnly) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Soft delete a delivery point.
  /// </summary>
  /// <param name="id">The ID of a delivery point.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpDelete("{id}", Name = "DeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Delete([FromRoute] string id, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Undelete a delivery point.
  /// </summary>
  /// <param name="id">The ID of a delivery point.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:undelete", Name = "UndeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Undelete([FromRoute] string id, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Soft delete a list of delivery points. All delivery points have to be related to the same warehouse.
  /// </summary>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:batchDelete", Name = "BatchDeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult BatchDelete([FromBody] BatchDeleteDeliveryPointRequest request, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Undelete a list of delivery points. All delivery points have to be related to the same warehouse.
  /// </summary>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:batchUndelete", Name = "BatchUndeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult BatchUndelete([FromBody] BatchUndeleteDeliveryPointRequest request, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Hand delete a delivery point.
  /// </summary>
  /// <param name="id">The ID of a delivery point.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost("{id}:expunge", Name = "ExpungeDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Expunge([FromRoute] string id, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );

  /// <summary>
  /// Import a list of delivery points from a file.
  /// </summary>
  /// <param name="request">Parameters of a file to import delivery points.</param>
  /// <param name="resourceId">The optional ID of a request to deduplicate requests. Use a random generated value.</param>
  [HttpPost(":import", Name = "ImportDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<NoResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMetadata))]
  public IActionResult Import([FromBody] ImportRequest request, [FromQuery] string? resourceId) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new { id = "test" },
    value: new OperationResource<DeliveryPointResource> { Id = "test" }
  );
}

