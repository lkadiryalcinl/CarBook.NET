using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetContactByIdQueryResult
            {
                Email = value.Email,
                ID = value.ID,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject
            };
        }
    }
}
