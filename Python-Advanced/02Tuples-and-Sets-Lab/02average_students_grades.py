grades_by_students = {}

n = int(input())

for _ in range(n):
    name, grade = input().split()

    if name not in grades_by_students.keys():
        grades_by_students[name] = []

    grades_by_students[name].append(float(grade))

for key, value in grades_by_students.items():
    print(f"{key} -> {' '.join(f'{grade:.2f}' for grade in value)} (avg: {sum(value) / len(value):.2f})")
