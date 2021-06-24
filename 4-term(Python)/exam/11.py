from random import randint


def quick_sort(arr):

    def sort(left, right):
        if left >= right:
            return
        mid = arr[randint(left, right)]

        pos_left = left
        pos_right = right

        while pos_left <= pos_right:
            if arr[pos_left] < mid:
                pos_left += 1
                continue

            if arr[pos_right] > mid:
                pos_right -= 1
                continue

            if pos_left >= pos_right:
                break

            arr[pos_left], arr[pos_right] = arr[pos_right], arr[pos_left]

            pos_left += 1
            pos_right -= 1

        sort(left, pos_right)
        sort(pos_right + 1, right)

    sort(0, len(arr) - 1)
    return arr


print(quick_sort([5, 2, 6, 2, 1, 9, 4, 2]))
