# Place Blocks

A block-placement puzzle built in Unity, with timed levels and an endless mode.

Drag pieces onto the board and find a position where every part of the shape fits. Valid placements snap into the grid. Pieces dropped outside the board or over occupied cells return to their starting position.

## Game Modes

### Timed Levels

Fill every cell on the board before the countdown reaches zero.

Completing the board marks the level as finished and stops the timer. Running out of time triggers a failed attempt and reduces the player's remaining lives.

### Endless Mode

Place pieces on a 10 × 10 board and complete rows or columns to clear them.

Cleared cells become available again, and empty piece slots receive randomly selected replacement pieces.

## Interaction

- Drag a piece by any of its active tiles.
- An outline highlights the selected shape.
- Placement checks every active tile before accepting the move.
- Valid pieces animate into their grid positions.
- Invalid placements animate back to their starting positions.
- Completed rows and columns clear with staggered timing.

## Level Setup

Level settings are stored in ScriptableObjects through `LevelData`, including the time limit, completion state and heart cost.

The timer reads the selected level's duration. Level completion and failure are handled separately from dragging and placement.

## Code Layout

Gameplay code is under `Assets/Scripts`.

- `Gameplay/Movable` handles dragging and position animations.
- `Grid System/Piece` validates and places complete shapes.
- `Grid System/BaseGrid` checks board completion and clears rows and columns.
- `Endless Level` manages piece slots and spawning.
- `Level System` contains level data and the countdown timer.
- `Managers` handles game state, level results and scene changes.

The project uses Zenject to connect level and UI dependencies.

## Opening the Project

Open the repository through Unity Hub using **Unity 2021.3.14f1**.

**Built with Unity, C# and Zenject.**
