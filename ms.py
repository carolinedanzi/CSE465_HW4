class Multiset:

    # Constructor for multiset
    def __init__(self):
        self.multiset = {}
        self.count = 0
    
    # Adds a single instance of v to the multiset
    def add(self, v):
        if v in self.multiset:
            self.multiset[v] += 1
        else:
            self.multiset[v] = 1
        self.count += 1

    # Removes a single instance of v to the multiset. If the
    # value v is not a member of the multiset, no action is performed.
    def remove(self, v):
        if v in self.multiset:
            if self.multiset[v] == 1:
                self.multiset.pop(v)
            else:
                self.multiset[v] -= 1
            self.count -= 1
        
    # Returns the number of copies of the value v are present
    # in the multiset.
    def count(self, v):
        if v in self.multiset:
            return self.multiset[v]
        else:
            return 0

    # Returns the total number of items in the multiset.
    def size(self):
        return self.count

    # For debugging
    def __str__(self):
        return "Multiset: " + str(self.multiset)
        
