n = int(input())

best_snowball_snow = 0
best_snowball_time = 0
best_snowball_quality = 0
best_snowball_value = 0

for i in range(n):
    snowball_snow = int(input())
    snowball_time = int(input())
    snowball_quality = int(input())

    snowball_value = (snowball_snow // snowball_time) ** snowball_quality

    if snowball_value > best_snowball_value:
        best_snowball_snow = snowball_snow
        best_snowball_time = snowball_time
        best_snowball_quality = snowball_quality
        best_snowball_value = snowball_value

print(f"{best_snowball_snow} : {best_snowball_time} = {best_snowball_value} ({best_snowball_quality})")