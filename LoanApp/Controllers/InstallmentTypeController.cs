using LoanApp.Entities.Loan;
using LoanApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

[ApiController]
[Route("api/installment-type")]
public class InstallmentTypeController:ControllerBase
{
    private readonly IRepository<InstallmentType> _installmentTypeRepository;
    private readonly IPersistence _persistence;

    public InstallmentTypeController(IRepository<InstallmentType> installmentTypeRepository, IPersistence persistence)
    {
        _installmentTypeRepository = installmentTypeRepository;
        _persistence = persistence;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewInstallmentType([FromBody] InstallmentType payload)
    {
        var installmentType = await _installmentTypeRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/installment-type", installmentType);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateInstallmentType([FromBody] InstallmentType payload)
    {
        var installmentType = _installmentTypeRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(installmentType);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInstallmentType(string id)
    {
        try
        {
            var installmentType = await _installmentTypeRepository.FindByIdAsync(int.Parse(id));
            if (installmentType is null) return NotFound("InstallmentType not found");
            _installmentTypeRepository.Delete(installmentType);
            await _persistence.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInstallmentTypeId(string id)
    {
        var installmentType = await _installmentTypeRepository
            .FindAsync(installmentType => installmentType.Id.Equals(int.Parse(id)));
        return Ok(installmentType);
    }
}