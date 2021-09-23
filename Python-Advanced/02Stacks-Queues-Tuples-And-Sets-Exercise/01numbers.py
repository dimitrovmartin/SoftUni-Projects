first_set = set([int(x) for x in input().split()])
second_set = set([int(x) for x in input().split()])

n = int(input())

for _ in range(n):
    command, sequence, *values = input().split()

    if command == "Add":
        set_to_add = set([int(x) for x in values])
        if sequence == "First":
            first_set = first_set.union(set_to_add)
        if sequence == "Second":
            second_set = second_set.union(set_to_add)
    elif command == "Remove":
        set_to_remove = set([int(x) for x in values])
        if sequence == "First":
            first_set = first_set.difference(set_to_remove)
        if sequence == "Second":
            second_set = second_set.difference(set_to_remove)
    elif command == "Check":
        if first_set.issubset(second_set) or second_set.issubset(first_set):
            print(True)
        else:
            print(False)

first_set = sorted(first_set)
second_set = sorted(second_set)

print(*first_set, sep=', ')
print(*second_set, sep=', ')