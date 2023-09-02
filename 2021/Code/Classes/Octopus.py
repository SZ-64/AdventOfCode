class Octopus:

    def __init__(self, r, c, e):
        self.row = r
        self.col = c
        self.energy = e
        self.has_flashed_this_tick = False
        self.total_flashes = 0
