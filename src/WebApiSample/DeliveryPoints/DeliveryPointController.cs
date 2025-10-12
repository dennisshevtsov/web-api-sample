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
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  public IActionResult Create([FromBody] DeliveryPointResource resource) => Ok(new OperationResource<DeliveryPointResource>
  {
    Id = "test",
  });

  [HttpPatch("{id}", Name = "UpdateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  public IActionResult Update([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new OperationResource<DeliveryPointResource>
  {
    Id = "test",
  });

  [HttpPut("{id}", Name = "ReplaceDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  public IActionResult Replace([FromRoute] string id, [FromBody] DeliveryPointResource resource) => Ok(new OperationResource<DeliveryPointResource>
  {
    Id = "test",
  });

  [HttpDelete("{id}", Name = "DeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  public IActionResult Delete([FromRoute] string id) => Ok(new OperationResource
  {
    Id = "test",
  });

  [HttpPost("{id}:undelete", Name = "UndeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  public IActionResult Undelete([FromRoute] string id) => Ok(new OperationResource
  {
    Id = "test",
  });

  [HttpPost(":import", Name = "ImportDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource))]
  public IActionResult Import([FromBody] ImportRequest request) => Ok(new OperationResource
  {
    Id = "test",
    Done = false,
  });
}

