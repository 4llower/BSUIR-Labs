def merge_sort(arr):

    def deep_merge(left, right):

        if left == right:
            return [arr[left]]

        mid = (left + right) // 2
        arr1 = deep_merge(left, mid)
        arr2 = deep_merge(mid + 1, right)

        l1 = 0
        l2 = 0
        result = []

        while not (l1 == len(arr1) and l2 == len(arr2)):
            if l1 == len(arr1):
                result.append(arr2[l2])
                l2 += 1
                continue

            if l2 == len(arr2):
                result.append(arr1[l1])
                l1 += 1
                continue

            if arr1[l1] < arr2[l2]:
                result.append(arr1[l1])
                l1 += 1
            else:
                result.append(arr2[l2])
                l2 += 1

        return result

    return deep_merge(0, len(arr) - 1)


print(merge_sort([5, 2, 6, 2, 1, 9, 4, 2]))
