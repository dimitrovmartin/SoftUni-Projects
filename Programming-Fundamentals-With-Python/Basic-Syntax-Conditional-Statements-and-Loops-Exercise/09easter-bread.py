budget = float(input())
flour_kg_price = float(input())

pack_eggs_price = flour_kg_price * 0.75
milk_price = flour_kg_price * 1.25
needed_milk_per_cozonac = 0.25
needed_milk_price = milk_price * needed_milk_per_cozonac

needed_money_per_cozonac = flour_kg_price + pack_eggs_price + needed_milk_price

counter = 1
is_money_enough = True

cozonacs_count = 0
eggs_count = 0

while is_money_enough:
   if budget - needed_money_per_cozonac < 0:
       is_money_enough = False
   else:
        budget -= needed_money_per_cozonac
        cozonacs_count += 1
        eggs_count += 1

        if counter % 3 == 0:
            eggs_count -= cozonacs_count - 2

   counter += 1

print(f"You made {cozonacs_count} cozonacs! Now you have {eggs_count} eggs and {budget:.2f}BGN left.")
