using Microsoft.EntityFrameworkCore;
using System;

namespace AareonTechnicalTest.Models.Interfaces
{
    public interface IPersonContext : IDisposable
    {
        DbSet<Person> Persons { get; }
        int SaveChanges();
    }
}
