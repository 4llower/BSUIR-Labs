class Iterator:
    def __init__(self, n, k):
        self.current = 0
        self.max = self.get_acc(n, k)
        self.n = n
        self.k = k

    def __iter__(self):
        return self

    def __next__(self):
        self.current += 1
        if self.current == self.max:
            raise StopIteration
        else:
            return self.generate_acc(self.current)

    @staticmethod
    def get_acc(n, k):
        result = 1
        for i in range(k):
            result *= n - i
        return result

    def generate_acc(self, nth):
        has = [False for _i in range(self.n)]
        result = []

        for i in range(0, self.k):
            for j in range(self.n):
                if has[j] is False:
                    acc = self.get_acc(self.n - i - 1, self.k - i - 1)
                    if nth >= acc:
                        nth -= acc
                    else:
                        has[j] = True
                        result.append(j + 1)
                        break

        return result


iterator = Iterator(5, 2)

for current in iterator:
    print(current)
