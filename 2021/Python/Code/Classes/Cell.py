class Cell:

    def __init__(self, row, col, val, visited=False):
        self.row = row
        self.col = col
        self.val = val
        self.risk = val + 1
        self.is_local_min = False
        self.visited = visited
