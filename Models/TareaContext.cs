using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TareaContext : DbContext
    {
        public TareaContext(DbContextOptions<TareaContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea> Tarea { get; set; } = null!;
    }
}