using System;
using System.Collections.Generic;
using NUnit.Framework;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path;

public class CatmullRomSplineBuilderTests
{
    [TestCaseSource(nameof(GetTestCases))]
    public int Should_Convert_Waypoints_To_Spline(IList<Vector2> waypoints)
    {
        var sut = new CatmullRomSplineBuilder(4);
        var spline = sut.Build(waypoints);
        return spline.Count;
    }

    private static IEnumerable<TestCaseData> GetTestCases()
    {
        yield return new TestCaseData(new[]
        {
            new Vector2(1, 1),
            new Vector2(2, 1),
            new Vector2(2, 2),
            new Vector2(2, 3),
            new Vector2(3, 3)
        }).Returns(17);

        yield return new TestCaseData(new[]
        {
            new Vector2(1, 1)
        }).Returns(1);

        yield return new TestCaseData(new[]
        {
            new Vector2(1, 1),
            new Vector2(2, 1)
        }).Returns(5);

        yield return new TestCaseData(
            Array.Empty<Vector2>()
        ).Returns(0);
    }
}