using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class CadastrarUsuarioServices
    {
        private IMapper _mapper;
        private UserManager<Usuario> _UserManager;
        

        public CadastrarUsuarioServices(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _UserManager = userManager;
        }


        public async Task CadastrarUsuarioAsync(CreateUsuarioDto usuarioDto)
        {

            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityResult resultado = await _UserManager.CreateAsync(usuario, usuarioDto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }
    }
}
