using BSB.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.DataAccess;

public class BSBDbContext : DbContext
{
    public BSBDbContext(DbContextOptions options)
            : base(options)
    { }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Salesperson> Salespeople { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Sales> Sales { get; set; }
}
