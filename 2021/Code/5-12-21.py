import Utils
from Classes.Point import Point


# Count overlapping vertical and horizontal lines
def part_one(use_diagonal=False):
    lines = Utils.read_file_as_lines("../Input/5-12-21.txt")
    grid = []

    for x in range(0, 1000):
        grid.append([])
        for y in range(0, 1000):
            grid[x].append(Point(x, y))

    for line in lines:
        points = line_to_points(line, use_diagonal)
        for point in points:
            grid[point.x][point.y].add_vent()

    flat_grid = [item for sublist in grid for item in sublist]
    results = list(filter(lambda p: p.vent_count > 1, flat_grid))
    print(len(results))


# Process commands calculating submarine aim
def part_two():
    part_one(True)


def line_to_points(line, use_diagonal=False):
    points = []
    tokens = line.split(' ')
    p1, p2 = tokens[0].split(','), tokens[2].split(',')
    start = Point(int(p1[0]), int(p1[1]))
    end = Point(int(p2[0]), int(p2[1]))

    if use_diagonal or start.x == end.x or start.y == end.y:
        rise = end.y - start.y
        run = end.x - start.x
        if use_diagonal and rise == 0 and run == 0:
            points.append(Point(end.x, end.y))
        elif use_diagonal and not rise == 0 and not run == 0:
            while not start.y == end.y and not start.x == end.x:
                points.append(Point(start.x, start.y))
                if not start.x == end.x:
                    start.x += (1 if run > 0 else -1)
                if not start.y == end.y:
                    start.y += (1 if rise > 0 else -1)
            points.append(Point(end.x, end.y))
        elif not rise == 0:
            while not start.y == end.y:
                points.append(Point(start.x, start.y))
                start.y += (1 if rise > 0 else -1)
            points.append(Point(end.x, end.y))
        elif not run == 0:
            while not start.x == end.x:
                points.append(Point(start.x, start.y))
                start.x += (1 if run > 0 else -1)
            points.append(Point(end.x, end.y))

    return points


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
