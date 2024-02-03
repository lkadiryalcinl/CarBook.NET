using CarBook.Application.Features.Mediator.Commands.CategoryCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
