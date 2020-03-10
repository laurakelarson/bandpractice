using System.Collections.Generic;
using Game.Models.Enum;

namespace Game.Models
{
    /// <summary>
    /// Manages the Message formatting for the UI to Display
    /// </summary>
    public class BattleMessagesModel
    {
        // Is the player a character or a monster
        public EntityTypeEnum PlayerType = EntityTypeEnum.Unknown;

        // The Status of the action
        public HitStatusEnum HitStatus = HitStatusEnum.Unknown;

        // Name of the Attacker
        public string AttackerName = string.Empty;

        // Name of who the target was
        public string TargetName = string.Empty;

        // The status of the Attack
        public string AttackStatus = string.Empty;

        // Turn Message
        public string TurnMessage = string.Empty;

        // Turn Special Message
        public string TurnMessageSpecial = string.Empty;

        // Turn Experience Earned Message
        public string ExperienceEarned = string.Empty;

        // Level Up Message
        public string LevelUpMessage = string.Empty;

        // Amount of Damage
        public int DamageAmount = 0;

        // The Remaining Health Mesage
        public int CurrentHealth = 0;

        // Message about the items equipped by characters during an item swap
        public List<string> ItemsEquipped = new List<string>();

        // Track whether attack was a Critical Hit (hackathon rule)
        public bool CriticalHit = false;

        // Beginning of the Html Block for html formatting
        public string htmlHead = @"<html><body bgcolor=""#E8D0B6""><p>";

        // Ending of the Html Block for Html formatting
        public string htmlTail = @"</p></body></html>";

        /// <summary>
        /// Clear all the battle messsages to start fresh
        /// </summary>
        /// <returns></returns>
        public bool ClearMessages()
        {

            PlayerType = EntityTypeEnum.Unknown;
            HitStatus = HitStatusEnum.Unknown;
            AttackerName = string.Empty;
            TargetName = string.Empty;
            AttackStatus = string.Empty;
            TurnMessage = string.Empty;
            TurnMessageSpecial = string.Empty;
            ExperienceEarned = string.Empty;
            LevelUpMessage = string.Empty;

            DamageAmount = 0;
            CurrentHealth = 0;

            return true;
        }

        /// <summary>
        /// Return formatted string
        /// </summary>
        /// <param name="hitStatus"></param>
        /// <returns></returns>
        public string GetSwingResult()
        {
            return HitStatus.ToMessage();
        }

        /// <summary>
        /// Return formatted Damage
        /// </summary>
        /// <returns></returns>
        public string GetDamageMessage()
        {
            return string.Format(" for {0} damage ", DamageAmount);
        }

        /// <summary>
        /// Returns the String Attacker Hit Defender
        /// </summary>
        /// <returns></returns>
        public string GetTurnMessage()
        {
            return AttackerName + GetSwingResult() + TargetName;
        }

        /// <summary>
        /// Remaining Health Message
        /// </summary>
        /// <returns></returns>
        public string GetCurrentHealthMessage()
        {
            return " remaining health is " + CurrentHealth.ToString();
        }

        /// <summary>
        /// Add an item equipped message to the list.
        /// </summary>
        /// <param name="CharacterName"></param>
        /// <param name="ItemName"></param>
        /// <returns></returns>
        public bool AddItemEquipped(string CharacterName, string ItemName)
        {
            string message = CharacterName + " equipped " + ItemName + ".";
            ItemsEquipped.Add(message);
            return true;
        }

        /// <summary>
        /// Returns the Items Equipped message as a string.
        /// </summary>
        /// <returns></returns>
        public string GetItemsEquippedMessage()
        {
            string message = "";
            foreach (string line in ItemsEquipped)
            {
                message += line + "\n";
            }
            return message;
        }

        /// <summary>
        /// Returns a blank HTML page, used for clearing the output window
        /// </summary>
        /// <returns></returns>
        public string GetHTMLBlankMessage()
        {
            var myResult = htmlHead + htmlTail;
            return myResult;
        }

        /// <summary>
        /// Output the Turn as a HTML string
        /// </summary>
        /// <returns></returns>
        public string GetHTMLFormattedTurnMessage()
        {
            var myResult = string.Empty;

            var AttackerStyle = @"<span style=""color:blue"">";
            var DefenderStyle = @"<span style=""color:green"">";

            if (PlayerType == EntityTypeEnum.Monster)
            {
                // If monster, swap the colors
                DefenderStyle = @"<span style=""color:blue"">";
                AttackerStyle = @"<span style=""color:green"">";
            }

            var SwingResult = string.Empty;
            switch (HitStatus)
            {
                case HitStatusEnum.Miss:
                    SwingResult = @"<span style=""color:yellow"">";
                    break;

                case HitStatusEnum.CriticalMiss:
                    SwingResult = @"<span bold style=""color:yellow; font-weight:bold;"">";
                    break;

                case HitStatusEnum.CriticalHit:
                    SwingResult = @"<span bold style=""color:red; font-weight:bold;"">";
                    break;

                case HitStatusEnum.Hit:
                default:
                    SwingResult = @"<span style=""color:red"">";
                    break;
            }

            var htmlBody = string.Empty;
            htmlBody += string.Format(@"{0}{1}</span>", AttackerStyle, AttackerName);
            htmlBody += string.Format(@"{0}{1}</span>", SwingResult, GetSwingResult());
            htmlBody += string.Format(@"{0}{1}</span>", DefenderStyle, TargetName);
            htmlBody += string.Format(@"<span>{0}</span>", TurnMessageSpecial);

            myResult = htmlHead + htmlBody + htmlTail;
            return myResult;
        }
    }
}