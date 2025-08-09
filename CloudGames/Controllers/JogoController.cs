using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CloudGamesAPI.Controllers;

[ApiController]
[Route("/[controller]")]
public class JogoController : ControllerBase
{
    private readonly IJogoRepository _jogoRepository;

    public JogoController(IJogoRepository jogoRepository)
    {
        _jogoRepository = jogoRepository;
    }


    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_jogoRepository.ObterTodos());
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult Get([FromRoute] int id)
    {
        try
        {
            return Ok(_jogoRepository.ObterPorID(id));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] JogoInput input)
    {
        try
        {
            var jogo = new Jogo()
            {
                Titulo = input.Titulo,
                Genero = input.Genero,
                Plataforma = input.Plataforma,
                DtLancamento = input.DtLancamento,
                Multiplayer = input.Multiplayer
            };
            _jogoRepository.Cadastrar(jogo);
            return Ok();

        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] JogoUpdateInput input)
    {
        try
        {
            var jogo = _jogoRepository.ObterPorID(input.Id);
            jogo.Titulo = input.Titulo;
            jogo.Genero = input.Genero;
            jogo.Plataforma = input.Plataforma;
            jogo.DtLancamento = input.DtLancamento;
            jogo.Multiplayer = input.Multiplayer;
            _jogoRepository.Alterar(jogo);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _jogoRepository.Deletar(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}