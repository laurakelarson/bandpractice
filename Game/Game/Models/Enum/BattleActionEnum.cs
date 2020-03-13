using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models.Enum
{
    /// <summary>
    /// Actions that can happen in the battle.
    /// 
    /// Example.  
    /// PlayerAlwaysHit can be Default, On, or Off
    /// PlayerAbility can be Default, On, Off
    /// </summary>
    public enum BattleActionEnum
    {
        // Default behavior
        Default = 0,

        // Supress Behavior
        Off = 2,

        // Force behavior
        On = 3,
    }
}
