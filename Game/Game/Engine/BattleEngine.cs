using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    /// <summary>
    /// Battle Engine for the game.
    /// Container for battle rounds (inheritance from RoundEngine) and
    /// battle turns (RoundEngine inherits from TurnEngine)
    /// </summary>
    class BattleEngine : RoundEngine
    {
        // Track whether battle is running
        public bool BattleRunning = false;
    }
}
