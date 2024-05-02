namespace Application.Data;

using Domain.Customers;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}