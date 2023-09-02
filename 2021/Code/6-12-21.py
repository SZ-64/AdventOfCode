import Utils
import threading
from Classes.Lanternfish import Lanternfish


# Calculate the number of fish after 80 days
def part_one():
    fishys_after_days(80)


# Calculate the number of fish after 256 days
def part_two():
    fishys_after_days(256)


def fishys_after_days(days):
    fishys = [Lanternfish(x, False) for x in Utils.read_line_as_csv("../Input/6-12-21.txt")]
    day_tick(fishys, 0, days)
    print(len(fishys))


def day_tick(fishys, start, end):
    for i in range(start, end):
        for fishy in fishys:
            if fishy.repro_timer == 0 and not fishy.newborn:
                fishy.repro_timer = 6
                fishys.append(Lanternfish(8, True))
            elif fishy.newborn:
                fishy.newborn = False
            else:
                fishy.repro_timer -= 1


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
