using LibraryAPI.Application.Books.Commands.CreateBook;
using LibraryAPI.Application.Books.Commands.DeleteBook;
using LibraryAPI.Application.Books.Commands.UpdateBook;
using LibraryAPI.Application.Books.Queries.GetAllBooks;
using LibraryAPI.Application.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers;
// Hanterar alla CRUD-operationer för böcker via MediatR
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Hämta alla böcker</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    /// <summary>Hämta en bok via ID</summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));
        return book is null ? NotFound() : Ok(book);
    }

    /// <summary>Skapa en ny bok</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
    {
        var book = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    /// <summary>Uppdatera en bok</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBookCommand command)
    {
        if (id != command.Id) return BadRequest("ID i URL och body matchar inte.");
        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    /// <summary>Ta bort en bok</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBookCommand(id));
        return result ? NoContent() : NotFound();
    }
}
