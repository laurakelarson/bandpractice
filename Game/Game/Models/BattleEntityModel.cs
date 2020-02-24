using System;
using Game.Models.Enum;

namespace Game.Models
{
    /// <summary>
    /// Represents an entity (Character or Monster) participating in a battle.
    /// </summary>
    public class BattleEntityModel : EntityModel<BattleEntityModel>
    {
        // Track what type of entity (character or monster)
        public EntityTypeEnum EntityType = EntityTypeEnum.Unknown;

        // Track the total experience this entity has earned or gives
        public int ExperiencePoints = 0;

        // Number representing the entity's place in the battle list
        public int ListOrder = 0;

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
            EntityType = EntityTypeEnum.Character;
            Id = data.Id;
            Alive = data.Alive;
            ExperiencePoints = data.TotalExperience;
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
            EntityType = EntityTypeEnum.Monster;
            Id = data.Id;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceGiven;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
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
