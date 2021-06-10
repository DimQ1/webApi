using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCQRS.Models;

namespace WebAppCQRS.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}