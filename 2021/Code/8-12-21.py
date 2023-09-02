import Utils


# Unique outputs
def part_one():
    lines = Utils.read_file_as_lines("../Input/8-12-21.txt")
    outputs = [line.split('|')[1].split(' ') for line in lines]
    nums = filter(None, [output for sublist in outputs for output in sublist])
    uniques = list(filter(lambda x: len(x) in [2, 3, 4, 7], nums))
    print(len(uniques))


# Seven segment displays
def part_two():
    segment_table = {
        'abcefg' : 0,
        'cf': 1,
        'acdeg': 2,
        'acdfg': 3,
        'bcdf': 4,
        'abdfg': 5,
        'abdefg': 6,
        'acf': 7,
        'abcdefg': 8,
        'abcdfg': 9
    }
    lines = Utils.read_file_as_lines("../Input/8-12-21.txt")
    total = 0

    # Decode each line seperately
    for line in lines:
        num_keys = {}
        seg_keys = {'a': 'a', 'b': 'b', 'c': 'c', 'd': 'd', 'e': 'e', 'f': 'f', 'g': 'g'}
        groups = line.split('|')
        lookup = list(filter(None, groups[0].split(' ')))
        output = list(filter(None, groups[1].split(' ')))

        # Start with the uniques
        for item in lookup:
            if len(item) == 2:
                num_keys[1] = item
            elif len(item) == 3:
                num_keys[7] = item
            elif len(item) == 4:
                num_keys[4] = item
            elif len(item) == 7:
                num_keys[8] = item
        
        # Set diff 8 and x to find 0, 6, 9 | 2, 3, 5
        eight_mask_1 = [
            x for x in lookup
            if len(set(num_keys[8]).difference(x)) == 1
        ]
        eight_mask_2 = [
            x for x in lookup
            if len(set(num_keys[8]).difference(x)) == 2
        ]
        
        num_keys[6] = [
            x for x in eight_mask_1
            if len(set(num_keys[1]).intersection(set(x))) == 1
        ][0]
        num_keys[9] = [
            x for x in eight_mask_1
            if len(set(x).intersection(set(num_keys[4]))) == 4
        ][0]
        num_keys[0] = [
            x for x in eight_mask_1
            if not x == num_keys[6] and not x == num_keys[9]
        ][0]

        num_keys[3] = [
            x for x in eight_mask_2
            if len(set(num_keys[7]).intersection(set(x))) == 3
        ][0]
        num_keys[5] = [
            x for x in eight_mask_2
            if len(set(num_keys[6]).difference(set(x))) == 1
        ][0]
        num_keys[2] = [
            x for x in eight_mask_2
            if not x == num_keys[3] and not x == num_keys[5]
        ][0]

        # Use more set differences to find the segments
        seg_keys['a'] = set(num_keys[7]).difference(set(num_keys[1])).pop()
        seg_keys['b'] = set(num_keys[0]).difference(set(num_keys[2])).difference(set(num_keys[3])).pop()
        seg_keys['c'] = set(num_keys[4]).difference(set(num_keys[6])).pop()
        seg_keys['d'] = set(num_keys[8]).difference(set(num_keys[0])).pop()
        seg_keys['e'] = set(num_keys[8]).difference(set(num_keys[9])).pop()
        seg_keys['f'] = set(num_keys[1]).difference(set(num_keys[2])).pop()
        seg_keys['g'] = set(num_keys[3]).difference(set(num_keys[4])).difference(set(num_keys[7])).pop()

        # Iterate over output and convert them to numbers
        res = []
        fliped = dict((v,k) for k,v in seg_keys.items())
        for o in output:
            res.append(segment_table["".join(sorted([fliped[x] for x in o]))])
        
        total += int("".join([str(x) for x in res]))
    
    print(total)
        

def main():
    part_one()
    part_two()


if __name__ == '__main__':
    main()
