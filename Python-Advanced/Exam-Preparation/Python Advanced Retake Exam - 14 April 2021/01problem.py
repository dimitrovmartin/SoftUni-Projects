from collections import deque

orders = deque([int(x) for x in input().split(', ')])
employees = [int(x) for x in input().split(', ')]

total_pizzas = 0

while orders and employees:
    order = orders.popleft()
    employee = employees[-1]

    if order > 10 or order <= 0:
        continue
    if order > employee:
        order -= employee
        orders.appendleft(order)
        total_pizzas += employee
    else:
        total_pizzas += order
    employees.pop()

if not orders:
    print('All orders are successfully completed!')
    print(f'Total pizzas made: {total_pizzas}')
    if employees:
        print(f'Employees: {", ".join([str(employee) for employee in employees])}')
else:
    print('Not all orders are completed.')
    print(f'Orders left: {", ".join(str(order) for order in orders)}')
