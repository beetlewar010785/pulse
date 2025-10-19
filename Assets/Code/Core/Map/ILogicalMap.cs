using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Map;

public interface ILogicalMap
{
    IEnumerable<Vector2Int> GetAdjacentPoints(Vector2Int point);
}