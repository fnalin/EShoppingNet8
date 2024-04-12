using MediatR;

namespace Catalog.Application.Types.GetAll;

public class GetAllTypesQuery : IRequest<IEnumerable<TypeResponse>>
{
    
}