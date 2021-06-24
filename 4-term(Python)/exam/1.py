def c(n, k):
    cur = []

    def get_c(count):
        if len(cur) == n:
            yield cur
            return

        if n - len(cur) > k - count:
            cur.append(0)
            yield from get_c(count)
            cur.pop()

        if count < k:
            cur.append(1)
            yield from get_c(count + 1)
            cur.pop()

    yield from get_c(0)


for i in c(5, 2):
    print(i)
