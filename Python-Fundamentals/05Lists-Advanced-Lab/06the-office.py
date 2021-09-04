employees_happiness = [int(happiness) for happiness in input().split()]
factor = int(input())
message = ""

employees_happiness = [happiness * factor for happiness in employees_happiness]

threshold = sum(employees_happiness) / len(employees_happiness)

happy_employees = [happiness for happiness in employees_happiness if happiness >= threshold]

happy_count = len(happy_employees)
total_count = len(employees_happiness)

if happy_count >= total_count / 2:
    message = "Employees are happy!"
else:
    message = "Employees are not happy!"

print(f"Score: {happy_count}/{total_count}. {message}")

