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

        /// <summary>
        /// Returns default Bassist CharacterModel
        /// </summary>
        /// <returns></returns>
        public CharacterModel DefaultBassist()
        {
            return new CharacterModel
            {
                Name = "Bassist",
                Type = CharacterTypeEnum.Bassist,
                ImageURI = "bassist.png",
                IconURI = "bassist_icon.png",
                Level = 2,
                Alive = true,
                TotalExperience = 300,
                Attack = 1,
                Defense = 1,
                Speed = 1,
                MaxHealth = 30,
                CurrentHealth = 30
            };
        }

        /// <summary>
        /// Returns default Keyboardist CharacterModel
        /// </summary>
        /// <returns></returns>
        public CharacterModel DefaultKeyboardist()
        {
            return new CharacterModel
            {
                Name = "Keyboardist",
                Type = CharacterTypeEnum.Keyboardist,
                ImageURI = "keyboardist.png",
                IconURI = "keyboardist_icon.png",
                Level = 5,
                Alive = true,
                TotalExperience = 6500,
                Attack = 2,
                Defense = 4,
                Speed = 2,
                MaxHealth = 50,
                CurrentHealth = 50
            };
        }

        /// <summary>
        /// Returns default Drummer CharacterModel
        /// </summary>
        /// <returns></returns>
        public CharacterModel DefaultDrummer()
        {
            return new CharacterModel
            {
                Name = "Drummer",
                Type = CharacterTypeEnum.Drummer,
                ImageURI = "drummer.png",
                IconURI = "drummer_icon.png",
                Level = 8,
                Alive = true,
                TotalExperience = 34000,
                Attack = 3,
                Defense = 5,
                Speed = 2,
                MaxHealth = 80,
                CurrentHealth = 80
            };
        }

    }
}
