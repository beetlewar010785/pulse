using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Path;

public interface IWorldPathBuilder
{
    Vector2[] Build(IEnumerable<Vector2Int> path);
}