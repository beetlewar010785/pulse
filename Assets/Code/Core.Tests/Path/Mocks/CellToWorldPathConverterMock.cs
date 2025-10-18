using System.Collections.Generic;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path.Mocks;

public class CellToWorldPathConverterMock: ICellToWorldPathConverter
{
    private readonly Vector2[] _path;

    public CellToWorldPathConverterMock(Vector2[] path)
    {
        _path = path;
    }

    public Vector2[] Convert(IEnumerable<Vector2Int> path)
    {
        return _path;
    }
}