using Microsoft.EntityFrameworkCore;
using TesteCamposDealer.Models;

namespace TesteCamposDealer.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions Banco) : base(Banco)
        {

        }
        public DataContext(DbContextOptions<DataContext> Banco) : base(Banco)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }


    }
}
