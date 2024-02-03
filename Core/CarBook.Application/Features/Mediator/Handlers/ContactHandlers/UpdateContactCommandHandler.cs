using CarBook.Application.Features.Mediator.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.Email = request.Email;
            value.SendDate = request.SendDate;
            value.Subject = request.Subject;
            value.Message = request.Message;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
