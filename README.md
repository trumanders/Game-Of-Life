# Game-Of-Life

Conway's Game of Life rules:

The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of
square cells, each of which is in one of two possible states, live or dead
(or populated and unpopulated, respectively). Every cell interacts with its eight
neighbours, which are the cells that are horizontally, vertically, or diagonally
adjacent. At each step in time, the following transitions occur:

1. Any live cell with two or three live neighbours survives.
2. Any dead cell with three live neighbours becomes a live cell.
3. All other live cells die in the next generation. Similarly, all other dead cells stay dead.

The initial pattern constitutes the seed of the system. The first generation is created by applying
the above rules simultaneously to every cell in the seed, live or dead; births and deaths occur simultaneously,
and the discrete moment at which this happens is sometimes called a tick.[nb 1] Each generation is a pure
function of the preceding one. The rules continue to be applied repeatedly to create further generations.
