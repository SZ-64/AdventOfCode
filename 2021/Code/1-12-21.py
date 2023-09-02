import Utils


# Count the number of times the depth increases
def part_one():
    heights = Utils.read_file_as_ints("../Input/1-12-21.txt")
    count = len([x for x in range(1, len(heights)) if heights[x] > heights[x-1]])
    print(count)


# Count the number of times the 3 digit sliding window increases
def part_two():
    heights = Utils.read_file_as_ints("../Input/1-12-21.txt")
    count = len([
        x
        for x
        in range(3, len(heights))
        if heights[x] + heights[x-1] + heights[x-2] > heights[x-1] + heights[x-2] + heights[x-3]
    ])
    print(count)


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
