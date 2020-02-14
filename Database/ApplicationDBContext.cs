using Microsoft.EntityFrameworkCore;
using CrudRafa.Models;

namespace CrudRafa.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios{get; set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){}  
    }
}