# 80/100

n = int(input())
guests = set()
confirmed_guests = set()

for _ in range(n):
    guests.add(input())

declined_guest = input()

while not declined_guest == "END":
    confirmed_guests.add(declined_guest)
    declined_guest = input()

arrived_guests = guests.difference(confirmed_guests)
arrived_guests = set(sorted(arrived_guests))

print(len(arrived_guests))
[print(guest) for guest in arrived_guests if guest[0].isdigit()]
[print(guest) for guest in arrived_guests if not guest[0].isdigit()]