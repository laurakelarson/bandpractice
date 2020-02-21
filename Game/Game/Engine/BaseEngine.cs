using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

/// <summary>
/// Holds the data structures for the battle engine.
/// </summary>
namespace Game.Engine
{
    class BaseEngine
    {
        // The score of the battle
        public ScoreModel Score = new ScoreModel();

        // The pool of items dropped and collected throughout the battle round
        public List<ItemModel> ItemPool = new List<ItemModel>();

        // Monsters in the battle
        public List<MonsterModel> MonsterList = new List<MonsterModel>();

        // Characters in the battle
        public List<CharacterModel> CharacterList = new List<CharacterModel>();
    }
}
