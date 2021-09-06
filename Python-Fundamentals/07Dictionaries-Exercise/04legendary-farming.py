def add_material(key_materials_by_quantity: dict, junks_by_quantity: dict, quantity: int, material: str):
    if material in key_materials_by_quantity.keys():
        key_materials_by_quantity[material] += quantity
    else:
        if material in junks_by_quantity:
            junks_by_quantity[material] += quantity
        else:
            junks_by_quantity[material] = quantity


key_materials_by_quantity = {"shards": 0, "fragments": 0, "motes": 0}
junks_by_quantity = {}

obtained_item = ""

while obtained_item == "":
    materials_data = input().split()

    for i in range(0, len(materials_data), 2):
        quantity = int(materials_data[i])
        material = materials_data[i + 1].lower()

        add_material(key_materials_by_quantity, junks_by_quantity, quantity, material)

        if key_materials_by_quantity["shards"] >= 250:
            obtained_item = "Shadowmourne"
            key_materials_by_quantity["shards"] -= 250
            break
        elif key_materials_by_quantity["fragments"] >= 250:
            obtained_item = "Valanyr"
            key_materials_by_quantity["fragments"] -= 250
            break
        elif key_materials_by_quantity["motes"] >= 250:
            obtained_item = "Dragonwrath"
            key_materials_by_quantity["motes"] -= 250
            break

key_materials_by_quantity = sorted(key_materials_by_quantity.items(), key=lambda x: (-x[1], x[0]))
junks_by_quantity = sorted(junks_by_quantity.items(), key=lambda x: x[0])

print(f"{obtained_item} obtained!")

for key, value in key_materials_by_quantity:
    print(f"{key}: {value}")

for key, value in junks_by_quantity:
    print(f"{key}: {value}")



