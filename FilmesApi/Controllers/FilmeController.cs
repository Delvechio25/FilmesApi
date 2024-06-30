using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadFilmeDto> RecuperasFilmes([FromQuery]int skip = 0, [FromQuery] int take = 50) 
    { 
        return _mapper.Map<List<ReadFilmeDto>>(_context.Fillmes.Skip(skip).Take(take));
    }
    [HttpGet("{Id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        
        var filme = _context.Fillmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filme);
    }
    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Fillmes.FirstOrDefault(filme => filme.Id == id );
        if (filme == null) return NotFound();
        _mapper.Map(filme, filmeDto);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial(int id,JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Fillmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar,ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Fillmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Fillmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
