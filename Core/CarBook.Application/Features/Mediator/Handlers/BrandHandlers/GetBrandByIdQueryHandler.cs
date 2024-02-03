using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery,GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBrandByIdQueryResult
            {
                ID = values.ID,
                Name = values.Name,
            };
        }
    }
}
