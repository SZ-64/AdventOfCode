import Utils


# Process commands in order to find the final position
def part_one():
    pos = 0
    depth = 0
    commands = Utils.read_file_as_lines("../Input/2-12-21.txt")
    for command in commands:
        tokens = command.split(' ')
        val = int(tokens[1])
        if tokens[0] == 'forward':  # Python y u no switch statements
            pos += val
        elif tokens[0] == 'down':
            depth += val
        else:  # if tokens[0] == 'up':
            depth -= val
    print(pos * depth)


# Process commands calculating submarine aim
def part_two():
    aim = 0
    pos = 0
    depth = 0
    commands = Utils.read_file_as_lines("../Input/2-12-21.txt")
    for command in commands:
        tokens = command.split(' ')
        val = int(tokens[1])
        if tokens[0] == 'forward':  # Python y u no switch statements
            pos += val
            depth += (aim * val)
        elif tokens[0] == 'down':
            aim += val
        else:  # if tokens[0] == 'up':
            aim -= val
    print(pos * depth)


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
