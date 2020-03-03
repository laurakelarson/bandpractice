using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Game.Helpers
{
    public static class GridPositionHelper
    {
        // Monster positions for battle grid starting spots, which don't change round to round
        public static List<Point> MonsterPositions = new List<Point> { 
            new Point(0,4), new Point(1,5), new Point(2,4), new Point(3,5), new Point(4,4), new Point(5,5)};

        // Character positions for battle grid starting spots, which don't change round to round
        public static List<Point> CharacterPositions = new List<Point> {
            new Point(0,2), new Point(1,1), new Point(2,2), new Point(3,1), new Point(4,2), new Point(5,1)};

    }
}
