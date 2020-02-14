namespace Game.Models
{
    /// <summary>
    /// Home Menu Item Model
    /// </summary>
    public class HomeMenuItemModel
    {
        // Id of menu item 
        public MenuItemEnum Id { get; set; }

        // Display string for menu item 
        public string Title { get; set; }
    }
}