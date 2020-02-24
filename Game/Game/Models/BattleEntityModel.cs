using System;
namespace Game.Models
{
    /// <summary>
    /// Represents an entity (Character or Monster) participating in a battle.
    /// </summary>
    public class BattleEntityModel : EntityModel<BattleEntityModel>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BattleEntityModel() {}

        /// <summary>
        /// Constructs a BattleEntityModel based on the character input
        /// </summary>
        /// <param name="character"></param>
        public BattleEntityModel(CharacterModel data)
        {
            //PlayerType = data.PlayerType;
            Id = data.Id;
            Alive = data.Alive;
            //ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            //Speed = data.GetSpeed();
            Speed = data.Speed;
            ImageURI = data.ImageURI;
            //CurrentHealth = data.GetCurrentHealthTotal;
            //MaxHealth = data.GetMaxHealthTotal;
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;

        }

        /// <summary>
        /// Constructs a BattleEntityModel based on the monster input
        /// </summary>
        /// <param name="monster"></param>
        public BattleEntityModel(MonsterModel data)
        {
            //PlayerType = data.PlayerType;
            Id = data.Id;
            Alive = data.Alive;
            //ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            //Speed = data.GetSpeed();
            Speed = data.Speed;
            ImageURI = data.ImageURI;
            //CurrentHealth = data.GetCurrentHealthTotal;
            //MaxHealth = data.GetMaxHealthTotal;
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;
        }

        /// <summary>
        /// ChangeLevel not currently implemented in this class
        /// </summary>
        /// <param name="levelValue"></param>
        /// <returns></returns>
        public override bool ChangeLevel(int levelValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of the battle entity.
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            return this.Name;
        }
    }
}
