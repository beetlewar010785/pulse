using System;
using System.Collections.Generic;
using System.Linq;
using PulseTD.Core.Map;
using UnityEngine;

namespace PulseTD.Core.Path;

public class AStarPathFinder : IPathFinder
{
    private class AStarPathNode
    {
        public Vector2Int Point { get; }

        public AStarPathNode? Previous { get; set; }

        public int Cost { get; set; }

        public AStarPathNode(Vector2Int point)
        {
            Point = point;
        }

        public override string ToString()
        {
            return $"{Point} (Cost: {Cost})";
        }
    }

    private readonly ILogicalMap _logicalMap;

    public AStarPathFinder(ILogicalMap logicalMap)
    {
        _logicalMap = logicalMap;
    }

    public Vector2Int[] FindPath(Vector2Int start, Vector2Int end)
    {
        var startNode = new AStarPathNode(start)
        {
            Cost = 0
        };

        var reachableNodes = new Dictionary<Vector2Int, AStarPathNode>
        {
            { start, startNode }
        };

        var exploredNodes = new Dictionary<Vector2Int, AStarPathNode>();

        while (reachableNodes.Any())
        {
            var chosenNode = ChooseNode(reachableNodes.Values, end);
            if (chosenNode.Point.Equals(end))
            {
                return BuildBackwardPath(chosenNode)
                    .Reverse()
                    .ToArray();
            }

            reachableNodes.Remove(chosenNode.Point);
            exploredNodes.Add(chosenNode.Point, chosenNode);

            var adjacentPoints = _logicalMap.GetAdjacentPoints(chosenNode.Point);
            foreach (var adj in adjacentPoints)
            {
                if (exploredNodes.ContainsKey(adj))
                {
                    continue;
                }

                if (!reachableNodes.TryGetValue(adj, out var adjNode))
                {
                    adjNode = new AStarPathNode(adj)
                    {
                        Cost = int.MaxValue
                    };
                    reachableNodes.Add(adj, adjNode);
                }

                var adjCost = chosenNode.Cost + 1;
                if (adjCost >= adjNode.Cost)
                {
                    continue;
                }

                adjNode.Previous = chosenNode;
                adjNode.Cost = adjCost;
            }
        }

        return new[] { start };
    }

    private static AStarPathNode ChooseNode(IEnumerable<AStarPathNode> reachableNodes, Vector2Int end)
    {
        var minCost = int.MaxValue;
        AStarPathNode? bestNode = null;

        foreach (var reachableNode in reachableNodes)
        {
            var destCost = EstimateCost(reachableNode.Point, end);
            var totalCost = reachableNode.Cost + destCost;

            if (minCost <= totalCost) continue;

            minCost = totalCost;
            bestNode = reachableNode;
        }

        return bestNode ?? throw new Exception("No path found");
    }

    private static int EstimateCost(Vector2Int start, Vector2Int end)
    {
        return Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y);
    }

    private static IEnumerable<Vector2Int> BuildBackwardPath(AStarPathNode node)
    {
        var cur = node;
        while (cur != null)
        {
            yield return cur.Point;
            cur = cur.Previous;
        }
    }
}