using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;
    
    [HttpPost]
    public CreatedAtActionResult AdicionarFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperasFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50) 
    { 
        return filmes.Skip(skip).Take(take);
    }
    [HttpGet("{Id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme =  filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
