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
