def stock_availability(*args):
    boxes = args[0]
    command = args[1]

    if command == 'delivery':
        if len(args) >= 3:
            orders = args[2:]

            for order in orders:
                boxes.append(order)
    elif command == 'sell':
        if len(args) >= 3:
            if len(args) == 3:
                arg = args[2]

                if isinstance(arg, int):
                    for _ in range(arg):
                        boxes.pop(0)
                else:
                    while arg in boxes:
                        boxes.remove(arg)
            else:
                orders = args[2:]

                for order in orders:
                    while order in boxes:
                        boxes.remove(order)
        else:
            boxes.pop(0)

    return boxes


print(stock_availability(["choco", "vanilla", "banana"], "delivery", "caramel", "berry"))
print(stock_availability(["chocolate", "vanilla", "banana"], "delivery", "cookie", "banana"))
print(stock_availability(["chocolate", "vanilla", "banana"], "sell"))
print(stock_availability(["chocolate", "vanilla", "banana"], "sell", 3))
print(stock_availability(["chocolate", "chocolate", "banana"], "sell", "chocolate"))
print(stock_availability(["cookie", "chocolate", "banana"], "sell", "chocolate"))
print(stock_availability(["chocolate", "vanilla", "banana"], "sell", "cookie"))
