using System.Collections.Generic;
using UnityEngine;

namespace PulseTD.Core.Spline;

public class CatmullRomWaypointsToSplineConverter : IWaypointsToSplineConverter
{
    private readonly int _samplesPerSegment;

    public CatmullRomWaypointsToSplineConverter(int samplesPerSegment)
    {
        _samplesPerSegment = samplesPerSegment;
    }

    public IList<Vector2> Convert(IList<Vector2> waypoints)
    {
        var result = new List<Vector2>();
        if (waypoints.Count == 0)
        {
            return result;
        }
        
        for (var i = -1; i < waypoints.Count - 2; i++)
        {
            var p0 = i < 0 ? waypoints[0] : waypoints[i];
            var p1 = waypoints[Mathf.Clamp(i + 1, 0, waypoints.Count - 1)];
            var p2 = waypoints[Mathf.Clamp(i + 2, 0, waypoints.Count - 1)];
            var p3 = waypoints[Mathf.Clamp(i + 3, 0, waypoints.Count - 1)];

            for (var s = 0; s < _samplesPerSegment; s++)
            {
                var t = s / (float)_samplesPerSegment;
                result.Add(Evaluate(p0, p1, p2, p3, t));
            }
        }
        result.Add(waypoints[^1]);

        return result;
    }
    
    private static Vector2 Evaluate(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        var t2 = t * t;
        var t3 = t2 * t;

        const float tension = 0.5f;
        return tension * (
            2f * p1 +
            (-p0 + p2) * t +
            (2f * p0 - 5f * p1 + 4f * p2 - p3) * t2 +
            (-p0 + 3f * p1 - 3f * p2 + p3) * t3
        );
    }
}
