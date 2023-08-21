using rpg.Models;

namespace Rpg;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<UpdateCharacterDto, Character>();
    }
}