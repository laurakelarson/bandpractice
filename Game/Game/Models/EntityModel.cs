using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    public class EntityModel <T> : BaseModel <T>
    {
        // Status indicating whether the character is currently alive or not
        public bool Alive { get; set; } = true;

        // The level of the character
        public int Level { get; set; } = 1;
    }
}
