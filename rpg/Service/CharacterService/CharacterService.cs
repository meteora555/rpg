using Microsoft.EntityFrameworkCore;
using rpg.Models;

namespace Rpg.Service.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly DefaultDbContext _context;

    public static List<Character> characters = new List<Character>
        { new Character(), new Character { Id = 1, Name = "Frodo" } };


    public CharacterService(IMapper mapper, DefaultDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbCharacters = await _context.Characters.AddAsync(_mapper.Map<Character>(newCharacter));
        // characters.Add(_mapper.Map<Character>(newCharacter));
        // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        await _context.SaveChangesAsync();

        var allCharacters = await _context.Characters.ToListAsync();
        serviceResponse.Data = allCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

        if (character != null) character.Name = updatedCharacter.Name;
        if (character != null) character.Health = updatedCharacter.Health;

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

        try
        {
            var dbCharacter = await _context.Characters.FirstAsync(c => c.Id == id);
            if (dbCharacter is null)
                throw new Exception($"Character with {id} not found");

            characters.Remove(dbCharacter);

            var allCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = allCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbCharacters = await _context.Characters.ToListAsync();
        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
    {
        var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        var serviceResponse = new ServiceResponse<GetCharacterDto>
        {
            Data = _mapper.Map<GetCharacterDto>(dbCharacter)
        };


        return serviceResponse;
    }
}