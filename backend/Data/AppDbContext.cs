/* 
* ApplicationDbContext
*
* This Represents the database context for the application, providing access to
* the various database tables through DbSet properties.
*
*/
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Patent> Patents { get; set; }
    }
}

/*
* Entity Framework Core
*
* Entity Framework Core is an Object-Relational Mapping (ORM) framework
* that enables .NET developers to work with relational data using domain-specific
* objects, eliminating the need for most of the data-access code.
*
*/