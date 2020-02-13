using System.Collections.Generic;
using Game.Services;

namespace Game.Models
{
    /// <summary>
    /// Monster for the Game
    /// 
    /// The Monsters that the characters battle in the game.
    /// The Monsters are stored in the DB, and during game time a random Monster is selected.
    /// The system supports CRUDi operations on the Monsters
    /// When in test mode, a test set of Monsters is loaded.
    /// When in run mode the Monsters are loaded from the database.
    /// 
    /// </summary>
    public class MonsterModel : BaseModel<MonsterModel>
    {
        //  Status indicating whether the monster is currently alive or not
        public bool Alive { get; set; } = true;

        // Integer indicating the monster’s level
        public int Level { get; set; } = 1;

        // Amount of experience the monster will give on defeat
        public int ExperienceGiven { get; set; } = 0;

        // The speed of the monster. Higher speeds give the monster higher precedence in turn order during a round
        public int Speed { get; set; } = 0;

        // The monster’s defense level. Higher defense makes it more difficult for characters to successfully attack
        public int Defense { get; set; } = 0;

        // The monster’s attack attribute. A Higher attack attribute makes a successful attack more likely
        public int Attack { get; set; } = 0;

        // The current health level of the monster
        public int CurrentHealth { get; set; } = 0;

        // The max health level of the monster
        public int MaxHealth { get; set; } = 0;

        // The range of the monster to attack. Attacks within range will be successful
        public int Range { get; set; } = 0;

        // The items that may be dropped by this monster on defeat. May drop none, some, or all of the items in the array
        public List<ItemModel> ItemsDropped { get; set; } = new List<ItemModel>();

        // The items that will always be dropped by this monster on defeat
        public List<ItemModel> UniqueDrops { get; set; } = new List<ItemModel>();

        /// <summary>
        /// Default MonsterModel
        /// Establish the Default Image Path
        /// </summary>
        public MonsterModel()
        {
            //ImageURI = MonsterService.DefaultImageURI;
        }

        /// <summary>
        /// Constructor to create an Monster based on what is passed in
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        ///// <summary>
        ///// Update the Record
        ///// </summary>
        ///// <param name="newData">The new data</param>
        //public override void Update(MonsterModel newData)
        //{
        //    if (newData == null)
        //    {
        //        return;
        //    }

        //    // Update all the fields in the Data, except for the Id and guid
        //    Name = newData.Name;
        //    Description = newData.Description;
        //    Value = newData.Value;
        //    Attribute = newData.Attribute;
        //    Location = newData.Location;
        //    Name = newData.Name;
        //    Description = newData.Description;
        //    ImageURI = newData.ImageURI;
        //    Range = newData.Range;
        //    Damage = newData.Damage;
        //}

        //// Helper to combine the attributes into a single line, to make it easier to display the Monster as a string
        //public string FormatOutput()
        //{
        //    var myReturn = Name + " , " +
        //                    Description + " for " +
        //                    Location.ToString() + " with " +
        //                    Attribute.ToString() +
        //                    "+" + Value + " , " +
        //                    "Damage : " + Damage + " , " +
        //                    "Range : " + Range;

        //    return myReturn.Trim();
        //}
    }
}