using System;
using System.Collections.Generic;
using PulseTD.Core.Map;
using UnityEngine;

namespace PulseTD.Core.Path;

public class PathFollower
{
    public Vector2 Position { get; private set; }
    public bool IsEndReached { get; private set; }

    private readonly IWorldToCellConverter _worldToCellConverter;
    private readonly IPathFinder _pathFinder;
    private readonly IWorldPathBuilder _cellToWorldPathBuilder;
    private readonly ISplineBuilder _splineBuilder;

    private IList<Vector2>? _waypoints;
    private int _targetWaypointIndex;

    public PathFollower(
        IWorldToCellConverter worldToCellConverter,
        IPathFinder pathFinder,
        IWorldPathBuilder cellToWorldPathBuilder,
        ISplineBuilder splineBuilder)
    {
        _worldToCellConverter = worldToCellConverter;
        _pathFinder = pathFinder;
        _cellToWorldPathBuilder = cellToWorldPathBuilder;
        _splineBuilder = splineBuilder;
    }

    public void CalculatePath(Vector2 start, Vector2 end)
    {
        var startCell = _worldToCellConverter.Convert(start);
        var endCell = _worldToCellConverter.Convert(end);
        var cellPath = _pathFinder.FindPath(startCell, endCell);
        var worldPath = _cellToWorldPathBuilder.Build(cellPath);

        var waypoints = _splineBuilder.Build(worldPath);
        if (waypoints.Count == 0)
        {
            throw new InvalidOperationException("Path is empty");
        }

        _waypoints = waypoints;
        Position = _waypoints[0];
        _targetWaypointIndex = 1;
        IsEndReached = _targetWaypointIndex >= _waypoints.Count;
    }

    public void UpdatePosition(float deltaTime, float speed)
    {
        if (_waypoints == null)
        {
            throw new InvalidOperationException("Path is not calculated");
        }

        var deltaDistance = deltaTime * speed;

        while (deltaDistance > 0)
        {
            if (IsEndReached)
            {
                break;
            }

            var targetWaypoint = _waypoints[_targetWaypointIndex];
            var distanceToTarget = Vector2.Distance(Position, targetWaypoint);
            Position = Vector2.MoveTowards(Position, targetWaypoint, deltaDistance);
            if (distanceToTarget <= deltaDistance)
            {
                // the target waypoint is reached
                _targetWaypointIndex++;
                IsEndReached = _targetWaypointIndex >= _waypoints.Count;
            }

            deltaDistance -= distanceToTarget;
        }
    }
}