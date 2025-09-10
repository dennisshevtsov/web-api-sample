using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Web.Warehouses;

[Route("v1/warehouses")]
public sealed class WarehousesController : ControllerBase
{
  [HttpGet("{id}")]
  public IActionResult Get(string id) => Ok();

  [HttpGet]
  public IActionResult List() => Ok();

  [HttpPost]
  public IActionResult Create(CreateWarehouseRequest request) => Ok();

  [HttpPatch("{id}")]
  public IActionResult Update(string id, UpdateWarehouseRequest request) => Ok();

  [HttpPut("{id}")]
  public IActionResult Replace(string id, ReplaceWarehouseRequest request) => Ok();

  [HttpDelete("{id}")]
  public IActionResult Delete(string id) => Ok();
}

