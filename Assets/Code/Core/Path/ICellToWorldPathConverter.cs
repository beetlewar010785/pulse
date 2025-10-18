using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Path;

public interface ICellToWorldPathConverter
{
    Vector2[] Convert(IEnumerable<Vector2Int> path);
}