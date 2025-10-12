using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Operations;

[Route("api/v1/operations")]
public sealed class OperationController : ControllerBase
{
  [HttpGet("{id}", Name = "GetOperation")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResource<,>))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OperationResource<ErrorResource>))]
  [ProducesResponseType(typeof(ErrorResource), StatusCodes.Status400BadRequest)]
  public IActionResult Get([FromRoute] string id) => Ok(new OperationResource
  {
    Id = id,
    Done = true,
  });
}
