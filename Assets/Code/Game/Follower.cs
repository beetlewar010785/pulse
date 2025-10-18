using System;
using System.Collections.Generic;
using PulseTD.Core.Path;
using PulseTD.Core.Spline;
using UnityEngine;

namespace PulseTD.Game;

public class Follower
{
    public Vector2 Position { get; private set; }
    public bool IsEndReached { get; private set; }

    private readonly IPathFinder _pathFinder;
    private readonly ICellToWorldPathConverter _cllToWorldPathConverter;
    private readonly IWaypointsToSplineConverter _waypointsToSplineConverter;

    private IList<Vector2>? _waypoints;
    private int _targetWaypointIndex;

    public Follower(
        IPathFinder pathFinder,
        ICellToWorldPathConverter cllToWorldPathConverter,
        IWaypointsToSplineConverter waypointsToSplineConverter)
    {
        _pathFinder = pathFinder;
        _cllToWorldPathConverter = cllToWorldPathConverter;
        _waypointsToSplineConverter = waypointsToSplineConverter;
    }

    public void CalculatePath(Vector2Int start, Vector2Int end)
    {
        var cellPath = _pathFinder.FindPath(start, end);
        var worldPath = _cllToWorldPathConverter.Convert(cellPath);
        var waypoints = _waypointsToSplineConverter.Convert(worldPath);
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

    public void ResetPosition()
    {
        Position = Vector2.zero;
        _targetWaypointIndex = 0;
        IsEndReached = false;
    }
}