import Utils
from Classes.Octopus import Octopus


# Comments
def part_one(cycles):
    octopuses = []
    energies = Utils.read_file_as_lines("../Input/11-12-21.txt")

    for row in range(len(energies)):
        octopuses.append([])
        for col in range(len(energies[row])):
            octopuses[row].append(Octopus(row, col, int(energies[row][col])))

    for i in range(cycles):
        do_tick(octopuses)
        if len(list(filter(lambda x: x == 0, [col.energy for row in octopuses for col in row]))) == (len(octopuses)*len(octopuses)):
            print(F"All flashed! {i} {[col.energy for row in octopuses for col in row]}")

    print(sum([col.total_flashes for row in octopuses for col in row]))


# Comments
def part_two():
    part_one(1000)


def do_tick(octopuses):
    for row in range(len(octopuses)):
        for col in range(len(octopuses[row])):
            energize(octopuses, row, col)

    for row in range(len(octopuses)):
        for col in range(len(octopuses[row])):
            if octopuses[row][col].has_flashed_this_tick:
                octopuses[row][col].energy = 0
                octopuses[row][col].total_flashes += 1
                octopuses[row][col].has_flashed_this_tick = False


def energize(octopuses, row, col):
    octopuses[row][col].energy += 1

    if octopuses[row][col].energy <= 9 or octopuses[row][col].has_flashed_this_tick:
        return

    size = len(octopuses)

    octopuses[row][col].has_flashed_this_tick = True

    can_search_up = (row - 1 >= 0)
    can_search_down = (row + 1 < size)
    can_search_left = (col - 1 >= 0)
    can_search_right = (col + 1 < size)

    if can_search_up and can_search_left:
        energize(octopuses, row - 1, col - 1)
    if can_search_up:
        energize(octopuses, row - 1, col)
    if can_search_up and can_search_right:
        energize(octopuses, row - 1, col + 1)

    if can_search_left:
        energize(octopuses, row, col - 1)
    if can_search_right:
        energize(octopuses, row, col + 1)

    if can_search_down and can_search_left:
        energize(octopuses, row + 1, col - 1)
    if can_search_down:
        energize(octopuses, row + 1, col)
    if can_search_down and can_search_right:
        energize(octopuses, row + 1, col + 1)


def main():
    part_one(100)
    part_two()


if __name__ == '__main__':
    main()
