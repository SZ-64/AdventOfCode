import Utils
import statistics


# Check for corrupted lines
def part_one():
    syntax_checker()


# Check for incomplete lines
def part_two():
    syntax_checker()


def syntax_checker():
    index = 0
    currupt = []
    incomplete = []
    bracket_table = {
        '(': ')',
        '[': ']',
        '{': '}',
        '<': '>'
    }
    corrupted_points = {
        ')': 3,
        ']': 57,
        '}': 1197,
        '>': 25137
    }
    incomplete_points = {
        ')': 1,
        ']': 2,
        '}': 3,
        '>': 4
    }

    lines = Utils.read_file_as_lines("../Input/10-12-21.txt")
    for line in lines:
        index += 1
        symbol_stack = []
        currupted = False
        for symbol in line:
            if symbol in bracket_table:
                symbol_stack.append(symbol)
            elif bracket_table[peek(symbol_stack)] == symbol:
                symbol_stack.pop()
            else:
                currupt.append(symbol)
                currupted = True
                print(f"Expected {bracket_table[peek(symbol_stack)]}, but found {symbol} on line {index}")
                break
        
        if not currupted and len(symbol_stack) > 0:
            print(f"Unclosed {peek(symbol_stack)} left in line {index}. Full stack: {symbol_stack}", end=' ')

            line_score = 0
            while len(symbol_stack) > 0:
                line_score *= 5
                line_score += incomplete_points[bracket_table[peek(symbol_stack)]]
                symbol_stack.pop()
            incomplete.append(line_score)
            print(f"Line score: {line_score}")
    
    print(f"Currupted Score: {sum([corrupted_points[x] for x in currupt])}")
    print(f"Missing Score: {statistics.median(incomplete)}")
        

def peek(stack):
    item = stack.pop()
    stack.append(item)
    return item


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
