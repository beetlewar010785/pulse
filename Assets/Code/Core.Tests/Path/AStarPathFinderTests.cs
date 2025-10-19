using NUnit.Framework;
using PulseTD.Core.Path;
using PulseTD.Core.Tests.Map.Mocks;
using UnityEngine;

namespace PulseTD.Core.Tests.Path;

public class AStarPathFinderTests
{
    [Test]
    public void Should_Find_Simple_Path()
    {
        // S 0 1 1
        // 1 0 0 1
        // 1 1 0 0
        // 1 1 1 E
        var logicalMap = new LogicalMapMock(4, 4);
        logicalMap.Occupy(new Vector2Int(0, 2));
        logicalMap.Occupy(new Vector2Int(0, 3));
        logicalMap.Occupy(new Vector2Int(1, 0));
        logicalMap.Occupy(new Vector2Int(1, 3));
        logicalMap.Occupy(new Vector2Int(2, 0));
        logicalMap.Occupy(new Vector2Int(2, 1));
        logicalMap.Occupy(new Vector2Int(3, 0));
        logicalMap.Occupy(new Vector2Int(3, 1));
        logicalMap.Occupy(new Vector2Int(3, 2));

        var sut = new AStarPathFinder(logicalMap);

        var actual = sut.FindPath(new Vector2Int(0, 0), new Vector2Int(3, 3));

        var expected = new[]
        {
            new Vector2Int(0, 0),
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(1, 2),
            new Vector2Int(2, 2),
            new Vector2Int(2, 3),
            new Vector2Int(3, 3)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Should_Return_Current_Point_When_No_path()
    {
        // S 1 0 
        // 1 0 0 
        // 0 0 E 
        var logicalMap = new LogicalMapMock(3, 3);
        logicalMap.Occupy(new Vector2Int(0, 1));
        logicalMap.Occupy(new Vector2Int(1, 0));

        var sut = new AStarPathFinder(logicalMap);

        var actual = sut.FindPath(new Vector2Int(0, 0), new Vector2Int(2, 2));

        var expected = new[]
        {
            new Vector2Int(0, 0)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Should_Return_Best_Path()
    {
        // S 0 0 0
        // 0 0 1 0
        // 0 0 1 E
        // 0 0 0 0
        var logicalMap = new LogicalMapMock(4, 4);
        logicalMap.Occupy(new Vector2Int(2, 1));
        logicalMap.Occupy(new Vector2Int(2, 2));
        
        var sut = new AStarPathFinder(logicalMap);

        var actual = sut.FindPath(new Vector2Int(0, 0), new Vector2Int(3, 2));

        var expected = new[]
        {
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(3, 0),
            new Vector2Int(3, 1),
            new Vector2Int(3, 2)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}