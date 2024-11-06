using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioApi.Data.Dtos;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class UsuarioServices
    {
        private IMapper _mapper;
        private UserManager<Usuario> _UserManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioServices(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _UserManager = userManager;
            _signInManager = signInManager;
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

        public async Task  Login(LoginUsuarioDto dto )
        {
          var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha na autenticação");
            }
        }
    }
}
