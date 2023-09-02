import Utils


# Comments
def part_one(cycles):
    lines = Utils.read_file_as_lines("../Input/12-12-21.txt")
    generator = Utils.seek_until_blank_line(lines)
    polymer = [x for x in next(generator)[0]]
    rules = {}
    rules_list = [
        list(filter(lambda x: x != '->', x.split(' ')))
        for x in next(generator)
    ]

    for r in rules_list:
        rules[r[0]] = r[1]

    print(rules)
    print(polymer)

    for i in range(cycles):
        do_substitution(polymer, rules)

    result_set = []
    polymer_set = set(polymer)
    for p in polymer_set:
        result_set.append(sum([1 for x in polymer if x == p]))

    print(max(result_set) - min(result_set))


# Comments
def part_two():
    part_one(20)
        

def do_substitution(polymer, rules):
    for i in range(len(polymer) - 1, 0, -1):
        if polymer[i - 1] + polymer[i] in rules:
            polymer.insert(i, rules[polymer[i - 1] + polymer[i]])


def main():
    part_one(10)
    part_two()


if __name__ == '__main__':
    main()
