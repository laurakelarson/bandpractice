﻿using System;

namespace Game.Models
{
    /// <summary>
    /// Score model for the game. Keeps track of all details of the full battle, including
    /// score, turn count, round count, list of monsters slain, total number of monsters 
    /// slain, list of characters and their attributes at their death, and list of items
    /// dropped during gameplay. 
    /// 
    /// </summary>
    public class ScoreModel : BaseModel<ScoreModel>
    {
        // This battle number, incremental int from the last int in the database
        public int BattleNumber { get; set; }

        // Total Score
        public int ScoreTotal { get; set; }

        // The Date the game played, and when the score was saved
        public DateTime GameDate { get; set; }

        // Tracks if auto battle is true, or if user battle = false
        public bool AutoBattle { get; set; }

        // The number of turns the battle took to finish
        public int TurnCount { get; set; }

        // The number of rounds the battle took to finish
        public int RoundCount { get; set; }

        // The count of monsters slain during battle
        public int MonsterSlainNumber { get; set; }

        // The total experience points all the characters received during the battle
        public int ExperienceGainedTotal { get; set; }

        // A list of all the characters at the time of death and their stats.  
        // Only use Get only, set will be done by the Add feature.
        public string CharacterAtDeathList { get; set; } = "";

        // All of the monsters killed and their stats. 
        // Only use Get only, set will be done by the Add feature.
        public string MonstersKilledList { get; set; } = "";

        // All of the items dropped and their stats. 
        // Only use Get only, set will be done by the Add feature.
        public string ItemsDroppedList { get; set; } = "";

        /// <summary>
        /// Instantiate new Score 
        /// </summary>
        public ScoreModel()
        {
            GameDate = DateTime.Now;    // Set to be now by default.
            AutoBattle = false;         //assume user battle
            TurnCount = 0;
            RoundCount = 0;
            TurnCount = 0;
            ExperienceGainedTotal = 0;
            MonsterSlainNumber = 0;
        }

        /// <summary>
        /// Constructor for loading score from SQL
        /// Takes a Score and make a scopy of it.
        /// </summary>
        /// <param name="data"></param>
        public ScoreModel(ScoreModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update the score based on the passed in values. 
        /// </summary>
        /// <param name="newData"></param>
        public override bool Update(ScoreModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            Description = newData.Description;

            BattleNumber = newData.BattleNumber;
            ScoreTotal = newData.ScoreTotal;
            GameDate = newData.GameDate;
            AutoBattle = newData.AutoBattle;
            TurnCount = newData.TurnCount;
            RoundCount = newData.RoundCount;
            MonsterSlainNumber = newData.MonsterSlainNumber;
            ExperienceGainedTotal = newData.ExperienceGainedTotal;
            CharacterAtDeathList = newData.CharacterAtDeathList;
            MonstersKilledList = newData.MonstersKilledList;
            ItemsDroppedList = newData.ItemsDroppedList;

            return true;
        }

        #region ScoreItems

        /// <summary>
        /// Helper method to add a CharacterModel to the CharacterAtDeathList
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddToList(CharacterModel data)
        {
            if (data == null)
            {
                return false;
            }

            CharacterAtDeathList += data.FormatOutput() + "\n";
            return true;
        }

        /// <summary>
        /// Helper method to add a MonsterModel to the MonsterAtDeathList
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddToList(MonsterModel data)
        {
            if (data == null)
            {
                return false;
            }
            MonsterSlainNumber++;
            MonstersKilledList += data.FormatOutput() + "\n";
            return true;
        }

        /// <summary>
        /// All an item to the list of items for score and their stats
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddToList(ItemModel data)
        {
            if (data == null)
            {
                return false;
            }

            ItemsDroppedList += data.FormatOutput() + "\n";
            return true;
        }
        #endregion ScoreItems
    }
}