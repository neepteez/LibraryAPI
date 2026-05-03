using LibraryAPI.Application.Authors.Commands.CreateAuthor;
using LibraryAPI.Application.Authors.Queries.GetAllAuthors;
using LibraryAPI.Application.Authors.Queries.GetAuthorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Hämta alla författare</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _mediator.Send(new GetAllAuthorsQuery());
        return Ok(authors);
    }

    /// <summary>Hämta en författare via ID</summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery(id));
        return author is null ? NotFound() : Ok(author);
    }

    /// <summary>Skapa en ny författare</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
    {
        var author = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }
}
