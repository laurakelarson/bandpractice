using System;
namespace Game.Models
{
    /// <summary>
    /// CoordinateModel class is used to store the coordinates of a cell on the Map.
    /// </summary>
    public class CoordinateModel
    {
        // Row of this coordinate
        public int Row = 0;

        // Column of this coordinate
        public int Column = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public CoordinateModel(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
    }
}
