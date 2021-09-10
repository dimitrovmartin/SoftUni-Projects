def print_expressions(numbers, result=0, expression=''):
    if not numbers:
        print(f'{expression}={result}')
        return
    print_expressions(numbers[1:], result + numbers[0], f'{expression}+{numbers[0]}')
    print_expressions(numbers[1:], result - numbers[0], f'{expression}-{numbers[0]}')


numbers = [int(x) for x in input().split(', ')]

print_expressions(numbers)