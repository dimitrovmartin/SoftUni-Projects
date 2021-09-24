rows, cols = [int(x) for x in input().split()]

word = input()
word_index = 0

matrix = []

for row in range(rows):
    matrix.append([None] * cols)

for row in range(rows):
    for col in range(cols):
        col_index = col if row % 2 == 0 else cols - col - 1
        matrix[row][col_index] = word[word_index]
        word_index = (word_index + 1) % len(word)

for row in range(rows):
    for col in range(cols):
        print(matrix[row][col], end='')
    print()
