using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class EntityModel <T> : BaseModel <T>
    {
        // Status indicating whether the entity is currently alive or not
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

        // The max health level of the entity
        public int MaxHealth { get; set; } = 1;

        // The current health level of the entity
        public int CurrentHealth { get; set; } = 1;

        // The movement range of the entity. Base stat starts at 1.
        public int Range { get; set; } = 1;

        /// <summary>
        /// Method to inflict damage to Entity object
        /// </summary>
        public bool TakeDamage(int damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= 0)
                {
                    // to prevent negative health for messages
                    CurrentHealth = 0;
                    Alive = false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change the level - should be implemented in inheriting classes.
        /// For now, return false.
        /// </summary>
        /// <param name="levelValue"></param>
        /// <returns></returns>
        public bool ChangeLevel(int levelValue)
        {
            return false;
        }

        /// <summary>
        /// Format output of the EntityModel - should be implemented in inheriting classes.
        /// </summary>
        /// <returns></returns>
        public string FormatOutput()
        {
            return string.Empty;
        }

        // Row position for entity on battle grid
        public int RowPos { get; set; }

        // Column position for entity on battle grid
        public int ColPos { get; set; }
    }
}
