class Point:

    def __init__(self, x, y):
        self.x = x
        self.y = y
        self.vent_count = 0

    def add_vent(self):
        self.vent_count += 1
