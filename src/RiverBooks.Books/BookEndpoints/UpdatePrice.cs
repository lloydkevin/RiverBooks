﻿using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class UpdatePrice(IBookService bookService) :
    Endpoint<UpdateBookPriceRequest, BookDto>
{
  private readonly IBookService _bookService = bookService;

  public override void Configure()
  {
    Post("/books/{Id}/pricehistory"); // we're not actually tracking price history but we could in the future
    AllowAnonymous();
  }

  public override async Task HandleAsync(UpdateBookPriceRequest request,
             CancellationToken cancellationToken = default)
  {
    await _bookService.UpdateBookPriceAsync(request.Id, request.NewPrice);

    var updatedBook = await _bookService.GetBookByIdAsync(request.Id);

    await SendAsync(updatedBook);
  }
}
