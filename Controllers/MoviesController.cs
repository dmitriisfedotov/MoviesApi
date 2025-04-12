using Microsoft.AspNetCore.Mvc;
using MoviesApi.Shared;

namespace MoviesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MoviesController : ControllerBase
{
    private ApplicationContext _appContext;

    public MoviesController(ApplicationContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(_appContext.Movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        var movie = _appContext.Movies.FirstOrDefault(m => m.Id == id);

        if (movie == null)
        {
            return NotFound("Not found");
        }

        return Ok(movie);
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] Movie movie)
    {
        _appContext.Movies.Add(movie);
        _appContext.SaveChanges();
        return Created("Created", new { id = movie.Id });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovies(int id, [FromBody] Movie updatedMovie)
    {
        if (updatedMovie == null || updatedMovie.Id != id)
        {
            return BadRequest();
        }

        var existingMovie = _appContext.Movies.FirstOrDefault(movie => movie.Id == id);

        if (existingMovie == null)
        {
            return NotFound("Not found");
        }

        existingMovie.Name = updatedMovie.Name;
        existingMovie.Duration = updatedMovie.Duration;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        // TODO DateTime вместо релиза, миграция изучить
        _appContext.SaveChanges();

        return Ok(existingMovie);
    }
}
