using Rpg.Dtos.Character;
using rpg.Models;

namespace Rpg.Service.CharacterService;

public interface ICharacterService
{
    Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();

    Task<ServiceResponse<GetCharacterDto>> GetById(int id);

    Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    
    Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

    Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
}