import Utils


# Determine which board is the winning board
def part_one():
    lines = Utils.read_file_as_lines("../Input/4-12-21.txt")
    board_generator = Utils.seek_until_blank_line(lines)
    numbers = [int(y) for y in [x.split(',') for x in next(board_generator)][0]]
    print(numbers)

    boards = []
    winners = []
    for count in range(0, 3):
        next_board = [
            [int(x) for x in list(filter(None, x.split(' ')))]
            for x
            in next(board_generator)
        ]
        boards.append(next_board)
        print(next_board)

    for board in boards:
        winners = win_check(board, numbers)


# Process commands calculating submarine aim
def part_two():
    pass


# Check each board's verticals and horizontals for five matches
def win_check(board, numbers):
    winner = True
    for n in len(numbers):
        for i in range(0, 5):
            winner = True
            for j in range(0, 5):
                if board[i][j] != numbers[n]:
                    winner = False
                    break
    return


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
