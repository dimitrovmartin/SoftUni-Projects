numbers = [int(x) for x in input().split()]

negative_numbers = filter(lambda a: a <= 0, numbers)
positive_numbers = filter(lambda a: a > 0, numbers)

negative_numbers_sum = sum(negative_numbers)
positive_numbers_sum = sum(positive_numbers)

print(negative_numbers_sum)
print(positive_numbers_sum)

if abs(negative_numbers_sum) > positive_numbers_sum:
    print("The negatives are stronger than the positives")
else:
    print("The positives are stronger than the negatives")
