using NUnit.Framework;
using PulseTD.Core.Path;
using UnityEngine;

namespace PulseTD.Core.Tests.Path;

public class CellCenterCellToWorldPathConverterTests
{
    [Test]
    public void Should_Return_Center_Of_Cell()
    {
        var initialPath = new[]
        {
            new Vector2Int(0, 0),
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(1, 2)
        };
        
        var actual = new CellCenterCellToWorldPathConverter(2)
            .Convert(initialPath);

        var expected = new[]
        {
            new Vector2(1, 1),
            new Vector2(1, 3),
            new Vector2(3, 3),
            new Vector2(3, 5)
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}