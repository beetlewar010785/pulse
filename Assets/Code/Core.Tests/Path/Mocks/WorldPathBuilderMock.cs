using System.Collections.Generic;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path.Mocks;

public class WorldPathBuilderMock: IWorldPathBuilder
{
    private readonly Vector2[] _path;

    public WorldPathBuilderMock(Vector2[] path)
    {
        _path = path;
    }

    public Vector2[] Build(IEnumerable<Vector2Int> path)
    {
        return _path;
    }
}