using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Path;

public interface ISplineBuilder
{
    IList<Vector2> Build(IList<Vector2> waypoints);
}