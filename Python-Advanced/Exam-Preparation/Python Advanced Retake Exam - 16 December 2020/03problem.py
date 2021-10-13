def get_magic_triangle(n):
    from math import factorial
    matrix = []
    for i in range(n):
        matrix.append([])
        for j in range(i + 1):
            matrix[i].append(factorial(i) // (factorial(j) * factorial(i - j)))

    return matrix


print(get_magic_triangle(5))
