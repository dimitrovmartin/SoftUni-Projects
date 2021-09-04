def is_perfect_number(number : int):
    sum = 0

    for i in range(1, number):
        if number % i == 0:
            sum += i

    if number == sum:
        return True
    else:
        return False


number = int(input())

if is_perfect_number(number):
    print("We have a perfect number!")
else:
    print("It's not so perfect.")

