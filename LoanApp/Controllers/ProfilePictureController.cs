using LoanApp.Entities.Loan;
using LoanApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

[ApiController]
[Route("customers/{customerId}/avatar")]
public class ProfilePictureController:ControllerBase
{
    private readonly IRepository<ProfilePicture> _profilePictureRepository;
    private readonly IPersistence _persistence;
    
    public ProfilePictureController(IRepository<ProfilePicture> profilePictureRepository, IPersistence persistence)
    {
        _profilePictureRepository = profilePictureRepository;
        _persistence = persistence;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewProfilePicture([FromRoute] int customerId, [FromBody] ProfilePicture payload)
    {
        var profilePicture = await _profilePictureRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created($"/customers/{customerId}/avatar", profilePicture);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProfilePicture([FromRoute] int customerId, [FromBody] ProfilePicture payload)
    {
        var profilePicture = _profilePictureRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return Ok(profilePicture);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfilePicture([FromRoute] int customerId, string id)
    {
        try
        {
            var profilePicture = await _profilePictureRepository.FindByIdAsync(int.Parse(id));
            if (profilePicture is null) return NotFound("Profile picture not found");
            _profilePictureRepository.Delete(profilePicture);
            await _persistence.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfilePicture(string id)
    {
        var profilePicture = await _profilePictureRepository
            .FindAsync(profilePicture => profilePicture.Id.Equals(int.Parse(id)));
        return Ok(profilePicture);
    }
}