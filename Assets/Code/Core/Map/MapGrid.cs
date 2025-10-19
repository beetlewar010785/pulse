using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Map
{
    public class MapGrid : ILogicalMap, IWorldToCellConverter
    {
        private readonly HashSet<Vector2Int> _occupiedPoints = new();

        public int Width { get; }
        public int Height { get; }
        public float CellSize { get; }

        public MapGrid(int width, int height, float cellSize)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
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

        public Vector2Int Convert(Vector2 worldPosition)
        {
            return new Vector2Int((int)(worldPosition.x / CellSize), (int)(worldPosition.y / CellSize));
        }
    }
}