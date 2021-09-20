n = int(input())

longest_intersection = set()

for _ in range(n):
    first, second = input().split("-")

    first_start, first_end = [int(value) for value in first.split(",")]
    second_start, second_end = [int(value) for value in second.split(",")]

    first_set = set(range(first_start, first_end + 1))
    second_set = set(range(second_start, second_end + 1))

    intersection_set = first_set.intersection(second_set)

    if len(intersection_set) > len(longest_intersection):
        longest_intersection = intersection_set

longest_intersection = [str(value) for value in longest_intersection]

print(f"Longest intersection is [{', '.join(longest_intersection)}] with length {len(longest_intersection)}")
