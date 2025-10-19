using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Path;

public interface IWorldPathBuilder
{
    List<Vector2> Build(IEnumerable<Vector2Int> path);
}