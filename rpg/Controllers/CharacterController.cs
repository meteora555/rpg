using Microsoft.AspNetCore.Mvc;
using rpg.Models;


namespace rpg.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CharacterController : Controller
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAll()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async  Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetById(int id)
    {
        return Ok(await _characterService.GetById(id));
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }
    
    [HttpPut]
    [Route("Update")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var response = await _characterService.UpdateCharacter(updatedCharacter);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async  Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var response = await _characterService.DeleteCharacter(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}