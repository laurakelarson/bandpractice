using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using Game.Models.Enum;

/// <summary>
/// Holds the data structures for the battle engine.
/// </summary>
namespace Game.Engine
{
    public class BaseEngine
    {
        // The score of the battle
        public ScoreModel Score = new ScoreModel();

        // Manages the battle messages for the UI
        public BattleMessagesModel BattleMessages = new BattleMessagesModel();

        // The pool of items dropped and collected throughout the battle round
        public List<ItemModel> ItemPool = new List<ItemModel>();

        // Monsters in the battle
        public List<MonsterModel> MonsterList = new List<MonsterModel>();

        // Characters in the battle
        public List<CharacterModel> CharacterList = new List<CharacterModel>();

        // Max number of Characters
        public int MaxNumberCharacters = 6;

        // Max number of Monsters
        public int MaxNumberMonsters = 6;

        // Max Number of Rounds for AutoBattle
        public int MaxRoundCount = 1000;

        // Max Number of Turns for AutoBattle
        public int MaxTurnCount = 10000;

        // Current Round state
        public RoundEnum RoundState = RoundEnum.Unknown;

        // List of current characters and monsters in battle
        public List<BattleEntityModel> EntityList = new List<BattleEntityModel>();

        // Current attacking entity
        public BattleEntityModel CurrentAttacker;

        // Current defending entity
        public BattleEntityModel CurrentDefender;

        // Entity currently engaged
        public BattleEntityModel CurrentEntity;

        // The Current Action 
        public ActionEnum CurrentAction;

        // Hold the current coordinate on the map
        public CoordinateModel CurrentMapLocation;

        // Hold the coordinate to move to on the map
        public CoordinateModel MoveMapLocation;

        // The battle Map
        public MapModel MapModel = new MapModel();

        // Flag to enable Critical Hits (hackathon rule)
        public bool CriticalHitsEnabled = false;

        // Flag to enable Critical Miss (hackathon rule)
        public bool CriticalMissEnabled = false;
    }
}
