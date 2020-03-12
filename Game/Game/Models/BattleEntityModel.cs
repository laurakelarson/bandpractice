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

        // Hackathon scenario 30 - volunteer to be first
        // If FirstBuff set to true, character gets buffed attributes
        public bool FirstBuff { get; set; } = false;

        public void BuffCharacterStats()
        {
            Attack *= 2;
            Speed *= 2;
            Defense *= 2;
        }
        public void UnbuffCharacterStats()
        {
            Attack /= 2;
            Speed /= 2;
            Defense /= 2;
        }

        
        /// <summary>
        /// Constructor.
        /// </summary>
        public BattleEntityModel() {}

        /// <summary>
        /// Copy constructor creates a new BattleEntityModel based on the input
        /// </summary>
        /// <param name="data"></param>
        public BattleEntityModel(BattleEntityModel data)
        {
            EntityType = data.EntityType;
            Id = data.Id;
            Alive = data.Alive;
            ExperiencePoints = data.ExperiencePoints;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.Speed;
            ImageURI = data.ImageURI;
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;
            Attack = data.Attack;
            Defense = data.Defense;
            FirstBuff = data.FirstBuff;
            Range = data.Range;
        }

        /// <summary>
        /// Constructs a BattleEntityModel based on the character input
        /// </summary>
        /// <param name="data"></param>
        public BattleEntityModel(CharacterModel data)
        {
            EntityType = EntityTypeEnum.Character;
            Id = data.Id;
            Alive = data.Alive;
            ExperiencePoints = data.TotalExperience;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;
            Attack = data.GetAttack();
            Defense = data.GetDefense();
            Range = data.GetRange();
        }

        /// <summary>
        /// Constructs a BattleEntityModel based on the monster input
        /// </summary>
        /// <param name="data"></param>
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
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;
            Attack = data.Attack;
            Defense = data.Defense;
            Range = data.Range;
        }

        /// <summary>
        /// Update the BattleEntityModel with new character stats.
        /// For example, if a character levels up or gets new items that increase speed.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(CharacterModel data)
        {
            // should not update a monster entity with a character
            if (EntityType != EntityTypeEnum.Character)
            {
                return false;
            }

            // reflect updates in character stats
            Alive = data.Alive;
            ExperiencePoints = data.TotalExperience;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            CurrentHealth = data.CurrentHealth;
            MaxHealth = data.MaxHealth;
            Attack = data.GetAttack();
            Defense = data.GetDefense();
            Range = data.GetRange();
            return true;
        }

        /// <summary>
        /// Returns the name of the battle entity.
        /// </summary>
        /// <returns></returns>
        public new string FormatOutput()
        {
            return this.Name;
        }
    }
}
