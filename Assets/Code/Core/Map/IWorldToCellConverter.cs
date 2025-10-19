using UnityEngine;

namespace PulseTD.Core.Map;

public interface IWorldToCellConverter
{
    Vector2Int Convert(Vector2 worldPosition);
}