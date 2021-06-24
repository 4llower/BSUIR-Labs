def a(n, k):
    cur = []
    has = [False for _i in range(n)]

    def get_a():
        if len(cur) == k:
            yield cur
            return

        for elem in range(n):
            if has[elem] is False:
                has[elem] = True
                cur.append(elem + 1)
                yield from get_a()
                cur.pop()
                has[elem] = False

    yield from get_a()


for i in a(5, 3):
    print(i)
