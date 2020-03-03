using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Beats model class. Stores the current number of beats
    /// the player has accumulated. Beats are used to recruit
    /// characters for battles. 
    /// </summary>
    public class BeatsModel : BaseModel<BeatsModel>
    {
        // The number of beats the player currently has. 
        public int Beats { get; set; } = 500000;


    }
}
