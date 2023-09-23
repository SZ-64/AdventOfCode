import Utils


# Crab sub fuel
def part_one():
    distances = Utils.read_line_as_csv("../Input/7-12-21.txt")
    fuel_costs = []

    print(distances)
    for i in range(0, len(distances)):
        local_dist = []
        for j in range(0, len(distances)):
            local_dist.append(abs(distances[j] - i))
        fuel_costs.append(local_dist)

    fuel_sums = [sum(x) for x in fuel_costs]
    print(fuel_costs)
    print(fuel_sums)
    print(f"Min fuel sum {min(fuel_sums)}")


# Crab sub engineering
def part_two():
    distances = Utils.read_line_as_csv("../Input/7-12-21.txt")
    fuel_costs = []

    print(distances)
    for i in range(0, len(distances)):
        local_dist = []
        for j in range(0, len(distances)):
            local_dist.append(0.5 * abs(distances[j] - i) * (abs(distances[j] - i) + 1))
        fuel_costs.append(local_dist)

    fuel_sums = [sum(x) for x in fuel_costs]
    print(fuel_costs)
    print(fuel_sums)
    print(f"Min fuel sum {min(fuel_sums)}")


def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
