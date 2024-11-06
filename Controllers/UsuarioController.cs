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
        private UsuarioServices _usuarioService;

        public UsuarioController(IMapper mapper, Contexto contexto, UserManager<Usuario> userManager, UsuarioServices UsuarioServices)
        {
            _mapper = mapper;
            _contexto = contexto;
            _UserManager = userManager;
            this._usuarioService = UsuarioServices;
        }



        [HttpPost("/Usuario/Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.CadastrarUsuarioAsync(usuarioDto);
            return Ok("Usuário cadastrado!");

        }


        [HttpPost("/Usuario/Login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
        {
            await _usuarioService.Login(dto);
            return Ok("Usuario Autenticado");
        }

    }
}
