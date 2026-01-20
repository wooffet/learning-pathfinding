using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace monogame_pathfinding;

public static class PathfinderHelpers
{
    public static IEnumerable<Point> Neighbours4(Point p)
    {
        yield return new Point(p.X + 1, p.Y);
        yield return new Point(p.X - 1, p.Y);
        yield return new Point(p.X, p.Y + 1);
        yield return new Point(p.X, p.Y - 1);
    }

    public static int Heuristic(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    public static List<Point> ReconstructPath(
        Dictionary<Point, Point> cameFrom,
        Point start,
        Point goal)
    {
        var path = new List<Point>();

        // check if goal was never reached
        if (!cameFrom.ContainsKey(goal) && start != goal)
        {
            return path;
        }

        var current = goal;
        path.Add(current);

        while (current != start)
        {
            current = cameFrom[current];
            path.Add(current);
        }

        path.Reverse();
        return path;
    }
}