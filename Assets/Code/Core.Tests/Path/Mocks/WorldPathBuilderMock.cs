using System.Collections.Generic;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path.Mocks;

public class WorldPathBuilderMock: IWorldPathBuilder
{
    private readonly List<Vector2> _path;

    public WorldPathBuilderMock(List<Vector2> path)
    {
        _path = path;
    }

    public List<Vector2> Build(IEnumerable<Vector2Int> path)
    {
        return _path;
    }
}