﻿using Ardalis.Result;
using MediatR;
using RiverBooks.OrderProcessing.Interfaces;

namespace RiverBooks.Users.UseCases;

internal record ListOrdersForUserQuery(string EmailAddress) : IRequest<Result<List<OrderSummary>>>;

internal class ListOrdersForUserQueryHandler : IRequestHandler<ListOrdersForUserQuery, Result<List<OrderSummary>>>
{
  private readonly IOrderRepository _orderRepository;

  public ListOrdersForUserQueryHandler(IOrderRepository orderRepository)
  {
    _orderRepository = orderRepository;
  }

  public async Task<Result<List<OrderSummary>>> Handle(ListOrdersForUserQuery request, CancellationToken cancellationToken)
  {
    // look up UserId for EmailAddress

    // add specification to get orders by userid
    //object spec = null!;
    var orders = await _orderRepository.ListAsync();

    // map orders to OrderSummary records and return
    return null!;
  }
}
