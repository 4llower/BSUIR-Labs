def unite_intervals(intervals, new_interval):
    left = new_interval[0]
    right = new_interval[1]
    result = []
    intervals = sorted(intervals, key=lambda a: a[0])
    for [cur_l, cur_r] in intervals:
        if cur_r < left or right < cur_l:
            result.append([cur_l, cur_r])
        else:
            if not (left <= cur_l and cur_r <= right):
                left = min(left, cur_l)
                right = max(right, cur_r)

    result.append([left, right])
    return sorted(result, key=lambda a: a[0])


print(unite_intervals([[6, 9], [1, 3]], [2, 5]))
print(unite_intervals([[3, 5], [8, 10], [1, 2], [6, 7], [12, 16]], [4, 8]))
