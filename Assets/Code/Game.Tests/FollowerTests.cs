using System;
using NUnit.Framework;
using PulseTD.Core.Tests.Path.Mocks;
using PulseTD.Core.Tests.Spline.Mocks;
using UnityEngine;

namespace PulseTD.Game.Tests
{
    public class FollowerTests
    {
        [Test]
        public void Should_Throw_Exception_On_Calculate_When_No_Path()
        {
            var spline = Array.Empty<Vector2>();

            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(spline);
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);

            Assert.Throws<InvalidOperationException>(() =>
                sut.CalculatePath(new Vector2Int(0, 0), new Vector2Int(0, 0)));
        }

        [Test]
        public void Should_Throw_Exception_On_Update_Position_Before_CalculatePath()
        {
            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(Array.Empty<Vector2>());
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);

            Assert.Throws<InvalidOperationException>(() => sut.UpdatePosition(1, 0.1f));
        }

        [Test]
        public void Should_Move_To_The_Next_Waypoint()
        {
            var spline = new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0)
            };

            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(spline);
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);
            sut.CalculatePath(new Vector2Int(0, 0), new Vector2Int(0, 0));

            sut.UpdatePosition(0.5f, 1f);

            Assert.That(sut.Position, Is.EqualTo(new Vector2(0.5f, 0f)));
        }

        [Test]
        public void Should_Overlap_Next_Waypoint()
        {
            var spline = new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1)
            };

            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(spline);
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);
            sut.CalculatePath(new Vector2Int(0, 0), new Vector2Int(0, 0));

            sut.UpdatePosition(1f, 1.5f);

            Assert.That(sut.Position, Is.EqualTo(new Vector2(1f, 0.5f)));
        }

        [Test]
        public void Should_Reach_The_End_Of_The_Path()
        {
            var spline = new[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(2, 0),
                new Vector2(3, 0.5f)
            };

            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(spline);
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);
            sut.CalculatePath(new Vector2Int(0, 0), new Vector2Int(0, 0));

            sut.UpdatePosition(10f, 1f);

            Assert.That(sut.Position, Is.EqualTo(new Vector2(3f, 0.5f)));
            Assert.That(sut.IsEndReached, Is.True);
        }

        [Test]
        public void Should_Not_Fail_When_Single_Waypoint()
        {
            var spline = new[]
            {
                new Vector2(0, 0)
            };

            var pathFinder = new PathFinderMock(Array.Empty<Vector2Int>());
            var cellToWorldPathConverter = new CellToWorldPathConverterMock(Array.Empty<Vector2>());
            var waypointsToSplineConverter = new WaypointsToSplineConverterMock(spline);
            var sut = new Follower(pathFinder, cellToWorldPathConverter, waypointsToSplineConverter);
            sut.CalculatePath(new Vector2Int(0, 0), new Vector2Int(0, 0));

            Assert.DoesNotThrow(() => sut.UpdatePosition(2, 3));
        }
    }
}