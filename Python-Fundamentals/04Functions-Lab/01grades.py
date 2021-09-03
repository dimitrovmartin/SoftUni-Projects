def get_grade_as_string(grade):
    if 2 <= grade <= 2.99:
        return "Fail"
    elif 3 <= grade <= 3.49:
        return "Poor"
    elif 3.50 <= grade <= 4.49:
        return "Good"
    elif 4.50 <= grade <= 5.49:
        return "Very Good"
    elif 5.50 <= grade <= 6:
        return "Excellent"


grade_data = float(input())

grade_as_string = get_grade_as_string(grade_data)

print(grade_as_string)
