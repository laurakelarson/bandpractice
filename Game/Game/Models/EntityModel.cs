using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public abstract class EntityModel <T> : BaseModel <T>
    {
        // Status indicating whether the character is currently alive or not
        public bool Alive { get; set; } = true;

        // The level of the entity
        public int Level { get; set; } = 1;

        // The speed of the entity
        public int Speed { get; set; } = 0;

        // The entity’s defense level. Higher defense makes it more difficult for entities to 
        // successfully attack
        public int Defense { get; set; } = 0;

        // The entity's attack level. A higher attack level will be more likely successful.
        public int Attack { get; set; } = 0;

        // The max health level of the character
        public int MaxHealth { get; set; } = 1;

        // The current health level of the entity
        public int CurrentHealth { get; set; } = 1;

        /// <summary>
        /// Method to inflict damage to Monster object
        /// </summary>
        public bool TakeDamage(int damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
                if (CurrentHealth < 0)
                {
                    Alive = false;
                    // drop items
                }
                return true;
            }
            return false;
        }

        
        

        // For each character/monster turn: There is a roll of a 20-sided dice: 
        // 1 is auto-miss, 20 is auto-hit. For all other rolls, the success of the 
        // turn entity’s hit is calculated by the following formula: 
        // (dice roll + Entity Level + Attack Modifiers) > (Target Defense attribute + Target level). 
        // If true, the hit succeeds; if false, it’s a miss and the turn is over for that entity.

        // Damage is determined by the following formula: dice roll + Weapon Damage + Level Damage.
        // Level damage is equal to ¼ of the entity’s level rounded up to the nearest whole integer.
        // Weapon damage is randomly found within the damage range of the weapon held by the entity 
        // (if a weapon has a damage attribute of 10, the weapon damage will be randomly determined in the range 1-10).


        public abstract string FormatOutput();
    }
}
