numbers = [int(number) for number in input().split(", ")]

positive_numbers = [str(number) for number in numbers if number >= 0]
negative_numbers = [str(number) for number in numbers if number < 0]
even_numbers = [str(number) for number in numbers if number % 2 == 0]
odd_numbers = [str(number) for number in numbers if not number % 2 == 0]

print("Positive: " + ", ".join(positive_numbers))
print("Negative: " + ", ".join(negative_numbers))
print("Even: " + ", ".join(even_numbers))
print("Odd: " + ", ".join(odd_numbers))

