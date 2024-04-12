using System.Net;
using Asp.Versioning;
using Catalog.Application.Brands;
using Catalog.Application.Brands.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.v1;

[ApiVersion("1")]
public class BrandController (ISender mediatr) : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BrandResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> Get()
    {
        var result = await mediatr.Send(new GetAllBrandsQuery());
        return Ok(result);
    }
}