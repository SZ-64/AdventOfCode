# -*- coding: utf-8 -*-


class Node:
    def __init__(self, data, items):
        self.data = data.lstrip()
        self.items = items
        
    def __str__(self):
        node_str = self.data + ": "
        for item in self.items:
            node_str += str(item)
        return node_str
    
    def find(self, data):
        if self.data.strip() == data.strip():
            return self
        else:
            for item in self.items:
                node = item.find(data)
                if node is not None:
                    return node

# Read in the input file and parse each line as data
def read_data():
    f = open("../input/7-12-20.txt", "r")
    return f.read().split('\n')

def part_one():
    forest = []
    for line in read_data():
        rule = line.split("contain")
        forest.append(Node(rule[0], [cond.strip() for cond in rule[1].split(',')]))
    for tree in forest:
        print(tree)

def part_two():
    pass
    
# Compute the number of trees using different slopes
print(part_one())
print(part_two())
