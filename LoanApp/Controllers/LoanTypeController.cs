using LoanApp.Entities.Loan;
using LoanApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

[ApiController]
[Route("api/loan-types")]
public class LoanTypeController:ControllerBase
{
    private readonly IRepository<LoanType> _loanTypeRepository;
    private readonly IPersistence _persistence;

    public LoanTypeController(IRepository<LoanType> loanTypeRepository, IPersistence persistence)
    {
        _loanTypeRepository = loanTypeRepository;
        _persistence = persistence;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewLoanType([FromBody] LoanType payload)
    {
        var installmentType = await _loanTypeRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/loan-types", installmentType);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateLoanType([FromBody] LoanType payload)
    {
        var installmentType = _loanTypeRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(installmentType);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoanType(string id)
    {
        try
        {
            var installmentType = await _loanTypeRepository.FindByIdAsync(int.Parse(id));
            if (installmentType is null) return NotFound("LoanType not found");
            _loanTypeRepository.Delete(installmentType);
            await _persistence.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanTypeId(string id)
    {
        var installmentType = await _loanTypeRepository
            .FindAsync(installmentType => installmentType.Id.Equals(int.Parse(id)));
        return Ok(installmentType);
    }
}