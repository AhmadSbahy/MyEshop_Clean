using MediatR;
using MyEshop_Clean.Application.Contracts.Persistence;
using MyEshop_Clean.Application.Exceptions;
using MyEshop_Clean.Application.Features.Product.Request.Commands;

namespace MyEshop_Clean.Application.Features.Product.Handlers.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException("محصولی پیدا نشد",typeof(Domain.Product));
        }

        await _productRepository.DeleteAsync(product);
    }
}