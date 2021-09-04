todos = [0] * 10

line = input()

while not line == "End":
    importance, note = line.split("-")
    index = int(importance) - 1

    todos[index] = note

    line = input()

todos = [note for note in todos if not note == 0]

print(todos)
