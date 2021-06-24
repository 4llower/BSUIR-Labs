class Node:
    def __init__(self, value=0, next=None):
        self.value = value
        self.next = next


def delete_duplicates(node):
    last = node
    current = node.next
    while current is not None:
        if current.value == last.value:
            last.next = current.next
            current = current.next
        else:
            last = current
            current = current.next
    return node


elem = Node(5)
elem = Node(4, elem)
elem = Node(1, elem)
elem = Node(1, elem)
elem = Node(2, elem)
elem = Node(1, elem)
head = Node(1, elem)
result = delete_duplicates(head)
print(result)  # set breakpoint here
