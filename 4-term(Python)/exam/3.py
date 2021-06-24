def fact(n):
    cur = []
    has = [False for _i in range(n)]

    def get_fact():
        if len(cur) == n:
            yield cur
            return

        for elem in range(n):
            if has[elem] is False:
                has[elem] = True
                cur.append(elem + 1)
                yield from get_fact()
                cur.pop()
                has[elem] = False

    yield from get_fact()


for i in fact(5):
    print(i)
