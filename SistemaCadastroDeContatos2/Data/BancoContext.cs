using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeContatos2.Models;

namespace SistemaCadastroDeContatos2.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
