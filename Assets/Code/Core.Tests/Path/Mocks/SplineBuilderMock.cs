using System.Collections.Generic;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path.Mocks;

public class SplineBuilderMock: ISplineBuilder
{
    private readonly IList<Vector2> _spline;

    public SplineBuilderMock(IList<Vector2> spline)
    {
        _spline = spline;
    }

    public IList<Vector2> Build(IList<Vector2> waypoints)
    {
        return _spline;
    }
}