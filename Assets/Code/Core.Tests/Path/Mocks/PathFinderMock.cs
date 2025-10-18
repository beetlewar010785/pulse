using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path.Mocks;

public class PathFinderMock: IPathFinder
{
    private readonly Vector2Int[] _path;

    public PathFinderMock(Vector2Int[] path)
    {
        _path = path;
    }

    public Vector2Int[] FindPath(Vector2Int start, Vector2Int end)
    {
        return _path;
    }
}