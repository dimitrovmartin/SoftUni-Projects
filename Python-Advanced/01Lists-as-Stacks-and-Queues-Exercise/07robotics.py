#50/100

import datetime
from time import strftime
from collections import deque


def datetime_to_seconds(hours, minutes, seconds):
    t = datetime.time(hours, minutes, seconds)
    time_in_seconds = (int(datetime.timedelta(hours=t.hour, minutes=t.minute, seconds=t.second).total_seconds()))

    return time_in_seconds


def seconds_to_tuple(time_in_seconds):
     hours = time_in_seconds // 3600
     minutes = time_in_seconds // 60 % 60
     seconds = time_in_seconds % 60
     if hours == 24:
         hours = 0

     return hours, minutes, seconds


class Robot:
    def __init__(self, name, process_time):
        self.name = name
        self.process_time = process_time
        self.busy_until = 0


robots_data = input().split(";")
hours, minutes, seconds = [int(value) for value in input().split(":")]

time_in_seconds = datetime_to_seconds(hours, minutes, seconds)
robots = []

for robot_data in robots_data:
    robot_name, process_time = robot_data.split("-")

    robot = Robot(robot_name, int(process_time))
    robots.append(robot)

products = deque()

product = input()

while not product == "End":
    products.append(product)
    product = input()

while products:
    current_product = products[0]
    time_in_seconds += 1
    is_processed = False

    for robot in robots:
        if robot.busy_until <= time_in_seconds:
            hours, minutes, seconds = seconds_to_tuple(time_in_seconds)

            robot.busy_until = time_in_seconds + robot.process_time

            is_processed = True
            print(f"{robot.name} - {current_product} [{hours:02d}:{minutes:02d}:{seconds:02d}]")
            break

    current_product = products.popleft()
    if not is_processed:
        products.append(current_product)

