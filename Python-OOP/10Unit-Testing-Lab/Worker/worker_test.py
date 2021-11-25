import unittest

from worker import Worker


class WorkersTest(unittest.TestCase):
    def setUp(self):
        self.worker = Worker('George', 2000, 60)

    def test_init(self):
        self.assertEqual(self.worker.name, 'George')
        self.assertEqual(self.worker.salary, 2000)
        self.assertEqual(self.worker.energy, 60)

    def test_if_energy_raised_when_worker_rest(self):
        self.worker.rest()
        self.assertEqual(self.worker.energy, 61)

    def test_if_error_raised_when_worker_tries_to_work_with_negative_energy(self):
        self.worker.energy = 0

        with self.assertRaises(Exception) as ex:
            self.worker.work()

        self.assertEqual(str(ex.exception), 'Not enough energy.')

    def test_salary_raise_when_worker_works(self):
        self.worker.work()

        self.assertEqual(self.worker.money, self.worker.salary)

    def test_worker_energy_is_decreased_when_worker_works(self):
        self.worker.work()

        self.assertEqual(self.worker.energy, 59)

    def test_get_info(self):
        self.assertEqual(self.worker.get_info(), f'{self.worker.name} has saved {self.worker.money} money.')

if __name__ == '__main__':
    unittest.main()