using Microsoft.AspNetCore.Mvc;
using MoviesApi.Shared;

namespace MoviesApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DirectorsController : ControllerBase
{
    private ApplicationContext _appContext;

    public DirectorsController(ApplicationContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public IActionResult GetDirectors()
    {
        return Ok(_appContext.Directors);
    }

    [HttpGet("{id}")]
    public IActionResult GetDirector(int id)
    {
        var director = _appContext.Directors.FirstOrDefault(d => d.Id == id);

        if (director == null)
        {
            return NotFound("Not found");
        }

        return Ok(director);
    }

    [HttpPost]
    public IActionResult PostDirector([FromBody] Director director)
    {
        _appContext.Directors.Add(director);
        _appContext.SaveChanges();
        return Created("Created", new { id = director.Id });
    }

    [HttpPut]

    public IActionResult UpdateDirector(int id, [FromBody] Director updateDirector)
    {
        if (updateDirector == null || id != updateDirector.Id)
        {
            return BadRequest();
        }

        var existingDirector = _appContext.Directors.FirstOrDefault(movie => movie.Id == id);

        if (existingDirector == null)
        {
            return BadRequest("Not Found");
        }

        existingDirector.FirstName = updateDirector.FirstName;
        existingDirector.MiddleName = updateDirector.MiddleName;
        existingDirector.LastName = updateDirector.LastName;
        existingDirector.BirthDate = updateDirector.BirthDate;
        existingDirector.Filmography = updateDirector.Filmography;
        existingDirector.Biography = updateDirector.Biography;
        _appContext.SaveChanges();
        return Ok(existingDirector);
        
    }
}
