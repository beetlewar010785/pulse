using System.Collections.Generic;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Game
{
    public class MapGrid : ILogicalMap
    {
        private readonly HashSet<Vector2Int> _occupiedPoints = new();

        public int Width { get; }
        public int Height { get; }

        public MapGrid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IEnumerable<Vector2Int> GetAdjacentPoints(Vector2Int point)
        {
            var directions = new (int dx, int dy)[]
            {
                (0, 1), // Up
                (1, 0), // Right
                (0, -1), // Down
                (-1, 0) // Left
            };

            foreach (var (dx, dy) in directions)
            {
                var newX = point.x + dx;
                var newY = point.y + dy;

                if (newX >= 0 && newX < Width &&
                    newY >= 0 && newY < Height &&
                    !_occupiedPoints.Contains(new Vector2Int(newX, newY)))
                {
                    yield return new Vector2Int(newX, newY);
                }
            }
        }

        public void Occupy(Vector2Int point)
        {
            _occupiedPoints.Add(point);
        }

        public bool Occupied(Vector2Int point)
        {
            return _occupiedPoints.Contains(point);
        }
    }
}