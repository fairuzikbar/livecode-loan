using LoanApp.Entities.Loan;
using LoanApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController:ControllerBase
{
    private readonly IRepository<LoanTransaction> _transactionRepository;
    private readonly IPersistence _persistence;

    public TransactionController(IRepository<LoanTransaction> transactionRepository, IPersistence persistence)
    {
        _transactionRepository = transactionRepository;
        _persistence = persistence;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewLoanTransaction([FromBody] LoanTransaction payload)
    {
        var transactionRepository = await _transactionRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/transactions", transactionRepository);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanTransactionId(string id)
    {
        var transactionRepository = await _transactionRepository
            .FindAsync(transactionRepository => transactionRepository.id.Equals(int.Parse(id)));
        return Ok(transactionRepository);
    }
    
    [HttpPut("{adminId}/approve")]
    public async Task<IActionResult> ApproveLoanTransaction(string adminId, [FromBody] LoanTransaction payload)
    {
        var transactionRepository = _transactionRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(transactionRepository);
    }
}