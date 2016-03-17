class Multiset:

    # Constructor for multiset
    def __init__(self):
        self.multiset = {}
        self.num = 0
    
    # Adds a single instance of v to the multiset
    def add(self, v):
        if v in self.multiset:
            self.multiset[v] += 1
        else:
            self.multiset[v] = 1
        self.num += 1

    # Removes a single instance of v to the multiset. If the
    # value v is not a member of the multiset, no action is performed.
    def remove(self, v):
        if v in self.multiset:
            if self.multiset[v] == 1:
                self.multiset.pop(v)
            else:
                self.multiset[v] -= 1
            self.num -= 1
        
    # Returns the number of copies of the value v are present
    # in the multiset.
    def count(self, v):
        if v in self.multiset:
            return self.multiset[v]
        else:
            return 0

    # Returns the total number of items in the multiset.
    def size(self):
        return self.num

    # For debugging
    def __str__(self):
        return "Multiset: " + str(self.multiset)

if __name__ == "__main__":
    intMS = Multiset()
    intMS.add(3)
    intMS.add(3)
    intMS.add(4)
    intMS.add(3)
    intMS.add(4)
    intMS.add(7)
    print('**********')
    print('Size: ' + str(intMS.size()))
    print(str(intMS))
    for m in range(10):
        print(str(m) + ':  ' + str(intMS.count(m)))
    intMS.remove(3)
    intMS.remove(3)
    intMS.remove(3)
    intMS.remove(3)
    intMS.remove(3)
    print('**********')
    print('Size: ' + str(intMS.size()))
    for m in range(10):
        print(str(m) + ':  ' + str(intMS.count(m)))

    strMS = Multiset()
    strMS.add('cat')
    strMS.add('dog')
    strMS.add('walrus')
    strMS.add('cat')
    strMS.add('lemur')
    strMS.add('walrus')
    print('**********')
    print('Size:' + str(strMS.size()))
    for s in range(10):
        print(str(s) + ': ' + str(strMS.count(s)))
    strMS.remove('cat')
    strMS.remove('cat')
    strMS.remove('cat')
    strMS.remove('cat')
    print('**********')
    print('Size: ' + str(strMS.size()))
    for s in range(10):
        print(str(s) + ': ' + str(strMS.count(s)))
        
        
