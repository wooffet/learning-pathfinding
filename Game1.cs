using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_pathfinding;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _spriteFont;

    private const int TileSize = 32;
    private const int GridWidth = 25;
    private const int GridHeight = 18;

    private Texture2D _pixel;

    private Grid _grid;
    private bool _showGridLines = true;

    private MouseState _prevMouseState;
    private KeyboardState _prevKeyboardState;

    private Point _start = new(2, 2);
    private Point _goal = new(15, 10);

    private List<Point> _path = [];
    private IPathfinder _pathfinder = new A4Pathfinder();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = TileSize * GridWidth;
        _graphics.PreferredBackBufferHeight = TileSize * GridHeight;
        _graphics.ApplyChanges();

        _grid = new Grid(GridWidth, GridHeight);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _spriteFont = Content.Load<SpriteFont>("DefaultFont");

        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData([Color.White]);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var mouseState = Mouse.GetState();
        var keyboardState = Keyboard.GetState();

        var cell = ScreenToGrid(mouseState.Position);

        if (mouseState.LeftButton == ButtonState.Pressed
        && _prevMouseState.LeftButton == ButtonState.Released)
        {
            _grid.Toggle(cell);
        }

        if (mouseState.RightButton == ButtonState.Pressed
        && _prevMouseState.RightButton == ButtonState.Released)
        {
            if (_grid.InBounds(cell) && _grid.Walkable[cell.X,cell.Y])
            {
                _goal = cell;
            }
        }
        
        if (mouseState.MiddleButton == ButtonState.Pressed
        && _prevMouseState.MiddleButton == ButtonState.Released)
        {
            if (_grid.InBounds(cell) && _grid.Walkable[cell.X,cell.Y])
            {
                _start = cell;
            }
        }

        _prevMouseState = mouseState;

        if (keyboardState.IsKeyDown(Keys.C))
        {
            _grid.ClearObstacles();
        }

        if (keyboardState.IsKeyDown(Keys.G) && _prevKeyboardState.IsKeyUp(Keys.G))
        {
            _showGridLines = !_showGridLines;
        }

        _prevKeyboardState = keyboardState;

        _path = _pathfinder.FindPath(_grid, _start, _goal);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        for (int x = 0; x < _grid.Width; x++)
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                var cell = new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize);
                var cellColor = _grid.Walkable[x, y] ? Color.LightGray : Color.Black;

                // Fill
                _spriteBatch.Draw(_pixel, cell, cellColor);

                // Grid lines
                if (_showGridLines)
                {
                    _spriteBatch.Draw(_pixel, new Rectangle(cell.X, cell.Y, cell.Width, 1), Color.DarkSlateGray);
                    _spriteBatch.Draw(_pixel, new Rectangle(cell.X, cell.Y, 1, cell.Height), Color.DarkSlateGray);
                }
            }
        }

        foreach (var p in _path)
        {
            var rect = new Rectangle(
                p.X * TileSize + 6,
                p.Y * TileSize + 6,
                TileSize - 12,
                TileSize - 12);

            _spriteBatch.Draw(_pixel, rect, Color.CornflowerBlue);
        }

        DrawMarker(_start, Color.LightGreen);
        DrawMarker(_goal, Color.OrangeRed);

        _spriteBatch.DrawString(_spriteFont,
            "LMB: toggle obstacle | RMB: goal | MMB: start | C: clear | G: grid",
            new Vector2(10, 10),
            Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private static Point ScreenToGrid(Point screen) => new(screen.X / TileSize, screen.Y / TileSize);

    private void DrawMarker(Point cell, Color color)
    {
        var rect = new Rectangle(
            cell.X * TileSize + 2,
            cell.Y * TileSize + 2,
            TileSize - 4,
            TileSize - 4);


        _spriteBatch.Draw(_pixel, rect, color);
    }
}
