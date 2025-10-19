using NUnit.Framework;
using PulseTD.Core.Map;
using UnityEngine;

namespace PulseTD.Core.Tests.Map;

public class MapGridTests
{
    [Test]
    public void Should_Convert_World_To_Cell()
    {
        var sut = new MapGrid(10, 10, 1.5f);

        var actual = sut.Convert(new Vector2(2.5f, 3.5f));

        var expected = new Vector2Int(1, 2);

        Assert.That(actual, Is.EqualTo(expected));
    }
}