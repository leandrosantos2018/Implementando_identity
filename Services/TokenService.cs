
using System.Security.Claims;
using UsuarioApi.Models;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace UsuarioApi.Services
{
    public class TokenService
    {
        public  string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[] {

            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ffPlikxi4SJ3qcC7H5kOE2Lv19epYZnA91ZfaCTDO_w=\r\n"));

            var signingCredentials = 
                new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(30),
                claims:claims,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}