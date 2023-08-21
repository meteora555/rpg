using rpg.Models;

namespace Rpg.Dtos.Character;

public class UpdateCharacterDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Health { get; set; }

    public int Strength { get; set; }

    public int Defence { get; set; }

    public int Intelligen { get; set; }

    public RpgClasses Class { get; set; } = RpgClasses.Knight;
}