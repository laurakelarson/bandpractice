﻿using System;
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

        public BattleEntityModel EmptySquare = new BattleEntityModel {
            EntityType = EntityTypeEnum.Unknown,
            ImageURI = "mapcell.png" };

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
        public bool MovePlayerOnMap(MapModelLocation data, MapModelLocation target)
        {
            if (!IsValidCoordinate(target))
            {
                return false;
            }

            MapGridLocation[target.Column, target.Row].Player = data.Player;

            // Clear out the old location
            MapGridLocation[data.Column, data.Row].Player = EmptySquare;

            return true;
        }

        /// <summary>
        /// Swap the players on the map in the given squares
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public bool SwapPlayersOnMap(MapModelLocation data1, MapModelLocation data2)
        {
            if (!IsValidCoordinate(data1))
            {
                return false;
            }

            if (!IsValidCoordinate(data2))
            {
                return false;
            }

            // swap the players
            var temp = data2.Player;
            MapGridLocation[data2.Column, data2.Row].Player = data1.Player;
            MapGridLocation[data1.Column, data1.Row].Player = temp;
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
        /// Return all Empty Locations on the map
        /// </summary>
        /// <returns></returns>
        public List<MapModelLocation> GetEmptyLocations()
        {
            var Result = new List<MapModelLocation>();

            foreach (var data in MapGridLocation)
            {
                if (data.Player.EntityType == EntityTypeEnum.Unknown)
                {
                    Result.Add(data);
                }
            }

            return Result;
        }

        /// <summary>
        /// Walk the Map and Find the Location that is close to the target
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public MapModelLocation ReturnClosestEmptyLocation(MapModelLocation Target)
        {
            MapModelLocation Result = null;

            int LowestDistance = int.MaxValue;

            foreach (var data in GetEmptyLocations())
            {
                var distance = CalculateDistance(data, Target);
                if (distance < LowestDistance)
                {
                    Result = data;
                    LowestDistance = distance;
                }
            }


            return Result;
        }

        /// <summary>
        /// Walk the Map and Find the Location that is reachable based on the range or closest to the target
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public MapModelLocation ReturnClosestEmptyLocation(MapModelLocation Target, int Range)
        {
            MapModelLocation Result = null;

            int LowestDistance = int.MaxValue;

            foreach (var data in GetEmptyLocations())
            {
                var distance = CalculateDistance(data, Target);

                // Target can be reached with this Range
                if (distance <= Range)
                {
                    return data;
                }

                if (distance < LowestDistance)
                {
                    Result = data;
                    LowestDistance = distance;
                }
            }


            return Result;
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

            if (locationAttacker == null)
            {
                return false;
            }

            if (locationDefender == null)
            {
                return false;
            }

            // Get X distance in absolute value
            var distance = Math.Abs(CalculateDistance(locationAttacker, locationDefender));

            var AttackerRange = Attacker.Range;

            // Can Reach?
            if (distance <= AttackerRange)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculate distance between two map locations
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int CalculateDistance(MapModelLocation start, MapModelLocation end)
        {
            if (start == null)
            {
                return int.MaxValue;
            }

            if (end == null)
            {
                return int.MaxValue;
            }

            return Distance(start.Column, start.Row, end.Column, end.Row);
        }

        /// <summary>
        /// Calculate Distance between locations
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public int Distance(int x1, int y1, int x2, int y2)
        {
            return ((int)Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
        }

        /// <summary>
        /// Verifies that the given coordinate is a valid location on this Map
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsValidCoordinate(MapModelLocation target)
        {
            if (target.Column < 0)
            {
                return false;
            }

            if (target.Row < 0)
            {
                return false;
            }

            if (target.Column >= MapXAxesCount)
            {
                return false;
            }

            if (target.Row >= MapYAxesCount)
            {
                return false;
            }

            return true;
        }
    }
}