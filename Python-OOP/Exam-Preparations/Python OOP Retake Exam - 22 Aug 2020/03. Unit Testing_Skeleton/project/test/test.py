import unittest

from project.student_report_card import StudentReportCard


class StudentTests(unittest.TestCase):
    def setUp(self):
        self.student = StudentReportCard('Pepo', 3)

    def test_init(self):
        self.assertEqual(self.student.student_name, 'Pepo')
        self.assertEqual(self.student.school_year, 3)
        self.assertEqual(self.student.grades_by_subject, {})

    def test_student_name_raises(self):
        with self.assertRaises(ValueError) as ex:
            self.student.student_name = ''

        self.assertEqual(str(ex.exception), "Student Name cannot be an empty string!")

    def test_school_year_raises(self):
        with self.assertRaises(ValueError) as ex:
            self.student.school_year = 0

        self.assertEqual(str(ex.exception), "School Year must be between 1 and 12!")

        with self.assertRaises(ValueError) as ex:
            self.student.school_year = 13

        self.assertEqual(str(ex.exception), "School Year must be between 1 and 12!")

    def test_add_grade(self):
        self.student.add_grade('JS', 4)

        self.assertEqual(True, 'JS' in self.student.grades_by_subject.keys())
        self.assertEqual(self.student.grades_by_subject['JS'], [4])

        self.student.add_grade('JS', 5)
        self.assertEqual(self.student.grades_by_subject['JS'], [4, 5])

    def test_average_grade(self):
        self.student.add_grade('JS', 4)
        self.student.add_grade('JS', 5)
        self.student.add_grade('JS', 6)

        result = self.student.average_grade_by_subject()
        self.assertEqual(result, f"JS: 5.00")

    def test_average_grade_for_all_subjects(self):
        self.student.add_grade('JS', 4)
        self.student.add_grade('JS', 5)
        self.student.add_grade('JS', 6)
        self.student.add_grade('C#', 4)
        self.student.add_grade('C#', 5)
        self.student.add_grade('C#', 6)

        result = self.student.average_grade_for_all_subjects()

        self.assertEqual(result, f"Average Grade: 5.00")

    def test_repr(self):
        self.student.add_grade('JS', 4)
        self.student.add_grade('JS', 5)
        self.student.add_grade('JS', 6)

        report = f"Name: Pepo\n" \
                 f"Year: 3\n" \
                 f"----------\n" \
                 f"JS: 5.00\n" \
                 f"----------\n" \
                 f"Average Grade: 5.00"

        self.assertEqual(repr(self.student), report)
