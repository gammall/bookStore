using BookStore1.Repositories;

namespace BookStore1.Services;

internal class OrderService(OrderRepository orderRepository)
{
    private readonly OrderRepository _orderRepository = orderRepository;


}
