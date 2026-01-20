using Microsoft.Xna.Framework;

namespace monogame_pathfinding;

public class Grid
{
    public int Width { get; }
    public int Height { get; }
    public bool[,] Walkable { get; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        Walkable = new bool[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Walkable[x, y] = true;
            }
        }
    }

    public bool InBounds(Point p) => p.X >= 0 && p.Y >= 0 && p.X < Width && p.Y < Height;

    public void Toggle(Point p)
    {
        if (InBounds(p))
        {
            Walkable[p.X, p.Y] = !Walkable[p.X, p.Y];
        }
    }

    public void ClearObstacles()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Walkable[x, y] = true;
            }
        }
    }
}