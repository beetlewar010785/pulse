using System.Collections.Generic;
using PulseTD.Core.Map;
using UnityEngine;

namespace PulseTD.Core.Tests.Map.Mocks;

public class LogicalMapMock : ILogicalMap
{
    private readonly int _width;
    private readonly int _height;
    private readonly HashSet<Vector2Int> _occupiedPoints = new();

    public LogicalMapMock(int width, int height)
    {
        _width = width;
        _height = height;
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

            if (newX >= 0 && newX < _width &&
                newY >= 0 && newY < _height &&
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
}