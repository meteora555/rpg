using System.Text.Json.Serialization;

namespace rpg.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClasses
{
    Knight = 0,
    Wizard = 1,
    Priest = 2,
    Druid = 3
}