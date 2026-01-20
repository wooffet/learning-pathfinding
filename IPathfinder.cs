using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace monogame_pathfinding;

public interface IPathfinder
{
    List<Point> FindPath(Grid grid, Point start, Point goal);
}