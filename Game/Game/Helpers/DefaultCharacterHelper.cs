﻿using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

namespace Game.Helpers
{
    /// <summary>
    /// DataHelper is a static class that helps create characters with the game's default base stats.
    /// </summary>
    public static class DefaultCharacterHelper
    {

        /// <summary>
        /// Helper that takes in a CharacterTypeEnum to return the default base version of that type
        /// </summary>
        /// <param name="type"></param>
        public static CharacterModel DefaultCharacter(CharacterTypeEnum type)
        {
            switch (type)
            {
                case CharacterTypeEnum.Bassist:
                    return DefaultBassist();
                case CharacterTypeEnum.Keyboardist:
                    return DefaultKeyboardist();
                case CharacterTypeEnum.Drummer:
                    return DefaultDrummer();
                case CharacterTypeEnum.Guitarist:
                    return DefaultGuitarist();
                case CharacterTypeEnum.LeadVocalist:
                    return DefaultLeadVocalist();
                default:
                    return DefaultTambourine();
            }
        }

        /// <summary>
        /// Returns default Tambourine Player CharacterModel
        /// </summary>
        /// <returns></returns>
        public static CharacterModel DefaultTambourine()
        {
            var name = RandomEntityHelper.GetCharacterName();

            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.TambourinePlayer,
                ImageURI = "sprite_tambourine.png",
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
        public static CharacterModel DefaultBassist()
        {
            var name = RandomEntityHelper.GetCharacterName();
            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.Bassist,
                ImageURI = "sprite_bassist.png",
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
        public static CharacterModel DefaultKeyboardist()
        {
            var name = RandomEntityHelper.GetCharacterName();
            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.Keyboardist,
                ImageURI = "sprite_keyboardist.png",
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
        public static CharacterModel DefaultDrummer()
        {
            var name = RandomEntityHelper.GetCharacterName();
            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.Drummer,
                ImageURI = "sprite_drummer.png",
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

        /// <summary>
        /// Returns default Guitarist CharacterModel
        /// </summary>
        /// <returns></returns>
        public static CharacterModel DefaultGuitarist()
        {
            var name = RandomEntityHelper.GetCharacterName();
            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.Guitarist,
                ImageURI = "sprite_guitarist.png",
                IconURI = "guitarist_icon.png",
                Level = 12,
                Alive = true,
                TotalExperience = 100000,
                Attack = 4,
                Defense = 6,
                Speed = 3,
                MaxHealth = 120,
                CurrentHealth = 120
            };
        }

        /// <summary>
        /// Returns default Lead Vocalist CharacterModel
        /// </summary>
        /// <returns></returns>
        public static CharacterModel DefaultLeadVocalist()
        {
            var name = RandomEntityHelper.GetCharacterName();
            return new CharacterModel
            {
                Name = name,
                Type = CharacterTypeEnum.LeadVocalist,
                ImageURI = "sprite_vocalist.png",
                IconURI = "vocalist_icon.png",
                Level = 16,
                Alive = true,
                TotalExperience = 195000,
                Attack = 5,
                Defense = 8,
                Speed = 4,
                MaxHealth = 120,
                CurrentHealth = 120
            };
        }


    }
}
