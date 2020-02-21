using System;
namespace Game.Models
{
    /// <summary>
    /// Represents an entity (Character or Monster) participating in a battle.
    /// </summary>
    public class BattleEntityModel : EntityModel<BattleEntityModel>
    {
        public BattleEntityModel()
        {
        }

        public override string FormatOutput()
        {
            throw new NotImplementedException();
        }
    }
}
