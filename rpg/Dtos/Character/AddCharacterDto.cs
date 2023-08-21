using rpg.Models;

namespace Rpg.Dtos.Character;

public class AddCharacterDto
{


    public string Name { get; set; }

    public int Health { get; set; }

    public int Strength { get; set; }

    public int Defence { get; set; }

    public int Intelligen { get; set; }

    public RpgClasses Class { get; set; }
}
