using System.Net;
using Asp.Versioning;
using Catalog.Application.Types;
using Catalog.Application.Types.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.v1;

[ApiVersion("1")]
public class TypeController(ISender mediatr) : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> Get()
    {
        var result = await mediatr.Send(new GetAllTypesQuery());
        return Ok(result);
    }
}