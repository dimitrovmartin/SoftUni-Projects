#90/100

import unittest

from project.student import Student


class StudentTests(unittest.TestCase):
    def setUp(self):
        self.student = Student('Ivancho')
        self.other_student = Student('Chochko', {'JS': [], 'React': []})

    def test_init_without_courses(self):
        self.assertEqual(self.student.name, 'Ivancho')
        self.assertEqual(self.student.courses, {})

    def test_init_with_courses(self):
        self.assertEqual(self.other_student.name, 'Chochko')
        self.assertEqual(self.other_student.courses, {'JS': [], 'React': []})

    def test_enroll_is_course_already_added(self):
        result = self.other_student.enroll('JS', ['js', 'notes'])

        self.assertEqual(result, "Course already added. Notes have been updated.")
        self.assertEqual(self.other_student.courses['JS'], ['js', 'notes'])

    def test_enroll_is_course_is_not_added(self):
        result = self.other_student.enroll('C#', ['c#', 'notes'])

        self.assertEqual(result, "Course and course notes have been added.")
        self.assertEqual(self.other_student.courses['C#'], ['c#', 'notes'])

    def test_enroll_is_course_is_not_added_and_add_course_notes_is_y(self):
        result = self.other_student.enroll('C#', ['c#', 'notes'], "Y")

        self.assertEqual(result, "Course and course notes have been added.")
        self.assertEqual(self.other_student.courses['C#'], ['c#', 'notes'])

    def test_enroll_is_course_is_not_added_and_add_course_notes_is_n(self):
        result = self.other_student.enroll('C#', [], "n")

        self.assertEqual(result, "Course has been added.")
        self.assertEqual(self.other_student.courses['C#'], [])

    def test_add_notes(self):
        result = self.other_student.add_notes('JS', 'Angular')

        self.assertEqual(result, "Notes have been updated")
        self.assertEqual('Angular', self.other_student.courses['JS'][-1])

    def test_add_notes_raises(self):
        with self.assertRaises(Exception) as ex:
            self.other_student.add_notes('c#', 'c#')

        self.assertEqual(str(ex.exception), 'Cannot add notes. Course not found.')

    def test_leave_course(self):
        result = self.other_student.leave_course('JS')
        result2 = 'JS' not in self.other_student.courses.keys()

        self.assertEqual(result, "Course has been removed")
        self.assertEqual(result2, True)

    def test_leave_course_should_empty_dict(self):
        self.other_student.leave_course('JS')
        self.other_student.leave_course('React')

        self.assertEqual(self.other_student.courses, {})

    def test_leave_course_raises(self):
        with self.assertRaises(Exception) as ex:
            self.other_student.leave_course('Java')

        self.assertEqual(str(ex.exception), "Cannot remove course. Course not found.")