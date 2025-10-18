using System.Collections.Generic;
using PulseTD.Core.Spline;
using UnityEngine;

namespace PulseTD.Core.Tests.Spline.Mocks;

public class WaypointsToSplineConverterMock: IWaypointsToSplineConverter
{
    private readonly IList<Vector2> _spline;

    public WaypointsToSplineConverterMock(IList<Vector2> spline)
    {
        _spline = spline;
    }

    public IList<Vector2> Convert(IList<Vector2> waypoints)
    {
        return _spline;
    }
}