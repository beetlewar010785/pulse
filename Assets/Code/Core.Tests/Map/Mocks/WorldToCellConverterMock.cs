using PulseTD.Core.Map;
using UnityEngine;

namespace PulseTD.Core.Tests.Map.Mocks;

public class WorldToCellConverterMock : IWorldToCellConverter
{
    private readonly float _cellSize;

    public WorldToCellConverterMock(float cellSize)
    {
        _cellSize = cellSize;
    }

    public Vector2Int Convert(Vector2 worldPosition)
    {
        return new Vector2Int((int)(worldPosition.x / _cellSize), (int)(worldPosition.y / _cellSize));
    }
}