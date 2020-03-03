using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Beats model class. Stores the current number of beats
    /// the player has accumulated. Beats are used to recruit
    /// characters for battles. 
    /// </summary>
    public class BeatsModel : BaseModel<BeatsModel>, INotifyPropertyChanged
    {
        // The number of beats the player currently has 
        private int _Beats; 
        
        // Public getter and setter for Beats  
        public int Beats 
        { 
            get { return _Beats; }
            set
            {
                _Beats = Beats;
                OnPropertyChanged("Beats");
            }
        } 

        // Event handler for property changes of beats 
        public event PropertyChangedEventHandler PropertyChanged;

        // Invoked whenever value of 'Beats' changes. 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Default constructor. Sets Beats to 500,000 
        // by default. 
        public BeatsModel()
        {
            _Beats = 500000; 
        }

        // Constructor. Assigns initial value of beats to value passed
        // in to constructor. 
        public BeatsModel(int value)
        {
            _Beats = value; 
        }

        /// <summary>
        /// Update the beats model. 
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(BeatsModel newData)
        {
            // new data cannot be null
            if (newData == null)
            {
                return false; 
            }

            // cannot have fewer than 0 beats
            if (newData.Beats < 0)
            {
                return false; 
            }

            // Update beats value
            Beats = newData.Beats;
            return true; 
        }
    }
}
