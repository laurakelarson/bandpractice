﻿using Game.Helpers;
using Game.Models;
using Game.Models.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine
{
    /// <summary>
    /// AutoBattle Engine
    /// Runs the engine simulation with no user interaction
    /// </summary>
    public class AutoBattleEngine : BattleEngine
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        // The Battle Engine
        // BattleEngine Engine = new BattleEngine();

        /// <summary>
        /// Return the Score Object
        /// </summary>
        /// <returns></returns>
        public ScoreModel GetScoreObject() { return Score; }

        /// <summary>
        /// Run Auto Battle
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RunAutoBattle()
        {
            RoundEnum RoundCondition;

            Debug.WriteLine("Auto Battle Starting");

            // Auto Battle, does all the steps that a human would do.

            // Prepare for Battle

            // Picks 6 Characters
            // TODO - implement better character picking method when we get Beats figured out
            CharacterModel data = DataHelper.DefaultTambourine();
            for (int i = CharacterList.Count(); i < MaxNumberCharacters; i++)
            {
                data.Name = "Tambourine Player " + i.ToString();
                AddBandMember(data);
            }

            // Start Battle in AutoBattle mode
            StartBattle(true);

            // Fight Loop. Continue until Game is Over...
            do
            {
                Debug.WriteLine("Next Turn");

                // Do the turn...
                // If the round is over start a new one...
                RoundCondition = RoundNextTurn();

                if (RoundCondition == RoundEnum.NewRound)
                {
                    NewRound();
                    Debug.WriteLine("New Round");
                }

            } while (RoundCondition != RoundEnum.GameOver);

            Debug.WriteLine("Game Over");

            // Wrap up
            EndBattle();

            return true;
        }
    }
}
