using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Exceptions;
using MyEshop_Clean.Application.Features.Category.Request.Commands;

namespace MyEshop_Clean.Application.Features.Category.Handlers.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException("جزییات دسته بندی پیدا نشد", typeof(Domain.Order));
        }

        await _categoryRepository.DeleteAsync(category);
    }
}