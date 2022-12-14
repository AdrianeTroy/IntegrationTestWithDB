using MediatR;
using S3E1.DTO;
using S3E1.Entities;

namespace S3E1.Queries
{
    public record GetOrdersByIdQuery(Guid id) :IRequest<OrderEntity>;
}
