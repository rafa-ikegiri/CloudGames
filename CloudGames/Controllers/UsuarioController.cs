using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CloudGamesAPI.Controllers;

[ApiController]
[Route("/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_usuarioRepository.ObterTodos());
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
            return Ok(_usuarioRepository.ObterPorID(id));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioInput input)
    {
        try
        {
            var usuario = new Usuario()
            {
                Nome = input.Nome,
                Email = input.Email,
                Senha = input.Senha,
                IsAdmin = input.IsAdmin
            };
            _usuarioRepository.Cadastrar(usuario);
            return Ok();

        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] UsuarioUpdateInput input)
    {
        try
        {
            var usuario = _usuarioRepository.ObterPorID(input.Id);
            usuario.Nome = input.Nome;
            usuario.Email = input.Email;
            usuario.Senha = input.Senha;
            usuario.IsAdmin = input.IsAdmin;
            _usuarioRepository.Alterar(usuario);
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
            _usuarioRepository.Deletar(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}