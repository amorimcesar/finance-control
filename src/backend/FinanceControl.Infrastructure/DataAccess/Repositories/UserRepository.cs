using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly FinanceControlDbContext _dbContext;
    public UserRepository(FinanceControlDbContext dbContext) => _dbContext = dbContext;
    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
}