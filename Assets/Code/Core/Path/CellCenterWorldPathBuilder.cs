using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PulseTD.Core.Path;

public class CellCenterWorldPathBuilder : IWorldPathBuilder
{
    private readonly float _cellSize;

    public CellCenterWorldPathBuilder(float cellSize)
    {
        _cellSize = cellSize;
    }

    public Vector2[] Build(IEnumerable<Vector2Int> path)
    {
        return path
            .Select(pt => new Vector2(
                pt.x * _cellSize + _cellSize / 2,
                pt.y * _cellSize + _cellSize / 2))
            .ToArray();
    }
}