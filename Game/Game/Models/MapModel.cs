using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Models;
using Game.Models.Enum;

namespace Game.Models
{
    /// <summary>
    /// Represent the Map
    /// 
    /// The Cordinates
    /// What is at that location
    /// 
    /// </summary>
    public class MapModel
    {
        // The X axies Size
        public int MapXAxesCount = 6;

        // The Y axies Size
        public int MapYAxesCount = 6;

        // The Map Locations
        public MapModelLocation[,] MapGridLocation;

        public BattleEntityModel EmptySquare = new BattleEntityModel { EntityType = EntityTypeEnum.Unknown };

        public MapModel()
        {
            // Create the Map
            MapGridLocation = new MapModelLocation[MapXAxesCount, MapYAxesCount];

            ClearMapGrid();
        }

        /// <summary>
        /// Create an Empty Map
        /// </summary>
        /// <returns></returns>
        public bool ClearMapGrid()
        {
            //Populate Map with Empty Values
            for (var x = 0; x < MapXAxesCount; x++)
            {
                for (var y = 0; y < MapYAxesCount; y++)
                {
                    // Populate the entire map with blank
                    MapGridLocation[x, y] = new MapModelLocation { Row = y, Column = x, Player = EmptySquare };
                }
            }
            return true;
        }

        /// <summary>
        /// Initialize the Data Structure
        /// Add Characters and Monsters to the Map
        /// </summary>
        /// <param name="PlayerList"></param>
        /// <returns></returns>
        public bool PopulateMapModel(List<BattleEntityModel> PlayerList)
        {
            ClearMapGrid();

            int x = 0;
            int y = 0;
            foreach (var data in PlayerList.Where(m => m.EntityType == EntityTypeEnum.Character))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxesCount)
                {
                    x = 0;
                    y++;
                }
            }

            x = 0;
            y = MapYAxesCount - 1;
            foreach (var data in PlayerList.Where(m => m.EntityType == EntityTypeEnum.Monster))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxesCount)
                {
                    x = 0;
                    y--;
                }
            }

            return true;
        }

        /// <summary>
        /// Changes the Row and Column for the Player
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool MovePlayerOnMap(MapModelLocation data, int ToX, int ToY)
        {
            if (ToX < 0)
            {
                return false;
            }

            if (ToY < 0)
            {
                return false;
            }

            if (ToX >= MapXAxesCount)
            {
                return false;
            }

            if (ToY >= MapYAxesCount)
            {
                return false;
            }

            MapGridLocation[ToX, ToY].Player = data.Player;

            // Clear out the old location
            MapGridLocation[data.Column, data.Row].Player = EmptySquare;

            return true;
        }

        /// <summary>
        /// Remove the Player from the Map
        /// Replaces with Empty Square
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RemovePlayerFromMap(BattleEntityModel data)
        {
            for (var x = 0; x < MapXAxesCount; x++)
            {
                for (var y = 0; y < MapYAxesCount; y++)
                {
                    if (MapGridLocation[x, y].Player.Id.Equals(data.Id))
                    {
                        MapGridLocation[x, y] = new MapModelLocation { Column = x, Row = y, Player = EmptySquare };
                        return true;
                    }
                }
            }

            // Not found
            return false;
        }

        /// <summary>
        /// Clear all Locations of the Selected Bool
        /// 
        /// Mike does not use this in the example battle grammar
        /// 
        /// TODO: INFO  Could be helpfull to track what is selected for actions etc
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ClearSelection()
        {
            foreach (var data in MapGridLocation)
            {
                data.IsSelectedTarget = false;
            }

            return true;
        }

        /// <summary>
        /// Find the Player on the map
        /// Return their information
        /// 
        /// If they don't exist, return null
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public MapModelLocation GetLocationForPlayer(BattleEntityModel player)
        {
            if (player == null)
            {
                return null;
            }

            foreach (var data in MapGridLocation)
            {
                if (data.Player.Id.Equals(player.Id))
                {
                    return data;
                }
            }

            return null;
        }

        /// <summary>
        /// Return who is at the location
        /// Could be Character, Monster or Empty
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BattleEntityModel GetPlayerAtLocation(int x, int y)
        {
            return MapGridLocation[x, y].Player;
        }

        /// <summary>
        /// Is the location empty?
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool IsEmptySquare(int x, int y)
        {
            var player = MapGridLocation[x, y].Player;

            // Unknown is Empty
            if (player.EntityType == EntityTypeEnum.Unknown)
            {
                return true;
            }

            // Occupied
            return false;
        }

        /// <summary>
        /// See if the Attacker is next to the Defender by the distance of Range
        /// 
        /// If either the X or Y distance is less than or equal the range, then they can hit
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Defender"></param>
        /// <returns></returns>
        public bool IsTargetInRange(BattleEntityModel Attacker, BattleEntityModel Defender)
        {
            var locationAttacker = GetLocationForPlayer(Attacker);
            var locationDefender = GetLocationForPlayer(Defender);

            // Get X distance in absolute value
            var distanceX = Math.Abs(locationAttacker.Column - locationDefender.Column);
            var distanceY = Math.Abs(locationAttacker.Row - locationDefender.Row);

            var AttackerRange = Attacker.Range;

            // Can Reach on X?
            if (distanceX <= AttackerRange)
            {
                return true;
            }

            // Can reach on Y?
            if (distanceY <= AttackerRange)
            {
                return true;
            }

            return false;
        }
    }
}