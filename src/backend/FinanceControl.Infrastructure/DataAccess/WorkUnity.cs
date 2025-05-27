using FinanceControl.Domain.Repositories;

namespace FinanceControl.Infrastructure.DataAccess;

public class WorkUnity : IWorkUnity
{
    private readonly FinanceControlDbContext _dbContext;
    public WorkUnity(FinanceControlDbContext dbContext) => _dbContext = dbContext;
    
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}