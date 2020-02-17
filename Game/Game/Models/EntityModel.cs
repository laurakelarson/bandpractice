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

        /// <summary>
        /// Method to calculate the damage that will be inflicted by the entity
        /// </summary>
        /// <returns></returns>
        public int GetAttackValue()
        {
            var roll = DiceHelper.RollDice(1, 20);
            var level_damage = Math.Ceiling((double)Level / 4);
            return roll + (int)level_damage;
        }


        public abstract string FormatOutput();
    }
}
