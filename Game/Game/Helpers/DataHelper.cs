using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

namespace Game.Helpers
{
    class DataHelper
    {

        /// <summary>
        /// Returns default Tambourine Player CharacterModel
        /// </summary>
        /// <returns></returns>
        public CharacterModel DefaultTambourine()
        {
            return new CharacterModel
            {
                Name = "Tambourine Player",
                Type = CharacterTypeEnum.TambourinePlayer,
                ImageURI = "tambourine.png",
                IconURI = "tambourine_icon.png",
                Alive = true,
                Level = 1,
                TotalExperience = 0,
                Attack = 1,
                Defense = 1,
                Speed = 1,
                MaxHealth = 20,
                CurrentHealth = 20
            };
        }

    }
}
