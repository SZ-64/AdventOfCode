import Utils


# Calculate the gamma and epsilon values
def part_one(report):
    epsilon, gamma = '', ''
    ones, zeros = [], []

    for n in range(0, len(report[0])):
        ones.append(0)
        zeros.append(0)

    for bin_string in report:
        index = 0
        for char in bin_string:
            if char == '1':
                ones[index] += 1
            else:  # char == 0
                zeros[index] += 1
            index += 1

    for n in range(0, len(report[0])):
        if ones[n] > zeros[n] or ones[n] == zeros[n]:
            gamma += '1'
            epsilon += '0'
        else:
            gamma += '0'
            epsilon += '1'

    return gamma, epsilon


# Process commands calculating submarine aim
def part_two():
    oxy = Utils.read_file_as_lines("../Input/3-12-21.txt")
    co2 = Utils.read_file_as_lines("../Input/3-12-21.txt")

    # There is probably a better way
    for bit in range(0, len(oxy[0])):
        if len(oxy) > 1:
            gamma, epsilon = part_one(oxy)
            oxy = [x for x in oxy if x[bit] == gamma[bit]]
        if len(co2) > 1:
            gamma, epsilon = part_one(co2)
            co2 = [x for x in co2 if x[bit] == epsilon[bit]]

    return oxy, co2


def main():
    report = Utils.read_file_as_lines("../Input/3-12-21.txt")
    gamma, epsilon = part_one(report)
    print(int(gamma, 2) * int(epsilon, 2))

    oxy, co2 = part_two()
    print(int(oxy[0], 2) * int(co2[0], 2))


if __name__ == '__main__':
    main()
