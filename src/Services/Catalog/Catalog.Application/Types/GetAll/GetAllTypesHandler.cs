using Catalog.Core.Contracts.Repositories;
using MediatR;

namespace Catalog.Application.Types.GetAll;

public class GetAllTypesHandler (ITypeRepository typeRepository) : IRequestHandler<GetAllTypesQuery, IEnumerable<TypeResponse>>
{
    public async Task<IEnumerable<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
    {
        var typeList = await typeRepository.GetAllTypesAsync();
        var response = typeList.Select(t => t.ToTypeResponse());
        return response;
    }
}