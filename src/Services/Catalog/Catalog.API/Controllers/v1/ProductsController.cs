using System.Net;
using Asp.Versioning;
using Catalog.Application.Products;
using Catalog.Application.Products.Create;
using Catalog.Application.Products.DeleteById;
using Catalog.Application.Products.GetAll;
using Catalog.Application.Products.GetById;
using Catalog.Application.Products.GetByName;
using Catalog.Application.Products.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.v1;

[ApiVersion("1")]
public class ProductsController (ISender mediatr) : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
    {
        var result = await mediatr.Send(new GetAllProductsQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetById(string id)
    {
        var result = await mediatr.Send(new GetByIdProductQuery(id));
        return Ok(result);
    }
    
    [HttpGet("byName/{name}")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetByName(string name)
    {
        var result = await mediatr.Send(new GetByNameProductQuery(name));
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<ProductResponse>> Post(CreateProductCommand command)
    {
        var result = await mediatr.Send(command);
        return Created(result.Id, result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Update(UpdateProductCommand command, string id)
    {
        command.Id = id;
        await mediatr.Send(command);
        return new NoContentResult();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> Delete(DeleteProductByIdCommand command, string id)
    {
        command.Id = id;
        await mediatr.Send(command);
        return new NoContentResult();
    }
    
    
}