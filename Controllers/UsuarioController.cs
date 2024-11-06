using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UsuarioApi.Data;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;
using UsuarioApi.Services;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private IMapper _mapper;
        private Contexto _contexto;
        private UserManager<Usuario> _UserManager;
        private CadastrarUsuarioServices _cadastroService;

        public UsuarioController(IMapper mapper, Contexto contexto, UserManager<Usuario> userManager, CadastrarUsuarioServices cadastrarUsuarioServices)
        {
            _mapper = mapper;
            _contexto = contexto;
            _UserManager = userManager;
            this._cadastroService = cadastrarUsuarioServices;
        }



        [HttpPost("/Usuario/Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CreateUsuarioDto usuarioDto)
        {
            await _cadastroService.CadastrarUsuarioAsync(usuarioDto);
            return Ok("Usuário cadastrado!");

        }

    }
}
