def get_loading_bar(percentage: int):

    loading_bar = []
    x = percentage // 10
    y = (100 - percentage) // 10
    z = "[" + x * "%" + y * "." + "]"
    loading_bar.append(z)

    if x == 10:
        loading_bar.insert(0, "100% Complete!")
    else:
        loading_bar.insert(0, f"{percentage}%")
        loading_bar.append("Still loading...")

    return loading_bar


percentage = int(input())

loading_bar = get_loading_bar(percentage)

if percentage < 100:
    percentage_as_string = loading_bar[0]
    bar = loading_bar[1]
    message = loading_bar[2]

    print(f"{percentage_as_string} {bar}\n{message}")

else:
    message = loading_bar[0]
    bar = loading_bar[1]

    print(f"{message}\n{bar}")

