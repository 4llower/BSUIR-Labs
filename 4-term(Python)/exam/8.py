def get_islands(color, n, m):
    result = 1
    for i in range(n):
        for j in range(m):
            if color[i][j] == 1:
                q = [[i, j]]
                pointer = 0
                result += 1
                while pointer < len(q):
                    [x, y] = q[pointer]
                    pointer += 1

                    if x >= n or x < 0 or y >= m or y < 0:
                        continue

                    if color[x][y] != 1:
                        continue

                    color[x][y] = result
                    q.append([x + 1, y])
                    q.append([x, y - 1])
                    q.append([x - 1, y])
                    q.append([x, y + 1])

    return result - 1


print(get_islands([[1, 0, 0],
                   [1, 0, 1],
                   [0, 0, 1]], 3, 3))