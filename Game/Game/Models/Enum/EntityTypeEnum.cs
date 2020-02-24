using System;
namespace Game.Models.Enum
{
    /// <summary>
    /// Used to track the type of the entity in a battle.
    /// </summary>
    public enum EntityTypeEnum
    {
        // Not Known
        Unknown = 0,

        // Entity is a Character
        Character = 1,

        // Entity is a Monster
        Monster = 2,
    }
}