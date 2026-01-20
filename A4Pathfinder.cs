using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace monogame_pathfinding;

public class A4Pathfinder : IPathfinder
{
    public List<Point> FindPath(Grid grid, Point start, Point goal)
    {
        var open = new PriorityQueue<Point, int>();
        open.Enqueue(start, 0);

        var cameFrom = new Dictionary<Point, Point>();

        var gScore = new Dictionary<Point, int>
        {
            [start] = 0
        };

        while (open.Count > 0)
        {
            var current = open.Dequeue();

            if (current == goal)
            {
                break;
            }

            foreach (var next in PathfinderHelpers.Neighbours4(current))
            {
                if (!grid.InBounds(next) || !grid.Walkable[next.X, next.Y])
                {
                    continue;
                }

                int newG = gScore[current] + 1;

                if (!gScore.TryGetValue(next, out int oldG) || newG < oldG)
                {
                    gScore[next] = newG;

                    // f is the queue priority of this neighbour
                    int f = newG + PathfinderHelpers.Heuristic(next, goal);

                    open.Enqueue(next, f);

                    // record how we got to the 'next' tile
                    cameFrom[next] = current;
                }
            }
        }

        return PathfinderHelpers.ReconstructPath(cameFrom, start, goal);
    }
}