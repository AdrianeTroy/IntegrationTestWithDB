using MediatR;
using S3E1.DTO;
using S3E1.Entities;

namespace S3E1.Commands
{
    public record UpdateCartitemCommand(CartItemEntity CartItems) : IRequest<CartItemEntity>;
}
