using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuarioApi.Models;

namespace UsuarioApi.Data
{
    public class Contexto : IdentityDbContext<Usuario>
    {
        public Contexto(DbContextOptions <Contexto> opts):
            base(opts)
        {

        }
    }
}
