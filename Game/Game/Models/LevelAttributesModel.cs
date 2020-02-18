using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /** LevelAttributesModel class. This class exists to make it 
     * easier to adjust the attributes of characters when they 
     * level up. **/
    public class LevelAttributesModel
    {
        // The level
        public int Level;

        // Base experience for this level
        public int Experience;

        // Attack bonus 
        public int Attack;

        // Defense bonus
        public int Defense;

        // Speed bonus 
        public int Speed; 

        /// <summary>
        /// Constructor. Creates level with passed in 
        /// attributes. 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="experience"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        public LevelAttributesModel(int level, int experience, int attack, 
            int defense, int speed)
        {
            Level = level;
            Experience = experience;
            Attack = attack;
            Defense = defense;
            Speed = speed; 
        }
    }
}
