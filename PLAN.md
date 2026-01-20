# MonoGame Pathfinding Plan

## Step 1 — Verify project runs (blank window)
- [x] Build and run the project
- [x] Confirm a blank window opens
- [x] Confirm Esc exits cleanly

## Step 2 — Render a grid (visual only)
- [x] Create a 1×1 pixel texture for drawing
- [x] Define `TileSize`, `GridWidth`, `GridHeight`
- [x] Draw grid cells (filled or outlined)

## Step 3 — Add grid data model
- [x] Create `Grid` class with `bool[,] Walkable`
- [x] Initialize all tiles as walkable
- [x] Ensure grid model matches rendered size

## Step 4 — Toggle obstacles with mouse
- [x] Convert mouse position to grid coordinates
- [x] On left click (single click), toggle `Walkable`
- [x] Render blocked cells in a distinct color

## Step 5 — Add start/goal markers
- [x] Add `Point Start`, `Point Goal`
- [x] Right click sets Goal, middle click sets Start
- [x] Render Start/Goal with unique colors

## Step 6 — Add A* pathfinding (logic only)
- [x] Implement A* with Manhattan heuristic
- [x] Return a `List<Point>` path

## Step 7 — Visualize path
- [x] Draw the path tiles with a highlight color
- [x] Update path each frame (or on change)

## Step 8 — Quality-of-life polish
- [x] Add key to clear obstacles
- [x] Add key to toggle grid lines
- [x] Add on-screen legend (optional)

## Extensions to add
- [ ] Diagonal (A*) movement
- [ ] Another pathfinding algorithm
- [ ] Visualising the open/closed sets
- [ ] Animated visualisations with start/pause key
- [ ] Different tile types (to support weighted tiles)
- [ ] Weighted tiles
- [ ] Multiple grid floors connected via stair tiles
- [ ] Teleportation tiles with a single destination
- [ ] Algorithm aware of teleport/stair tiles during pathfinding
