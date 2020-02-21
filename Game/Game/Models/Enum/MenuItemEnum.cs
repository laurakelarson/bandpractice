namespace Game.Models
{
    /// <summary>
    /// List of items to show in the Menu
    /// </summary>
    public enum MenuItemEnum
    {
        // Not specified
        Unknown = 0,

        // MyBand page is the entry point to a battle
        MyBand = 1,

        // Home page
        Home = 2,

        // Encyclopedia page, landing point for CRUDi pages
        Encyclopedia = 3,

        // Score CRUDi
        Score = 4,

        // Items CRUDi
        Items = 5,

        // About page, includes debug settings
        About = 6
    }
}