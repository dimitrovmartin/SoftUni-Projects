from math import floor


class Integer:
    def __init__(self, value):
        self.value = value

    @classmethod
    def from_roman(cls, roman_number):
        rom_val = {'I': 1, 'V': 5, 'X': 10, 'L': 50, 'C': 100, 'D': 500, 'M': 1000}
        int_val = 0
        for i in range(len(roman_number)):
            if i > 0 and rom_val[roman_number[i]] > rom_val[roman_number[i - 1]]:
                int_val += rom_val[roman_number[i]] - 2 * rom_val[roman_number[i - 1]]
            else:
                int_val += rom_val[roman_number[i]]
        return cls(int_val)

    @classmethod
    def from_float(cls, float_number):
        if not isinstance(float_number, float):
            return 'value is not a float'
        return cls(floor(float_number))

    @classmethod
    def from_string(cls, string_number):
        if not isinstance(string_number, str) or not string_number.isnumeric():
            return 'wrong type'
        return cls(int(string_number))


first_num = Integer(10)
second_num = Integer.from_roman("IV")

print(Integer.from_float("2.6"))
print(Integer.from_string(2.6))
