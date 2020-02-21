namespace Game.Models
{
    /// <summary>
    /// Available Character types.
    /// Used by Character CRUDi to help create characters of a certain type.
    /// </summary>
    public enum CharacterTypeEnum
    {
        // Not specified
        Unknown = 0,

        // All the character types available in game
        TambourinePlayer = 1,
        Bassist = 2,
        Keyboardist = 3,
        Drummer = 4,
        Guitarist = 5,
        LeadVocalist = 6
    }
}