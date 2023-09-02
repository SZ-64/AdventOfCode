import Utils
import math
from Classes.Cell import Cell


# Find local mins
def part_one():
    grid = []
    height_map = Utils.read_file_as_lines("../Input/9-12-21.txt")

    line = 0
    for row in range(len(height_map)):
        grid.append([])
        for col in range(len(height_map[row])):
            grid[line].append(Cell(line, col, int(height_map[row][col])))
        line += 1

    for row in range(len(grid)):
        for col in range(len(grid[row])):
            set_local_min(grid, row, col)
    
    print(sum([col.risk for row in grid for col in row if col.is_local_min]))


# Find basin size
def part_one():
    grid = []
    height_map = Utils.read_file_as_lines("../Input/9-12-21.txt")

    line = 0
    for row in range(len(height_map)):
        grid.append([])
        for col in range(len(height_map[row])):
            grid[line].append(Cell(line, col, int(height_map[row][col])))
        line += 1

    basins = []
    for row in range(len(grid)):
        for col in range(len(grid[row])):
            set_local_min(grid, row, col)
            if grid[row][col].is_local_min:
                basins.append(get_basin_size(grid, row, col))
    
    print(math.prod(sorted(basins)[-3:]))


def set_local_min(grid, row, col):
    top_val = grid[row - 1][col].val if row - 1 >= 0 else 9
    bottom_val = grid[row + 1][col].val if row + 1 < len(grid) else 9
    left_val = grid[row][col - 1].val if col - 1 >= 0 else 9
    right_val = grid[row][col + 1].val if col + 1 < len(grid[row]) else 9

    grid[row][col].is_local_min = \
        top_val > grid[row][col].val and \
        bottom_val > grid[row][col].val and \
        left_val > grid[row][col].val and \
        right_val > grid[row][col].val


def get_basin_size(grid, row, col):
    grid[row][col].visited = True

    top_cell = grid[row - 1][col] if row - 1 >= 0 else Cell(-1, -1, 9, True)
    bottom_cell = grid[row + 1][col] if row + 1 < len(grid) else Cell(-1, -1, 9, True)
    left_cell = grid[row][col - 1] if col - 1 >= 0 else Cell(-1, -1, 9, True)
    right_cell = grid[row][col + 1] if col + 1 < len(grid[row]) else Cell(-1, -1, 9, True)

    size = 1

    if not top_cell.visited and not top_cell.val == 9:
        size += get_basin_size(grid, top_cell.row, top_cell.col)
    if not bottom_cell.visited and not bottom_cell.val == 9:
        size += get_basin_size(grid, bottom_cell.row, bottom_cell.col)
    if not left_cell.visited and not left_cell.val == 9:
        size += get_basin_size(grid, left_cell.row, left_cell.col)
    if not right_cell.visited and not right_cell.val == 9:
        size += get_basin_size(grid, right_cell.row, right_cell.col)
    
    return size


# Seven segment displays
def part_two():
    pass
        

def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
