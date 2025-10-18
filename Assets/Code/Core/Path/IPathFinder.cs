using UnityEngine;

namespace PulseTD.Core.Path;

public interface IPathFinder
{
    public Vector2Int[] FindPath(Vector2Int start, Vector2Int end);
}