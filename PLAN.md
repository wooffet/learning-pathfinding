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

## Extension 1 — Diagonal (A*) movement
### Step 1 — Create the new pathfinder class
- [ ] Add a new class that implements `IPathfinder`
- [ ] Name it to indicate diagonal A* (e.g., `AStarPathfinder`)

### Step 2 — Add diagonal neighbors
- [ ] Define 8-direction neighbor offsets (N, S, E, W, NW, NE, SW, SE)
- [ ] Keep existing grid bounds and walkability checks

### Step 3 — Apply movement costs
- [ ] Use cost = 1 for orthogonal moves
- [ ] Use cost = 1.4142 for diagonal moves

### Step 4 — Update heuristic
- [ ] Implement Octile heuristic in the new pathfinder

### Step 5 — Prevent corner-cutting
- [ ] For a diagonal move, require both adjacent orthogonal tiles to be walkable

### Step 6 — Add algorithm switch button
- [ ] Add an input action (key or on-screen button) to cycle pathfinding algorithms
- [ ] Track the active `IPathfinder` in game state
- [ ] Update the on-screen legend to show the active algorithm

### Step 7 — Wire up and verify
- [ ] Use the active `IPathfinder` selected by the switch in the game loop
- [ ] Ensure the switch cycles between existing A4 and A*
- [ ] Confirm paths use diagonals when optimal
