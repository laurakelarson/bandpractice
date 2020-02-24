using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

namespace Game.Engine
{
    /// <summary>
    /// Turn Engine for the game.
    /// Manages an entity (character or monster) taking a turn.
    /// </summary>
    public class TurnEngine : BaseEngine
    {


        /// <summary>
        /// The current attacker takes their turn.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool TakeTurn(BattleEntityModel attacker)
        {
            //TODO implement
            return true;
        }

        /// <summary>
        /// Attack as a turn.
        ///
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool Attack(BattleEntityModel attacker)
        {
            //// For Attack, Choose Who
            //var target = AttackChoice(attacker);

            //if (target == null)
            //{
            //    return false;
            //}

            //// Do Attack
            //TurnAsAttack(attacker, target);

            CurrentAttacker = new BattleEntityModel(attacker);
            //CurrentDefender = new BattleEntityModel(target);

            return true;
        }

    }
}
