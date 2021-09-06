students_by_courses = {}

line = input()

while ":" in line:
    name, id, course = line.split(":")

    if course not in students_by_courses:
        students_by_courses[course] = {}

    students_by_courses[course][id] = name

    line = input()

searched_course_data = line.split("_")
searched_course_name = " ".join(searched_course_data)

for key, value in students_by_courses[searched_course_name].items():
    print(f"{value} - {key}")
    