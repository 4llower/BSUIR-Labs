class Node:
    def __init__(self, value=0, next=None):
        self.value = value
        self.next = next


def partition(node, x):
    start_white = None
    start_black = None
    last_black = None
    last_white = None

    current = node

    while current is not None:
        if current.value < x:
            if start_white is None:
                start_white = current
                last_white = current
            else:
                last_white.next = current
                last_white = current
        else:
            if start_black is None:
                start_black = current
                last_black = current
            else:
                last_black.next = current
                last_black = current

        current = current.next

    last_white.next = start_black

    return start_white


elem = Node(1)
elem = Node(1, elem)
elem = Node(2, elem)
elem = Node(1, elem)
elem = Node(4, elem)
elem = Node(5, elem)
head = Node(1, elem)


result = partition(head, 3)
print(result)  # set breakpoint here
