# Sudoku Solver – Backtracking (Brute-Force) in Unity

A minimal **Sudoku solver** implemented in **Unity (C#)**.  
The application takes a partially filled 9×9 board and computes a valid completion using a depth-first search **backtracking** algorithm (a brute-force approach with validity checks).

---

## Overview

Sudoku is a logic puzzle where a 9×9 grid must be filled so that each row, column, and 3×3 subgrid contains the digits 1–9 exactly once.  
This project demonstrates a straightforward programmatic approach to solving such puzzles by recursively trying candidate digits and backtracking on conflicts.

---

## Application Description

- **9×9 grid UI** with clear, high-contrast rendering.
- **Solve** button runs the backtracking solver on the current board.
- **Reset** button restores the board to its initial state.
- Visual feedback shows the solved grid once a solution is found.

> The solver assumes the input puzzle is valid and has at least one solution.

---

## Algorithm

**Backtracking (DFS)**
1. Locate the next empty cell.
2. Iterate candidate digits 1–9.
3. For each digit, check row/column/box constraints.
4. If valid, place the digit and recurse to the next empty cell.
5. If a dead end is reached, undo the placement and try the next digit.
6. Terminate when all cells are filled (solution found) or when all candidates are exhausted (no solution).

This method is simple to implement and guarantees a solution for any solvable puzzle, though runtime depends on puzzle difficulty.

---

## Features

- Deterministic, constraint-checked brute-force solver.
- Clear separation of UI rendering and solver logic.
- Fast enough for typical human-grade puzzles.
- Defensive validation for row, column, and 3×3 subgrid rules.

---

## Technical Summary

- **Engine:** Unity
- **Language:** C#
- **Core Components:**
  - Grid rendering and input layer
  - Board model (9×9 integer matrix)
  - Backtracking solver with constraint checks

---

## Usage

1. Launch the application.
2. Load or prepare the puzzle on the grid (prefilled example included).
3. Click **Solve** to compute the solution.
4. Click **Reset** to restore the initial puzzle.

---

## Screenshots

| Initial Puzzle | Solved Board |
| --- | --- |
| ![Initial](<img width="597" height="830" alt="image" src="https://github.com/user-attachments/assets/dee5f799-59a5-4dbc-8cea-ba5ea5b935a4" />
) | ![Solved](<img width="596" height="832" alt="image" src="https://github.com/user-attachments/assets/f4198f95-9a87-4c21-84d4-6f97fe456731" />
) |

---

## Limitations and Notes

- The solver uses pure backtracking; it does not implement human-style heuristics or advanced pruning.
- For pathological inputs or multiple-solution boards, runtime can increase.
- Input validation assumes a standard 9×9 Sudoku with digits 1–9.

---

## Possible Extensions

- Add heuristics (e.g., most-constrained cell, candidate ordering).
- Add pencil marks and human-strategy steps (singles, hidden singles, pairs).
- Detect and report multiple solutions or unsatisfiable boards.
- Import/export puzzles from text or image OCR.
- Timing metrics and step-by-step visualization.

---

## License

This project is provided for educational and non-commercial use.
