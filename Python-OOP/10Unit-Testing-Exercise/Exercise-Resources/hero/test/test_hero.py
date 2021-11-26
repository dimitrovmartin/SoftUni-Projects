import unittest
from project.hero import Hero


class HeroTests(unittest.TestCase):
    def setUp(self):
        self.hero = Hero('Ivo', 200, 2000, 100)

    def test_init(self):
        self.assertEqual(self.hero.username, 'Ivo')
        self.assertEqual(self.hero.level, 200)
        self.assertEqual(self.hero.health, 2000)
        self.assertEqual(self.hero.damage, 100)

    def test_battle_hero_wins(self):
        enemy_hero = Hero('Kiril', 2, 10, 50)
        enemy_hero_damage = enemy_hero.damage * enemy_hero.level

        expected_hero_health = self.hero.health - enemy_hero_damage + 5
        expected_hero_level = self.hero.level + 1
        expected_hero_damage = self.hero.damage + 5

        result = self.hero.battle(enemy_hero)

        self.assertEqual(result, 'You win')
        self.assertEqual(self.hero.health, expected_hero_health)
        self.assertEqual(self.hero.level, expected_hero_level)
        self.assertEqual(self.hero.damage, expected_hero_damage)

    def test_battle_draw(self):
        enemy_hero = Hero('Kiril', 100, 10, 50)

        result = self.hero.battle(enemy_hero)

        self.assertEqual(result, 'Draw')

    def test_battle_hero_lose(self):
        enemy_hero = Hero('Kiril', 1000, 100000, 50)
        player_damage = self.hero.damage * self.hero.level
        expected_enemy_hero_health = enemy_hero.health - player_damage + 5
        expected_enemy_hero_level = enemy_hero.level + 1
        expected_enemy_hero_damage = enemy_hero.damage + 5

        result = self.hero.battle(enemy_hero)

        self.assertEqual(result, 'You lose')

        self.assertEqual(enemy_hero.health, expected_enemy_hero_health)
        self.assertEqual(enemy_hero.level, expected_enemy_hero_level)
        self.assertEqual(enemy_hero.damage, expected_enemy_hero_damage)

    def test_battle_raises_exception(self):
        with self.assertRaises(Exception) as ex:
            self.hero.battle(self.hero)

        self.assertEqual(str(ex.exception), "You cannot fight yourself")

    def test_battle_raises_value_error_if_hero_health_equals_zero_or_negative(self):
        enemy_hero = Hero('Kiril', 2, 10, 50)
        self.hero.health = 0

        with self.assertRaises(Exception) as ex:
            self.hero.battle(enemy_hero)

        self.assertEqual(str(ex.exception), "Your health is lower than or equal to 0. You need to rest")

    def test_battle_raises_value_error_if_enemy_hero_health_equals_zero_or_negative(self):
        enemy_hero = Hero('Kiril', 2, 0, 50)

        with self.assertRaises(Exception) as ex:
            self.hero.battle(enemy_hero)

        self.assertEqual(str(ex.exception), f"You cannot fight {enemy_hero.username}. He needs to rest")

    def test_str(self):
        self.assertEqual(str(self.hero),
                         f"Hero {self.hero.username}: {self.hero.level} lvl\nHealth: {self.hero.health}\nDamage: {self.hero.damage}\n")
