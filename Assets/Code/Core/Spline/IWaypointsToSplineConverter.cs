using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Spline;

public interface IWaypointsToSplineConverter
{
    IList<Vector2> Convert(IList<Vector2> waypoints);
}