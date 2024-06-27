using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public CreatedAtActionResult AdicionarFilme([FromBody]CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Fillmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperasFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50) 
    { 
        return _context.Fillmes.Skip(skip).Take(take);
    }
    [HttpGet("{Id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Fillmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
