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
            new Point(2,2), new Point(3,1), new Point(4,2), new Point(1,1), new Point(5,1), new Point(0,2)};

        public static string[,] GridPositions = new string[6, 7] {
            {"R0C0", "R0C1", "R0C2", "R0C3", "R0C4", "R0C5", "R0C6" },
            {"R1C0", "R1C1", "R1C2", "R1C3", "R1C4", "R1C5", "R1C6" },
            {"R2C0", "R2C1", "R2C2", "R2C3", "R2C4", "R2C5", "R2C6" },
            {"R3C0", "R3C1", "R3C2", "R3C3", "R3C4", "R3C5", "R3C6" },
            {"R4C0", "R4C1", "R4C2", "R4C3", "R4C4", "R4C5", "R4C6" },
            {"R5C0", "R5C1", "R5C2", "R5C3", "R5C4", "R5C5", "R5C6" }};

    }
}
