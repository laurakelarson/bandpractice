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
        //// Range of the Monster, swords are 1, hats/rings are 0, bows are >1
        //public int Range { get; set; } = 0;

        //// The Damage the Monster can do if it is used as a weapon in the primary hand
        //public int Damage { get; set; } = 0;

        //// Enum of the different attributes that the Monster modifies, Monsters can only modify one Monster
        //public AttributeEnum Attribute { get; set; } = AttributeEnum.Unknown;

        //// Where the Monster goes on the character.  Head, Foot etc.
        //public MonsterLocationEnum Location { get; set; } = MonsterLocationEnum.Unknown;

        //// The Value Monster modifies.  So a ring of Health +3, has a Value of 3
        //public int Value { get; set; } = 0;

        //// Add Unique attributes for Monster

        ///// <summary>
        ///// Default MonsterModel
        ///// Establish the Default Image Path
        ///// </summary>
        //public MonsterModel() {
        //    ImageURI = MonsterService.DefaultImageURI;
        //}

        ///// <summary>
        ///// Constructor to create an Monster based on what is passed in
        ///// </summary>
        ///// <param name="data"></param>
        //public MonsterModel(MonsterModel data)
        //{
        //    Update(data);
        //}

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