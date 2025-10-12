using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.DeliveryPoints;

[Route("api/v1/delivery-points")]
public sealed class DeliveryPointController : ControllerBase
{
  [HttpGet("{id}", Name = "GetDeliveryPoint")]
  [ProducesResponseType(typeof(DeliveryPointResource), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Get([FromRoute] string id, [FromQuery] IReadOnlyList<string> fieldMask) => Ok(new DeliveryPointResource { Id = id });

  [HttpGet(Name = "ListDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
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
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Create([FromBody] DeliveryPointResource resource) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpPatch("{id}", Name = "UpdateDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Update([FromRoute] string id, [FromBody] DeliveryPointResource resource, [FromQuery] IReadOnlyList<string> fieldMask) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpPut("{id}", Name = "ReplaceDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Replace([FromRoute] string id, [FromBody] DeliveryPointResource resource) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpDelete("{id}", Name = "DeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Delete([FromRoute] string id) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpPost("{id}:undelete", Name = "UndeleteDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Undelete([FromRoute] string id) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpPost("{id}:expunge", Name = "ExpungeDeliveryPoint")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource<DeliveryPointResource>))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Expunge([FromRoute] string id) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );

  [HttpPost(":import", Name = "ImportDeliveryPoints")]
  [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(OperationResource))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResource))]
  public IActionResult Import([FromBody] ImportRequest request) => CreatedAtRoute
  (
    routeName: "GetOperation",
    routeValues: new
    {
      id = "test",
    },
    value: new OperationResource<DeliveryPointResource>
    {
      Id = "test",
    }
  );
}

