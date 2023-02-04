using LoanApp.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanApp.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<GuaranteePicture> GuaranteePictures { get; set; }
    public DbSet<InstallmentType> InstallmentTypes { get; set; }
    public DbSet<LoanDocuments> LoanDocuments { get; set; }
    public DbSet<LoanTransaction> LoanTransactions { get; set; }
    public DbSet<LoanType> LoanTypes { get; set; }
    public DbSet<ProfilePicture> ProfilePictures { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }

    protected AppDbContext()
    {
    }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}